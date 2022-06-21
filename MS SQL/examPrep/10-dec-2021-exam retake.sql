use master
create database Airport
use Airport
--1
create table Passengers
(
    Id       int primary key identity,
    FullName varchar(100) unique not null,
    Email    varchar(50) unique  not null,
)

create table Pilots
(
    Id        int primary key identity,
    FirstName varchar(30) unique                    not null,
    LastName  varchar(30) unique                    not null,
    Age       Tinyint check (Age between 21 and 62) not null,
    Rating    float check (Rating between 0.0 and 10.0)
)

create table AircraftTypes
(
    Id       int primary key identity,
    TypeName varchar(30) not null unique
)

create table Aircraft
(
    Id           int primary key identity,
    Manufacturer varchar(25) not null,
    Model        varchar(30) not null,
    [Year]       int         not null,
    FlightHours  int,
    [Condition]  char(1)     not null,--????
    TypeId       int         not null references AircraftTypes (Id)
)

create table PilotsAircraft
(
    AircraftId int not null references Aircraft (Id),
    PilotId    int not null references Pilots (Id),
    primary key (AircraftId, PilotId)
)

create table Airports
(
    Id          int primary key identity,
    AirportName varchar(70) unique  not null,
    Country     varchar(100) unique not null,
)

create table FlightDestinations
(
    Id          int primary key identity,
    AirportId   int                       not null references Airports (Id),
    [Start]     datetime                  not null,
    AircraftId  int                       not null references Aircraft (Id),
    PassengerId int                       not null references Passengers (Id),
    TicketPrice decimal(18, 2) default 15 not null
)
--2
insert into Passengers(fullname, email)
values ( (select concat(FirstName, ' ', LastName) as fullName from Pilots where Pilots.Id = 5)
       , (select concat(FirstName, LastName, '@gmail.com') as fullName from Pilots where Pilots.Id = 5)),
       ( (select concat(FirstName, ' ', LastName) as fullName from Pilots where Pilots.Id = 6)
       , (select concat(FirstName, LastName, '@gmail.com') as fullName from Pilots where Pilots.Id = 6)),
       ( (select concat(FirstName, ' ', LastName) as fullName from Pilots where Pilots.Id = 7)
       , (select concat(FirstName, LastName, '@gmail.com') as fullName from Pilots where Pilots.Id = 7)),
       ( (select concat(FirstName, ' ', LastName) as fullName from Pilots where Pilots.Id = 8)
       , (select concat(FirstName, LastName, '@gmail.com') as fullName from Pilots where Pilots.Id = 8)),
       ( (select concat(FirstName, ' ', LastName) as fullName from Pilots where Pilots.Id = 9)
       , (select concat(FirstName, LastName, '@gmail.com') as fullName from Pilots where Pilots.Id = 9)),
       ( (select concat(FirstName, ' ', LastName) as fullName from Pilots where Pilots.Id = 10)
       , (select concat(FirstName, LastName, '@gmail.com') as fullName from Pilots where Pilots.Id = 10)),
       ( (select concat(FirstName, ' ', LastName) as fullName from Pilots where Pilots.Id = 11)
       , (select concat(FirstName, LastName, '@gmail.com') as fullName from Pilots where Pilots.Id = 11)),
       ( (select concat(FirstName, ' ', LastName) as fullName from Pilots where Pilots.Id = 12)
       , (select concat(FirstName, LastName, '@gmail.com') as fullName from Pilots where Pilots.Id = 12)),
       ( (select concat(FirstName, ' ', LastName) as fullName from Pilots where Pilots.Id = 13)
       , (select concat(FirstName, LastName, '@gmail.com') as fullName from Pilots where Pilots.Id = 13)),
       ( (select concat(FirstName, ' ', LastName) as fullName from Pilots where Pilots.Id = 14)
       , (select concat(FirstName, LastName, '@gmail.com') as fullName from Pilots where Pilots.Id = 14)),
       ( (select concat(FirstName, ' ', LastName) as fullName from Pilots where Pilots.Id = 15)
       , (select concat(FirstName, LastName, '@gmail.com') as fullName from Pilots where Pilots.Id = 15))

--3
select count(*)
from Aircraft
where Condition = 'A'

update Aircraft
set Condition = 'A'
where Condition in ('C', 'B')
  and FlightHours <= 100
  and Year >= 2013

update Aircraft
set Condition = 'A'
where Condition in ('C', 'B')
  and FlightHours is null
  and Year >= 2013

--4.
delete Passengers
where LEN(FullName) <= 10

--5.
select Manufacturer, Model, FlightHours, Condition
from Aircraft
order by FlightHours desc

--6.
select p.FirstName, p.LastName, a.Manufacturer, a.Model, a.FlightHours
from Pilots as p
         join PilotsAircraft PA on p.Id = PA.PilotId
         join Aircraft A on A.Id = PA.AircraftId
where a.FlightHours is not null
  and a.FlightHours <= 304
order by a.FlightHours desc, p.FirstName

--7.
select top (20) fd.Id,
                fd.Start,
                p.FullName,
                a.AirportName,
                fd.TicketPrice
from FlightDestinations as fd
         join Passengers P on P.Id = fd.PassengerId
         join Airports A on fd.AirportId = A.Id
where day(fd.Start) % 2 = 0
order by fd.TicketPrice desc, a.AirportName asc

--8.
select a.Id,
       a.Manufacturer,
       a.FlightHours,
       count(fd.Id)                  as FlightDestinationsCount,
       round(avg(fd.TicketPrice), 2) as AvgPrice
from Aircraft as A
         join FlightDestinations FD on A.Id = FD.AircraftId
group by A.Id, a.Manufacturer, a.FlightHours
having count(fd.Id) >= 2
order by count(fd.Id) desc, a.Id asc

--9.
select p.FullName,
       count(fd.Id)        as CountOfAircraft,
       sum(fd.TicketPrice) as TotalPayed
from Passengers as p
         join FlightDestinations FD on p.Id = FD.PassengerId
where substring(p.FullName, 2, 1) = 'a'
group by p.Id, p.FullName
having count(fd.Id) > 1
order by p.FullName

--10
select ap.AirportName,
       fd.Start as DayTime,
       fd.TicketPrice,
       p.FullName,
       a.Manufacturer,
       a.Model
from FlightDestinations as fd
         join Airports as ap on ap.Id = fd.AirportId
         join Aircraft A on A.Id = fd.AircraftId
         join Passengers P on P.Id = fd.PassengerId
where datepart(hour, fd.Start) between 6 and 20
  and fd.TicketPrice > 2500
order by a.Model asc

--11
create or alter function udf_FlightDestinationsByEmail(@email varchar(50))
    returns int
as
begin
    declare @count int
    set @count = (select count(FD.Id)
                  from Passengers as p
                           join FlightDestinations FD on p.Id = FD.PassengerId
                  where p.Email = @email
                  group by p.Id)
    if (@count is null)
        begin
            set @count = 0
        end
    return @count
end

--12
create or alter procedure usp_SearchByAirportName(@airportName varchar(70))
as
select a.AirportName,
       p.FullName,
       case
           when fd.TicketPrice <= 400 then 'Low'
           when fd.TicketPrice between 401 and 1500 then 'Medium'
           else 'High'
           end as LevelOfTicketPrice,
       a2.Manufacturer,
       a2.Condition,
       t.TypeName
from FlightDestinations as fd
         join Passengers P on P.Id = fd.PassengerId
         join Airports A on A.Id = fd.AirportId
         join Aircraft A2 on A2.Id = fd.AircraftId
         join AircraftTypes T on T.Id = A2.TypeId
where a.AirportName = @airportName
order by a2.Manufacturer ,p.FullName

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'



