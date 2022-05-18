-----
--Lab problems:
-----
use SoftUni1
--1:Addresses with towns
select top 50 e.FirstName,
              e.LastName,
              t.Name as Town,
              a.AddressText
from Employees as e
         join Addresses a on a.AddressID = e.AddressID
         join Towns t on a.TownID = t.TownID
order by FirstName, LastName
--1:Addresses with towns

--2:Sales Employees
select e.EmployeeID,
       e.FirstName,
       e.LastName,
       d.Name as DepartmentName
from Employees as e
         join Departments as d on d.DepartmentID = e.DepartmentID
where d.Name = 'Sales'
order by e.EmployeeID
--2:Sales Employees

--3:Employees Hired After
select e.FirstName,
       e.LastName,
       e.HireDate,
       d.Name as DeptName
from Employees as e
         join Departments as d on d.DepartmentID = e.DepartmentID
where d.Name in ('Sales', 'Finance')
  and e.HireDate > year(1 / 1 / 1999)
order by HireDate
--3:Employees Hired After

--4:Employee Summary
select top 50 e.EmployeeID,
              concat(e.FirstName, ' ', e.LastName) as EmployeeName,
              concat(m.FirstName, ' ', m.LastName) as ManagerName,
              d.Name                               as DepartmentName
from Employees as e
         left join Employees as m on m.EmployeeID = e.ManagerID
         left join Departments as d on d.DepartmentID = e.DepartmentID
order by e.EmployeeID
--4:Employee Summary


--
--Subqueries
--
select *
from Employees as e
where e.DepartmentID in
      (select d.DepartmentID
       from Departments as d
       where d.Name = 'Sales')
--

select *
from (select *
      from Employees
      where JobTitle like 'Production%') as e
where e.HireDate > '1/04/2002'

--1:Min Average Salary
select min(s.avgSalary)
from (select avg(Salary) as avgSalary
      from Employees
      group by DepartmentID) as s
------
select top (1) avg(e.Salary)
from Employees as e
         join Departments as d on d.DepartmentID = e.DepartmentID
group by d.DepartmentID
order by avg(e.Salary)
--1:Min Average Salary

------
--CTE (Common Table Expression)
-----
with avgSalary_CTE (avgSalary, DepartmentName)
         as
         (select avg(Salary) as avgSalary,
                 d.Name
          from Employees as e
                   join Departments d on d.DepartmentID = e.DepartmentID
          group by e.DepartmentID, d.Name)
select *
from avgSalary_CTE as a
where a.avgSalary =
      (select min(avgSalary) from avgSalary_CTE)

-----
--Exercises: Subqueries and Joins
----

--1.Employee Address
select top 5 e.EmployeeID,
             e.JobTitle,
             a.AddressID,
             a.AddressText
from Employees as e
         join Addresses as a on a.AddressID = e.AddressID
order by AddressID
--1.Employee Address

--2.Addresses with Towns
select top 50 e.FirstName,
              e.LastName,
              t.Name,
              a.AddressText
from Employees as e
         join Addresses as a on e.AddressID = a.AddressID
         join Towns as t on a.TownID = t.TownID
order by FirstName, LastName
--2.Addresses with Towns

--3.Sales Employee
select e.EmployeeID,
       e.FirstName,
       e.LastName,
       d.Name
from Employees as e
         join Departments D on D.DepartmentID = e.DepartmentID
where d.Name = 'Sales'
order by EmployeeID
--3.Sales Employee

--4.Employee Departments
select top 5 e.EmployeeID,
             e.FirstName,
             e.Salary,
             d.Name
from Employees as e
         join Departments D on D.DepartmentID = e.DepartmentID
where e.Salary > 15000
order by e.DepartmentID
--4.Employee Departments

--5.Employees Without Project
select top 3 e.EmployeeID,
             e.FirstName
from Employees as e
         full join EmployeesProjects as ep
                   on e.EmployeeID = ep.EmployeeID
where ep.ProjectID is null
order by e.EmployeeID
--5.Employees Without Project

--6.Employees Hired After
select e.FirstName,
       e.LastName,
       e.HireDate,
       d.Name as DeptName
from Employees as e
         join Departments as d on d.DepartmentID = e.DepartmentID
where d.Name in ('Sales', 'Finance')
  and e.HireDate > year(1 / 1 / 1999)
order by HireDate
--6.Employees Hired After

--7.Employees with Project
select top 5 e.EmployeeID,
             e.FirstName,
             p.Name as ProjectName
from Employees as e
         join EmployeesProjects as ep on e.EmployeeID = ep.EmployeeID
         join Projects as p on ep.ProjectID = p.ProjectID
where p.StartDate > '08/13/2002'
  and p.EndDate is null
order by e.EmployeeID
--7.Employees with Project

--8.Employee 24
select e.EmployeeID,
       e.FirstName,
       --p.Name as ProjectName,
       case
           when p.StartDate >= '2005' then null
           else p.Name
           end
           as ProjectName
from Employees as e
         join EmployeesProjects as ep on e.EmployeeID = ep.EmployeeID and e.EmployeeID = 24
         join Projects as p on ep.ProjectID = p.ProjectID
--8.Employee 24

--9.Employee Manager
select e.EmployeeID,
       e.FirstName,
       m.EmployeeID,
       m.FirstName as ManagerName
from Employees as e
         join Employees as m on e.ManagerID = m.EmployeeID
where e.ManagerID in (3, 7)
order by e.EmployeeID
--9.Employee Manager

--10.Employee Summary
select top 50 e.EmployeeID,
              concat(e.FirstName, ' ', e.LastName) as EmployeeName,
              concat(m.FirstName, ' ', m.LastName) as ManagerName,
              d.Name                               as DepartmentName
from Employees as e
         left join Employees as m on m.EmployeeID = e.ManagerID
         left join Departments as d on d.DepartmentID = e.DepartmentID
order by e.EmployeeID
--10.Employee Summary

--11.Min Average Salary
select min(s.avgSalary)
from (select avg(Salary) as avgSalary
      from Employees
      group by DepartmentID) as s
--11.Min Average Salary

--12.Highest Peaks in Bulgaria
use Geography

select c.CountryCode,
       m.MountainRange,
       p.PeakName,
       p.Elevation
from Countries as c
         join MountainsCountries as mc on c.CountryCode = mc.CountryCode
         join Mountains as m on mc.MountainId = m.Id
         join Peaks as p on m.Id = p.MountainId
where CountryName = 'Bulgaria'
  and p.Elevation > 2835
order by p.Elevation desc
--12.Highest Peaks in Bulgaria

--13.Count Mountain Ranges
select c.CountryCode,
       count(MC.MountainId) as MountainRanges
from Countries as c
         left join MountainsCountries MC on c.CountryCode = MC.CountryCode
where c.CountryCode in ('BG', 'RU', 'US')
group by c.CountryCode
--13.Count Mountain Ranges

--14.Countries with Rivers
select top 5 c.CountryName,
             r.RiverName
from Countries as c
         full join CountriesRivers as cr on c.CountryCode = cr.CountryCode
         full join Rivers as r on cr.RiverId = r.Id
where c.ContinentCode = 'AF'
order by c.CountryName asc
--14.Countries with Rivers

--15.*Continents and Currencies
select ContinentCode,
       CurrencyCode,
       CurrencyUsage
from (select *
           , dense_rank() over (partition by ContinentCode order by CurrencyUsage desc ) as CurrencyRank
      from (select ContinentCode,
                   CurrencyCode,
                   count(CurrencyCode) as CurrencyUsage
            from Countries
            group by ContinentCode, CurrencyCode) as ccs
      where CurrencyUsage > 1)
         as CurrRankSubQ
where CurrencyRank = 1
order by ContinentCode
--15.*Continents and Currencies

--16.Countries Without Any Mountains
select count(c.CountryCode) as Count
from Countries as c
         full join MountainsCountries MC on c.CountryCode = MC.CountryCode
where mc.CountryCode is null
--16.Countries Without Any Mountains

--17.Highest Peak and Longest River by Country
select top 5
    c.CountryName,
             max(p.Elevation) as HighestPeakElevation,
             max(r.Length)    as LongestRiverLength
      from Countries as c
               full join MountainsCountries MC on c.CountryCode = MC.CountryCode
               full join Peaks P on MC.MountainId = P.MountainId
               full join CountriesRivers CR on c.CountryCode = CR.CountryCode
               full join Rivers R on R.Id = CR.RiverId
      group by c.CountryName--) as myTable
order by HighestPeakElevation desc, LongestRiverLength desc, CountryName

--17.Highest Peak and Longest River by Country

--18.Highest Peak Name and Elevation by Country
SELECT TOP (5) WITH TIES c.CountryName, ISNULL(p.PeakName, '(no highest peak)') AS 'HighestPeakName', ISNULL(MAX(p.Elevation), 0) AS 'HighestPeakElevation', ISNULL(m.MountainRange, '(no mountain)')
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange
ORDER BY c.CountryName, p.PeakName
--19.Highest Peak Name and Elevation by Country

