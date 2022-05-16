-- Queries for SoftUni Database

--1.Examine the Databases

--2.Find All Information About Departments
use SoftUni
select *
from Departments
--2.Find All Information About Departments

--3.Find all Department Names
select name
from Departments
--3.Find all Department Names

--4.Find Salary of Each Employee
select FirstName, LastName, Salary
from Employees
--4.Find Salary of Each Employee

--5.Find Full Name of Each Employee
select FirstName, MiddleName, LastName
from Employees
--5.Find Full Name of Each Employee

--6.Find Email Address of Each Employee
select FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
from Employees
--6.Find Email Address of Each Employee

--7.Find All Different Employee’s Salaries
select distinct Salary
from Employees
--7.Find All Different Employee’s Salaries

--8.Find all Information About Employees
select *
from Employees
where JobTitle = 'Sales Representative'
--8.Find all Information About Employees

--9.Find Names of All Employees by Salary in Range
select FirstName, LastName, JobTitle
from Employees
where Salary between 20000 and 30000
--9.Find Names of All Employees by Salary in Range

--10.Find Names of All Employees
select FirstName + ' ' + MiddleName + ' ' + LastName as [Full Name]
from Employees
where Salary in (25000, 14000, 12500, 23600)
--10.Find Names of All Employees

--11.Find All Employees Without Manager
select FirstName, LastName
from Employees
where ManagerID is null
--11.Find All Employees Without Manager

--12.Find All Employees with Salary More Than 50000//Order the result in decreasing order by salary
select FirstName, LastName, Salary
from Employees
where Salary > 50000
order by Salary desc
--12.Find All Employees with Salary More Than 50000

--13.Find 5 Best Paid Employees.//ordered in descending by their salary
select top 5 FirstName, LastName
from Employees
order by Salary desc
--13.Find 5 Best Paid Employees.

--14.Find All Employees Except Marketing
select FirstName, LastName
from Employees
where DepartmentID != 4
--14.Find All Employees Except Marketing

--15.Sort Employees Table
/*By salary in decreasing order
Then by the first name alphabetically
Then by the last name descending
Then by middle name alphabetically*/
select *
from Employees
order by Salary desc, FirstName, LastName desc, MiddleName
--15.Sort Employees Table

--16.Create View Employees with Salaries
create view V_EmployeesSalaries as
select FirstName, LastName, Salary
from Employees
select*
from V_EmployeesSalaries
--16.Create View Employees with Salaries

--17.Create View Employees with Job Titles
create view V_EmployeeNameJobTitle as
select FirstName + ' ' + isnull(MiddleName, '') + ' ' + LastName as 'Full Name', JobTitle
from Employees
--17.Create View Employees with Job Titles

--18.Distinct Job Titles
select distinct JobTitle
from Employees
--18.Distinct Job Titles

--19.Find First 10 Started Projects
select top 10 *
from Projects
order by startdate, [name]
--19.Find First 10 Started Projects

--20.Last 7 Hired Employees
select top 7 FirstName, LastName, HireDate
from Employees
order by HireDate desc
--20.Last 7 Hired Employees


--21.Increase Salaries
update Employees
set Salary *= 1.12
where DepartmentID in (select DepartmentID
                       from Departments
                       where name in ('Engineering', 'Tool Design', 'Marketing', 'Information Services'))
select Salary from  Employees


drop  database SoftUni
--21.Increase Salaries

-- Queries for Geography Database

--22. All Mountain Peaks
select PeakName
from Peaks
order by PeakName
--22. All Mountain Peaks

--23. Biggest Countries by Population
select top 30 CountryName, [Population]
from Countries
where ContinentCode = 'EU'
order by Population desc, CountryName
--23. Biggest Countries by Population

--24. *Countries and Currency (Euro / Not Euro)
select CountryName,
       CountryCode,
       case
           when CurrencyCode = 'EUR'
               then 'Euro'
           else 'Not Euro'
           end
           as Currency
from Countries
order by CountryName
--24. *Countries and Currency (Euro / Not Euro)

--Queries for Diablo Database

use Diablo
--25.All Diablo Characters
--Display all characters in alphabetical order.
select Name from Characters order by Name
--25.All Diablo Characters
