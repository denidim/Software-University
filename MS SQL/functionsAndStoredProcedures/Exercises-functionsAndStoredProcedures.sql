-- lab
--scalar function
CREATE FUNCTION udf_ProjectDurationWeeks(@Start DATETIME, @End DATETIME)
    RETURNS INT
AS
BEGIN
    DECLARE @projectWeeks INT;
    IF (@End IS NULL)
        BEGIN
            SET @End = GETDATE()
        END
    SET @projectWeeks = DATEDIFF(WEEK, @Start, @End)
    RETURN @projectWeeks;
END
--scalar function
select ProjectID,
       [Name],
       StartDate,
       EndDate,
       dbo.udf_ProjectDurationWeeks(StartDate, EndDate)
           as ProjectDurationWeeks
from projects
where dbo.udf_ProjectDurationWeeks(StartDate, EndDate) > 800
--scalar function

--table-valued function
CREATE FUNCTION udf_AverageSalaryByDepartment()
    RETURNS TABLE AS
        RETURN
            (
                SELECT d.[Name] AS Department, AVG(e.Salary) AS AverageSalary
                FROM Departments AS d
                         JOIN Employees AS e ON d.DepartmentID = e.DepartmentID
                GROUP BY d.DepartmentID, d.[Name]
            )

select *
from udf_AverageSalaryByDepartment()
where AverageSalary > 20000
--table-valued function

--problem: salary level function
create function udf_GetSalaryLevel(@Salary money)
    returns varchar(10)
as
begin
    declare @SalaryLevel varchar(10)
    if (@Salary < 30000)
        set @SalaryLevel = 'Low'
    else
        if (@Salary between 30000 and 50000)
            set @SalaryLevel = 'Average'
        else
            set @SalaryLevel = 'High'
    return @SalaryLevel
end

select *,
       dbo.udf_GetSalaryLevel(Salary) as SalaryLevel
from Employees
--problem: salary level function

--stored procedures
create procedure usp_EmployeesProjects
as
select concat(e.FirstName, ' ', e.LastName) as name, p.Name
from Employees as e
         join EmployeesProjects as ep on e.EmployeeID = ep.EmployeeID
         join projects as p on ep.ProjectID = p.ProjectID

    exec usp_EmployeesProjects

--stored procedures
    USE SoftUni1
GO
CREATE PROC dbo.usp_SelectEmployeesBySeniority
AS
SELECT *
FROM Employees
WHERE DATEDIFF(Year, HireDate, GETDATE()) > 20
GO
exec usp_SelectEmployeesBySeniority

drop procedure usp_SelectEmployeesBySeniority
--parameterized stored procedures
CREATE PROC usp_SelectEmployeesBySeniority(@minYearsAtWork int = 5)
AS
SELECT FirstName,
       LastName,
       HireDate,
       DATEDIFF(Year, HireDate, GETDATE()) as Years
FROM Employees
WHERE DATEDIFF(Year, HireDate, GETDATE()) > @minYearsAtWork
ORDER BY HireDate
GO

EXEC usp_SelectEmployeesBySeniority 21

--Returning Values Using OUTPUT Parameters
CREATE PROCEDURE dbo.usp_AddNumbers @firstNumber SMALLINT,
                                    @secondNumber SMALLINT,
                                    @result INT OUTPUT
AS
    SET @result = @firstNumber + @secondNumber
GO

DECLARE @answer smallint
EXECUTE usp_AddNumbers 5, 6, @answer OUTPUT
SELECT 'The result is: ', @answer
-- The result is: 11

--Returning Multiple Results
CREATE OR ALTER PROC usp_MultipleResults
AS
SELECT FirstName, LastName
FROM Employees
SELECT FirstName, LastName, d.[Name] AS Department
FROM Employees AS e
         JOIN Departments AS d ON e.DepartmentID = d.DepartmentID;
GO
EXEC usp_MultipleResults

--error handling
BEGIN TRY
    -- Generate a divide-by-zero error.
    SELECT 1 / 0
END TRY
BEGIN CATCH
    SELECT ERROR_NUMBER()    AS ErrorNumber
         , ERROR_SEVERITY()  AS ErrorSeverity
         , ERROR_STATE()     AS ErrorState
         , ERROR_PROCEDURE() AS ErrorProcedure
         , ERROR_LINE()      AS ErrorLine
         , ERROR_MESSAGE()   AS ErrorMessage;
END CATCH
GO

--problem:Employees with Three Projects
create or alter proc usp_AddEmployeeToProject(@EmployeeID int, @ProjectID int)
as
begin
    declare @employeeProjectNumber int
    set @employeeProjectNumber = (select count(*) from EmployeesProjects where EmployeeID = @EmployeeID)
    if (@employeeProjectNumber > 3)
        throw 50001, 'Too Many Projects',1
    begin try
        insert into EmployeesProjects Values (@EmployeeID, @ProjectID)
    end try
    begin catch
        select error_message()
    end catch
end

select EmployeeID
from EmployeesProjects
group by EmployeeID
having count(*) = 2

select *
from EmployeesProjects
where EmployeeID = 240

    exec dbo.usp_AddEmployeeToProject 1235, 42
-- lab