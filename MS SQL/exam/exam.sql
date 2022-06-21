use master
go
create database Zoo
go
use Zoo
create table Owners
(
    Id          int primary key identity,
    [Name]      varchar(50) not Null,
    PhoneNumber varchar(15) not Null,
    [Address]   varchar(50)
)

create table AnimalTypes
(
    Id         int primary key identity,
    AnimalType varchar(30) not null
)

create table Cages
(
    Id           int primary key identity,
    AnimalTypeId int not null references AnimalTypes (Id)
)

create table Animals
(
    Id           int primary key identity,
    [Name]       varchar(30) not null,
    BirthDate    Date        not null,
    OwnerId      int references Owners (id),
    AnimalTypeId int         not null references AnimalTypes (Id)
)

create table AnimalsCages
(
    CageId   int not null references Cages (Id),
    AnimalId int not null references Animals (Id),
    primary key (CageId, AnimalId)
)

create table VolunteersDepartments
(
    Id             int primary key identity,
    DepartmentName varchar(30) not null
)

create table Volunteers
(
    Id           int primary key identity,
    [Name]       varchar(50) not null,
    PhoneNumber  varchar(15) not null,
    [Address]    varchar(50),
    AnimalId     int references Animals (Id),
    DepartmentId int         not null references VolunteersDepartments (Id)
)
--2.
insert into Volunteers(name, phonenumber, address, animalid, departmentid)
values ('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
       ('Dimitur Stoev', '0877564223', null, 42, 4),
       ('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
       ('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
       ('Boryana Mileva', '0888112233', null, 31, 5)

insert into Animals(name, birthdate, ownerid, animaltypeid)
values ('Giraffe', '2018-09-21', 21, 1),
       ('Harpy Eagle', '2015-04-17', 15, 3),
       ('Hamadryas Baboon', '2017-11-02', null, 1),
       ('Tuatara', '2021-06-30', 2, 4)

--3.
update Animals
set OwnerId = (select id from Owners where Owners.Name = 'Kaloqn Stoqnov')

--4.

delete Volunteers
where DepartmentId = (select Id from VolunteersDepartments where DepartmentName = 'Education program assistant')
delete VolunteersDepartments
where DepartmentName = 'Education program assistant'

--5.
select Name,
       PhoneNumber,
       Address,
       AnimalId,
       DepartmentId
from Volunteers
order by Name asc, AnimalId asc, DepartmentId

--6.
select a.Name,
       at.AnimalType,
       a.BirthDate
from Animals as a
         join AnimalTypes at on at.Id = a.AnimalTypeId
order by a.Name asc

--7.
select top (5) o.Name as Owner, count(a.Id) as CountOfAnimals
from Owners as o
         join Animals A on o.Id = A.OwnerId
group by o.Name
order by count(a.id) desc

--8.
select concat(o.Name, '-', a.Name) as ownersAnimals,
       o.PhoneNumber,
       ac.CageId
from Owners as o
         join Animals A on o.Id = A.OwnerId
         join AnimalTypes T on T.Id = A.AnimalTypeId
         join Cages C on T.Id = C.AnimalTypeId
         join AnimalsCages AC on A.Id = AC.AnimalId
where t.AnimalType = 'mammals'
group by OwnerId, o.Name, a.Name, o.PhoneNumber, ac.CageId
order by o.Name asc, a.Name desc

--9.
select v.Name,
       v.PhoneNumber,
       substring(v.Address, charindex(',', v.Address) + 1, 100) as Address
from Volunteers as v
         full outer join VolunteersDepartments VD on VD.Id = v.DepartmentId
where VD.DepartmentName = 'Education program assistant'
  and v.Address like '%Sofia%'
order by v.Name asc

--10.
select a.Name,
       year(a.BirthDate) as BirthYear,
       t.AnimalType
from Animals as a
         join AnimalTypes T on T.Id = a.AnimalTypeId
where t.AnimalType != 'Birds'
  and datediff(year, a.BirthDate, '01/01/2022') < 5
  and OwnerId is null
order by a.Name

--11.
create or alter function udf_GetVolunteersCountFromADepartment(@VolunteersDepartment varchar(30))
    returns int
as
begin
    declare @count int
    set @count = (select count(v.Id)
                  from Volunteers as v
                           join VolunteersDepartments VD on VD.Id = v.DepartmentId
                  where vd.DepartmentName = @VolunteersDepartment
                  group by vd.Id)
    if (@count is null)
        begin
            set @count = 0
        end
    return @count
end

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')

--12.
create procedure usp_AnimalsWithOwnersOrNot(@AnimalName varchar(30))
as
select
    a.Name as Name,
    isnull(o.Name,'For adoption') as OwnersName
from Animals as a
left join Owners O on O.Id = a.OwnerId
where a.Name=@AnimalName

EXEC usp_AnimalsWithOwnersOrNot 'Hippo'

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'