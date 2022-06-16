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

--exercise

--Queries for SoftUni Database

--1.Employees with Salary Above 35000
create procedure usp_GetEmployeesSalaryAbove35000
    as
    select FirstName,LastName
    from Employees
    where Salary > 35000

exec usp_GetEmployeesSalaryAbove35000
--1.Employees with Salary Above 35000

--2.Employees with Salary Above Number
create procedure usp_GetEmployeesSalaryAboveNumber(@number decimal(18,4))
    as
    select FirstName,LastName
    from Employees
    where Salary >= @number

exec usp_GetEmployeesSalaryAboveNumber 48100
--2.Employees with Salary Above Number

--3.Town Names Starting With
create procedure usp_GetTownsStartingWith (@string nvarchar(10))
as
    select [Name] as Town
    from Towns
    where  left([Name] , len(@string)) = @string
go
exec usp_GetTownsStartingWith b
--3.Town Names Starting With

--4.Employees from Town
create procedure usp_GetEmployeesFromTown(@townName nvarchar(50))
as
    select FirstName,LastName
from Employees as e join Addresses A on A.AddressID = e.AddressID
join Towns T on T.TownID = A.TownID
where T.Name = @townName

exec usp_GetEmployeesFromTown Sofia
--4.Employees from Town

--5.Salary Level Function
create or alter function ufn_GetSalaryLevel(@salary DECIMAL(18,4))
returns nvarchar(10)
as
    begin
        declare @salaryLevel varchar(10)
        if(@salary<30000)
            begin
                set @salaryLevel = 'Low'
            end
        else if (@Salary between 30000 and 50000)
            begin
               set @SalaryLevel = 'Average'
            end
        else
            begin
                set @SalaryLevel = 'High'
            end
    return @SalaryLevel
    end

select Salary,
       dbo.ufn_GetSalaryLevel(Salary) as SalaryLevel
from Employees
--5.Salary Level Function

--6.Employees by Salary Level
create or alter procedure usp_EmployeesBySalaryLevel(@level nvarchar(10))
as
    begin
        select FirstName, LastName
        from Employees
        where dbo.ufn_GetSalaryLevel(Salary) =@level
    end

exec usp_EmployeesBySalaryLevel high
--6.Employees by Salary Level

--7.Define Function
create or alter function ufn_IsWordComprised(@setOfLetters nvarchar(20), @word nvarchar(20))
    returns bit
as
    begin
        declare @i int = 1
        declare @letter nvarchar(1)

        while (@i<=len(@word))
            begin
                set @letter = substring(@word, @i, 1)
                if(charindex(@letter,@setOfLetters) = 0)
                      return 0
                set @i += 1
            end
        return 1
    end
--7.Define Function

--8.* Delete Employees and Departments
create procedure usp_DeleteEmployeesFromDepartment(@departmentId INT)
as
    begin
        delete from EmployeesProjects
               where EmployeeID in(select EmployeeID
                                   from Employees
                                   where DepartmentID = @departmentId)

        update Employees
        set ManagerID = null
        where ManagerID in(select EmployeeID
                                   from Employees
                                   where DepartmentID = @departmentId)

        alter table Departments
        alter column ManagerID int null
        update Departments
        set ManagerID = null
        where ManagerID in(select EmployeeID
                                   from Employees
                                   where DepartmentID = @departmentId)

        delete from Employees
        where DepartmentID = @departmentId

        delete from Departments
        where DepartmentID =@departmentId

        select count(*)
        from Employees
        where DepartmentID = @departmentId
    end
--8.* Delete Employees and Departments

--Queries for Bank Database

--9.Find Full Name
create procedure usp_GetHoldersFullName
as
select concat(FirstName, ' ', LastName) as 'Full Name'
from AccountHolders

exec usp_GetHoldersFullName
--9.Find Full Name

--10.People with Balance Higher Than
create or alter procedure usp_GetHoldersWithBalanceHigherThan(@num dec(15,2))
as
begin
    select FirstName, LastName
    from AccountHolders as ah
             join Accounts as a on a.AccountHolderId = ah.Id
    group by FirstName, LastName
    having sum(Balance) > @num
    order by FirstName,LastName
end
go
exec usp_GetHoldersWithBalanceHigherThan 50000
--10.People with Balance Higher Than

--11.Future Value Function
create function ufn_CalculateFutureValue
    (@I decimal(15,2), @R float, @T int)
    returns decimal(15,4)
as
    begin
        declare @result decimal(15,4)
        set @result = @I * power((1+@R),@T)
        return @result
    end

select dbo.ufn_CalculateFutureValue(1000,0.1,5)
--11.Future Value Function

--12.Calculating Interest
create procedure usp_CalculateFutureValueForAccount(@accID int,@interestRate float)
    as
select a.Id,
       ah.FirstName,
       ah.LastName,
       a.Balance,
       dbo.ufn_CalculateFutureValue(a.Balance, 0.1, 5)
from AccountHolders as ah
         join Accounts A on ah.Id = A.AccountHolderId
where a.Id =1

exec usp_CalculateFutureValueForAccount 1, 0.1
--12.Calculating Interest

--Queries for Diablo Database
use Diablo

--13.*Scalar Function: Cash in User Games Odd Rows
create or alter function ufn_CashInUsersGames(@gameName nvarchar(50))
    returns table
        as
        return
            (
                select sum(Cash) as SumCash
                from (select g.Name,
                             ug.Cash,
                             row_number() over (partition by g.Name order by ug.Cash desc) as RowNumber
                      from UsersGames as ug
                               join Games as g on ug.GameId = g.Id
                      where g.Name = @gameName) as RowNumberSubQ
                where RowNumber % 2 != 0
            )
go
select * from ufn_CashInUsersGames('Love in a mist')
--13.*Scalar Function: Cash in User Games Odd Rows
--exercise
