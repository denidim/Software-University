--1.Records’ Count
--use Gringotts
select count(w.id) as Count
from WizzardDeposits as w
--1.Records’ Count

--2.Longest Magic Wand
select max(MagicWandSize) as LongestMagicWand
from WizzardDeposits
--2.Longest Magic Wand

--3.Longest Magic Wand Per Deposit Groups
select DepositGroup,
       max(MagicWandSize) as LongestMagicWand
from WizzardDeposits
group by DepositGroup
--3.Longest Magic Wand Per Deposit Groups

--4.* Smallest Deposit Group Per Magic Wand Size
select top 2 DepositGroup
from WizzardDeposits as wd
group by DepositGroup
order by avg(MagicWandSize)
--4.* Smallest Deposit Group Per Magic Wand Size

--5.Deposits Sum
select DepositGroup,
       sum(DepositAmount) as TotalSum
from WizzardDeposits
group by DepositGroup
--5.Deposits Sum

--6.Deposits Sum for Ollivander Family
select DepositGroup,
       sum(DepositAmount) as TotalSum
from WizzardDeposits
where MagicWandCreator = 'Ollivander family'
group by DepositGroup
--6.Deposits Sum for Ollivander Family

--7.Deposits Filter
select DepositGroup,
       sum(DepositAmount) as TotalSum
from WizzardDeposits
where MagicWandCreator = 'Ollivander family'
group by DepositGroup
having sum(DepositAmount) < 150000
order by sum(DepositAmount) desc
--7.Deposits Filter

--8.Deposit Charge
select DepositGroup,
       MagicWandCreator,
       min(DepositCharge) as MinDepostCharge
from WizzardDeposits
group by DepositGroup, MagicWandCreator
--8.Deposit Charge

--9.Age Groups
select AgeGroup,
       count(Age)
FROM (select age,
             case
                 when Age between 0 and 10 then '[0-10]'
                 when Age between 11 and 20 then '[11-20]'
                 when Age between 21 and 30 then '[21-30]'
                 when Age between 31 and 40 then '[31-40]'
                 when Age between 41 and 50 then '[41-50]'
                 when Age between 51 and 60 then '[51-60]'
                 else '[61+]'
                 end
                 as AgeGroup
      from WizzardDeposits)
         as myQ
group by AgeGroup
--9.Age Groups

--10.First Letter
select distinct left(FirstName, 1) as FirstLetter
from WizzardDeposits
where DepositGroup = 'Troll Chest'
group by FirstName
--10.First Letter

--11.Average Interest
select DepositGroup,
       IsDepositExpired,
       avg(DepositInterest) as AverageInterest
from WizzardDeposits
where DepositStartDate > '01/01/1985'
group by DepositGroup, IsDepositExpired
order by DepositGroup desc, IsDepositExpired asc
--11.Average Interest

--12.* Rich Wizard, Poor Wizard
select sum(difference)
from (select FirstName                                              as HostWizard,
             DepositAmount                                          as HowstWizardDeposit,
             lead(FirstName) over (order by Id)                     as GuestWizard,
             lead(DepositAmount) over (order by id)                 as GuestWizardDeposit,
             DepositAmount - lead(DepositAmount) over (order by id) as difference
      from WizzardDeposits) as myQ
--12.* Rich Wizard, Poor Wizard

--13.Departments Total Salaries
use SoftUni1
select DepartmentID,
       sum(Salary)
from Employees
group by DepartmentID
--13.Departments Total Salaries

--14.Employees Minimum Salaries
select DepartmentID,
       min(Salary)
from Employees
where DepartmentID in (2, 5, 7)
  and HireDate > '01/01/2000'
group by DepartmentID
--14.Employees Minimum Salaries

--15.Employees Average Salaries
select *
into newEmpl
from Employees
where Salary > 30000
delete
from newEmpl
where ManagerID = 42
update newEmpl
set Salary +=5000
where DepartmentID = 1
select DepartmentID,
       avg(Salary) as AverageSalary
from newEmpl
group by DepartmentID
--15.Employees Average Salaries

--16.Employees Maximum Salaries
select DepartmentID,
       max(Salary) as MaxSalary
from Employees
group by DepartmentID
having max(Salary) not between 30000 and 70000
--16.Employees Maximum Salaries

--17.Employees Count Salaries
select count(Salary) as Count
from Employees
where ManagerID is null
--17.Employees Count Salaries

--18.*3rd Highest Salary
select DepartmentID,
       Salary as ThirdHighestSalary
from (select DepartmentID,
             Salary,
             dense_rank() over (partition by DepartmentID order by Salary desc ) as SalaryRank
      from Employees
      group by DepartmentID, Salary) as myQ
where SalaryRank = 3
--18.*3rd Highest Salary

--19.**Salary Challenge
SELECT top 10 e.FirstName,
              e.LastName,
              e.DepartmentID
FROM employees as e
where Salary > (SELECT AVG(subQ.salary) as DepartmentSalary
                FROM employees as subQ
                WHERE subQ.DepartmentID = e.DepartmentID
                GROUP BY subQ.DepartmentID)
ORDER BY e.DepartmentID

--19.**Salary Challenge
