--
--Part I – Queries for SoftUni Database
--

use SoftUni1
--1.Find Names of All Employees by First Name
select FirstName, LastName
from Employees
where FirstName like 'Sa%'
--1.Find Names of All Employees by First Name

--2.Find Names of All employees by Last Name
select FirstName, LastName
from Employees
where LastName like '%ei%'
--2.Find Names of All employees by Last Name

--3.Find First Names of All Employees
select FirstName
from Employees
where DepartmentID in (3, 10)
  and year(HireDate) between 1995 and 2005
--3.Find First Names of All Employees

--4.Find All Employees Except Engineers
select FirstName, LastName
from Employees
where JobTitle not like '%Engineer%'
--4.Find All Employees Except Engineers

--5.Find Towns with Name Length
select Name
from Towns
where len(Name) in (5, 6)
order by Name
--5.Find Towns with Name Length

--6.Find Towns Starting With
select *
from Towns
where left(Name, 1) in ('M', 'K', 'B', 'E')
order by Name
--6.Find Towns Starting With

--7.Find Towns Not Starting With
select *
from Towns
where left(Name, 1) not in ('R', 'B', 'D')
order by Name
--7.Find Towns Not Starting With

--8.Create View Employees Hired After 2000 Year
create view V_EmployeesHiredAfter2000 as
select FirstName, LastName
from Employees
where year(HireDate) > 2000
--8.Create View Employees Hired After 2000 Year

--9.Length of Last Name
select FirstName, LastName
from Employees
where len(LastName) = 5
--9.Length of Last Name

--10.Rank Employees by Salary
select EmployeeID,
       FirstName,
       LastName,
       Salary,
       dense_rank() over (partition by Salary order by EmployeeID) as Rank
from Employees
where Salary between 10000 and 50000
order by Salary desc
--10.Rank Employees by Salary

--11.Find All Employees with Rank 2 *
select *
from (select EmployeeID,
             FirstName,
             LastName,
             Salary,
             dense_rank() over (partition by Salary order by EmployeeID) as Rank
      from Employees
      where Salary between 10000 and 50000) as MyTable
where Rank = 2
order by Salary desc
--11.Find All Employees with Rank 2 *


--
--Part II – Queries for Geography Database
--
use Geography

--12.Countries Holding ‘A’ 3 or More Times
select CountryName, IsoCode
from Countries
where CountryName like '%a%a%a%'
order by IsoCode
--12.Countries Holding ‘A’ 3 or More Times

--13. Mix of Peak and River Names
select p.PeakName,
       r.RiverName,
       lower(concat(p.PeakName, substring(r.RiverName, 2, Length))) as Mix
from Peaks as p,
     Rivers as r
where lower(right(p.PeakName, 1)) = lower(left(r.RiverName, 1))
order by Mix
--13. Mix of Peak and River Names


--Part III – Queries for Diablo Database
use Diablo

--14.Games from 2011 and 2012 year
select top 50 [Name], convert(date, Start) as Start
from Games
where year(Start) between 2011 and 2012
order by Start, Name
--14.Games from 2011 and 2012 year

--15.User Email Providers
select [Username], right(Email, charindex('@', reverse(Email)) - 1) as 'Email Provider'
from Users
order by [Email Provider], Username
--15.User Email Providers

--16.Get Users with IPAdress Like Pattern
select [Username], IpAddress
from Users
where IpAddress like '___.1%.%.___'
order by Username
--16.Get Users with IPAdress Like Pattern

--17.Show All Games with Duration and Part of the Day
select [Name] as [Game],
       case
           when datepart(hour, [Start]) >= 0 and datepart(hour, [Start]) < 12 then 'Morning'
           when datepart(hour, [Start]) >= 12 and datepart(hour, [Start]) < 18 then 'Afternoon'
           else 'Evening'
           end
              as [Part of the Day],
       case
           when Duration <= 3 then 'Extra Short'
           when Duration between 4 and 6 then 'Short'
           when Duration > 6 then 'Long'
           else 'Extra Long'
           end
              as 'Duration'
from [Games]
order by [Game], [Duration], [Part of the Day]
--17.Show All Games with Duration and Part of the Day

--Part IV – Date Functions Queries
use Orders

--18.Orders Table
select ProductName,
       OrderDate,
       dateadd(day,3,Orderdate) as 'Pay Due',
       dateadd(month ,1,Orderdate) as 'Deliver Due'
from Orders
--18.Orders Table
