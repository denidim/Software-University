use Minions
go
--2.Create Tables
create table Minions
(
    [Id]     int PRIMARY KEY not null,
    [Name]   nvarchar(50)    not null,
    [Age]    int,
    [TownId] int
)

create table Towns
(
    [Id]   int PRIMARY KEY not null,
    [Name] nvarchar(50)    not null,
)
--2.Create Tables

--3.Alter Minions Table
alter table Minions
    add TownId int
        constraint MinionsTownId
            foreign key (TownId)
                references Towns (Id)
--3.Alter Minions Table

--4.Insert Records in Both Tables
insert into Towns(Id, [Name])
values (1, 'Sofia'),
       (2, 'Plovdiv'),
       (3, 'Varna')

--sets identity to be inserted manual
--SET IDENTITY_INSERT Minions ON
--sets identity to auto increment
--SET IDENTITY_INSERT Minions OFF

insert into Minions(Id, [name], age, townid)
values (1, 'Kevin', 22, 1),
       (2, 'Bob', 15, 3),
       (3, 'Steward', Null, 2)
--4.Insert Records in Both Tables

use Minions

--5.Truncate Table Minions
truncate table Minions
--5.Truncate Table Minions

--6.Drop All Tables
drop table Minions
drop table Towns
--6.Drop All Tables

use Minions

--8.Create Table Users
create table Users
(
    [Id]             bigint identity (1,1) primary key not null,
    [Username]       varchar(30) unique                not null,
    [Password]       varchar(26)                       not null,
    [ProfilePicture] varbinary(max),
    check (datalength(ProfilePicture) <= 900000),
    [LastLoginTime]  datetime2,
    [IsDeleted]      bit                               not null
)

insert into Users(Username, [Password], Profilepicture, Lastlogintime, IsDeleted)
values ('user1', 'pass1', null, '1999-01-01 13:56:33. 345', 'true'),
       ('user2', 'pass1', null, '1999-01-01', '0'),
       ('user3', 'pass1', null, '1999-01-01', '0'),
       ('user4', 'pass1', null, '1999-01-01', '0'),
       ('user5', 'pass1', null, '1999-01-01', '0')
--8.Create Table Users

--7.Create Table People
create table People
(
    [Id]        int identity (1,1) primary key               not null,
    [Name]      nvarchar(200)                                not null,
    [Picture]   varbinary(2048),
    [Height]    decimal(10, 2),
    [Weight]    decimal(10, 2),
    [Gender]    char(1) check (Gender = 'm' or Gender = 'f') not null,
    [Birthdate] datetime2                                    not null,
    [Biography] nvarchar(max)
)

insert into People(name, picture, height, weight, gender, birthdate, biography)
values ('Pesho', null, 1.76, 65.5, 'm', '06.06.1995', 'bography1'),
       ('Gosho', null, null, null, 'm', '06.06.1995', 'bography1'),
       ('Pesho', null, 1.76, 65.5, 'm', '06.06.1995', 'bography1'),
       ('Pesho', null, 1.76, 65.5, 'm', '06.06.1995', 'bography1'),
       ('Pesho', null, 1.76, 65.5, 'm', '06.06.1995', 'bography1')
--7.Create Table People

select *
from INFORMATION_SCHEMA.TABLE_CONSTRAINTS

--9.Change Primary Key
alter table Users
    drop constraint PK__Users__3214EC07C8009004

alter table Users
    add constraint Users_pk primary key (Id, Username)
--9.Change Primary Key

--10.Add Check Constraint
alter table Users
    add constraint CHK_UserPassword
        check (len(Password) <= 5)
--10.Add Check Constraint

--11.Set Default Value of a Field
alter table Users
    add constraint df_LastLoginTime
        default getdate()
        for LastLoginTime
--11.Set Default Value of a Field

--12.Set Unique Field
alter table Users
    drop constraint Users_pk

alter table Users
    add constraint Users_pk
        primary key (Id)

alter table Users
    add constraint CHK_Username
        check (len(Username) <= 3)
--12.Set Unique Field

--13.Movies Database
use master

create database Movies

use Movies

create table Directors
(
    [Id]           int primary key identity (1,1) not null,
    [DirectorName] nvarchar(50)                   not null,
    [Notes]        nvarchar(max)
)

insert into Directors (directorname, notes)
values ('Director1', null),
       ('Director1', null),
       ('Director1', null),
       ('Director1', null),
       ('Director1', null)

create table Genres
(
    [Id]        int primary key identity (1,1) not null,
    [GenreName] nvarchar(50)                   not null,
    [Notes]     nvarchar(max)
)

insert into Genres (GenreName, notes)
values ('Ganre', null),
       ('Ganre', null),
       ('Ganre', null),
       ('Ganre', null),
       ('Ganre', null)

create table Categories
(
    [Id]           int primary key identity (1,1) not null,
    [CategoryName] nvarchar(50)                   not null,
    [Notes]        nvarchar(max)
)

insert into Categories (categoryname, notes)
values ('Category', null),
       ('Category', null),
       ('Category', null),
       ('Category', null),
       ('Category', null)

create table Movies
(
    [Id]            int primary key identity not null,
    [Title]         nvarchar(50)             not null,
    [DirectorId]    int                      not null
        constraint MoviesDirectorId
            foreign key references Directors (Id),
    [CopyrightYear] datetime2                not null,
    [Length]        datetime2                not null,
    [GenreId]       int                      not null
        constraint MoviesGenrId
            foreign key references Genres (Id),
    [CategoryId]    int                      not null
        constraint MoviesCategoryId
            foreign key references Categories (Id),
    [Rating]        int,
    [Notes]         nvarchar(max)
)

insert into Movies (Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
values ('Title', 1, '1999-01-01', '13:56:33. 345', 1, 1, null, null),
       ('Title', 1, '1999-01-01', '13:56:33. 345', 1, 1, null, null),
       ('Title', 1, '1999-01-01', '13:56:33. 345', 1, 1, null, null),
       ('Title', 1, '1999-01-01', '13:56:33. 345', 1, 1, null, null),
       ('Title', 1, '1999-01-01', '13:56:33. 345', 1, 1, null, null)
--13.Movies Database

--14.Car Rental Database
use master

create database CarRental

use CarRental

create table Categories
(
    ID           int primary key identity (1,1) not null,
    CategoryName varchar(50)                    not null,
    DailyRate    decimal(10, 2)                 not null,
    WeeklyRate   decimal(10, 2)                 not null,
    MonthlyRate  decimal(10, 2)                 not null,
    WeekendRate  decimal(10, 2)                 not null
)
insert into Categories(categoryname, dailyrate, weeklyrate, monthlyrate, weekendrate)
values ('SomeName', 500.50, 500.50, 500.50, 500.50),
       ('SomeName', 500.50, 500.50, 500.50, 500.50),
       ('SomeName', 500.50, 500.50, 500.50, 500.50)

create table Cars
(
    Id           int primary key identity (1,1) not null,
    PlateNumber  nvarchar(10) unique,
    Manufacturer nvarchar(50)                   not null,
    Model        nvarchar(50)                   not null,
    CarYear      datetime2                      not null,
    CategoryId   int
        constraint CarsCategoryId
            foreign key references Categories (ID),
    Doors        int                            not null,
    Picture      varbinary(max),
    [Condition]  nvarchar(50),
    Available    char                           not null
)
insert into Cars(platenumber, manufacturer, model, caryear,
                 categoryid, doors, picture, [condition], available)
values ('CT1234BP', 'BMW', 'X5', '2022 - 01 - 01', 1, 5, null, 'Very good!', 1),
       ('CT1235BP', 'BMW', 'X5', '2022 - 01 - 01', 1, 5, null, 'Very good!', 1),
       ('CT1236BP', 'BMW', 'X5', '2022 - 01 - 01', 1, 5, null, 'Very good!', 1)

create table Employees
(
    Id        int primary key identity (1,1) not null,
    FirstName nvarchar(50)                   not null,
    LastName  nvarchar(50)                   not null,
    Title     nvarchar(50)                   not null,
    Notes     nvarchar(max)
)
insert into Employees (FirstName, LastName, Title, Notes)
values ('Gosho', 'Goshkov', 'Gospodin', null),
       ('Gosho', 'Goshkov', 'Gospodin', null),
       ('Gosho', 'Goshkov', 'Gospodin', null)

create table Customers
(
    Id                  int primary key identity (1,1) not null,
    DriverLicenceNumber nvarchar(20) unique            not null,
    FullName            nvarchar(50)                   not null,
    [Address]           nvarchar(50)                   not null,
    City                nvarchar(50)                   not null,
    ZIPCode             nvarchar(10)                   not null,
    Notes               nvarchar(max)
)

insert into Customers(driverlicencenumber, fullname, [address], city, zipcode, notes)
values ('drn1', 'Pencho Penchev', 'Sesame streat 11', 'Kaspichan', '6000', null),
       ('drn2', 'Pencho Penchev', 'Sesame streat 11', 'Kaspichan', '6000', null),
       ('drn3', 'Pencho Penchev', 'Sesame streat 11', 'Kaspichan', '6000', null)

create table RentalOrders
(
    Id               int primary key identity (1,1) not null,
    EmployeeId       int
        constraint RentalOrdersEmployeeId
            foreign key references Employees (Id),
    CustomerId       int
        constraint RentalOrdersCustumerId
            foreign key references Customers (Id),
    CarId            int
        constraint RentalOrdersCarsId
            foreign key references Cars (Id),
    TankLevel        decimal(10, 2)                 not null,
    KilometrageStart decimal(10, 2)                 not null,
    KilometrageEnd   decimal(10, 2)                 not null,
    TotalKilometrage decimal(10, 2),
    StartDate        datetime2                      not null,
    EndDate          datetime2                      not null,
    TotalDays        int                            not null,
    RateApplied      decimal(10, 2)                 not null,
    TaxRate          decimal(10, 2)                 not null,
    OrderStatus      nvarchar(50),
    Notes            nvarchar(max)
)
insert into RentalOrders(employeeid, customerid, carid, tanklevel, kilometragestart,
                         kilometrageend, totalkilometrage, startdate, enddate,
                         totaldays, rateapplied, taxrate, orderstatus, notes)
values (1, 3, 1, 15.5, 10000, 10500, 500, '2022-01-01', '2022-01-02', 30, 100, 10, 'rented', null),
       (2, 3, 2, 15.5, 10000, 10500, 500, '2022-01-01', '2022-01-02', 30, 100, 10, 'rented', null),
       (3, 3, 3, 15.5, 10000, 10500, 500, '2022-01-01', '2022-01-02', 30, 100, 10, 'rented', null)
--14.Car Rental Database

--15.Hotel Database
create database Hotel

use Hotel

create table Employees
(
    Id        int primary key identity (1,1) not null,
    FirstName nvarchar(50)                   not null,
    LastName  nvarchar(50)                   not null,
    Title     nvarchar(50)                   not null,
    Notes     nvarchar(max)
)
insert into Employees(firstname, lastname, title, notes)
values ('SomeName', 'SomeLAstName', 'SomeMister', null),
       ('SomeName', 'SomeLAstName', 'SomeMister', null),
       ('SomeName', 'SomeLAstName', 'SomeMister', null)

create table Customers
(
    AccountNumber   int primary key not null,
    FirstName       nvarchar(50)    not null,
    LastName        nvarchar(50)    not null,
    PhoneNumber     int unique      not null,
    EmergencyName   nvarchar(50),
    EmergencyNumber int,
    Notes           nvarchar(max)
)
insert into Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
values (001, 'SomeFistName', 'SomeLastName', 089, null, null, null),
       (002, 'SomeFistName', 'SomeLastName', 0810, null, null, null),
       (003, 'SomeFistName', 'SomeLastName', 0811, null, null, null)

create table RoomStatus
(
    RoomStatus nvarchar(50) primary key,
    Notes      nvarchar(max)
)
insert into RoomStatus(roomstatus, notes)
values ('Empty', null),
       ('Full', null),
       ('Dirty', null)

create table RoomTypes
(
    RoomType nvarchar(20) primary key,
    Notes    nvarchar(max)
)
insert into RoomTypes(roomtype, notes)
values ('single1', null),
       ('double1', null),
       ('kingsize1', null)

create table BedTypes
(
    BedType nvarchar(50) primary key,
    Notes   nvarchar(max)
)
insert into BedTypes(bedtype, notes)
values ('single1', null),
       ('single2', null),
       ('single3', null)

create table Rooms
(
    RoomNumber int primary key,
    RoomType   nvarchar(20)
        constraint RoomType_Pk foreign key references RoomTypes (roomtype),
    BedType    nvarchar(50)
        constraint RoomsBetType_Pk foreign key references BedTypes (bedtype),
    Rate       decimal(10, 2) not null,
    RoomStatus nvarchar(50)
        constraint RoomsStatus_Pk foreign key references RoomStatus (RoomStatus),
    Notes      nvarchar(max)
)
insert into Rooms(roomnumber, roomtype, bedtype, rate, roomstatus, notes)
values (1, 'single1', 'single1', 150.00, 'Empty', null),
       (2, 'single1', 'single1', 150.00, 'Empty', null),
       (3, 'single1', 'single1', 150.00, 'Empty', null)

create table Payments
(
    Id                int primary key identity (1,1),
    EmployeeId        int
        constraint PaymentEmplayeeId_FK foreign key references Employees (Id),
    PaymentDate       datetime2      not null,
    AccountNumber     int
        constraint PaymentAccNumber_FK foreign key references Customers (AccountNumber),
    FirstDateOccupied datetime2      not null,
    LastDateOccupied  datetime2      not null,
    TotalDays         int            not null,
    AmountCharged     decimal(10, 2) not null,
    TaxRate           decimal(10, 2) not null,
    TaxAmount         decimal(10, 2) not null,
    PaymentTotal      decimal(10, 2) not null,
    Notes             nvarchar(max)
)
insert into Payments(employeeid, paymentdate, accountnumber, firstdateoccupied,
                     lastdateoccupied, totaldays, amountcharged, taxrate,
                     taxamount, paymenttotal, notes)
values (1, '2022-01-01', 1, '2022-01-01', '2022-02-01', 30, 1000, 10, 100, 1100, null),
       (1, '2022-01-01', 1, '2022-01-01', '2022-02-01', 30, 1000, 10, 100, 1100, null),
       (1, '2022-01-01', 1, '2022-01-01', '2022-02-01', 30, 1000, 10, 100, 1100, null)

create table Occupancies
(
    Id            int primary key identity (1,1),
    EmployeeId    int
        constraint OccupanciesEmplayeeId_FK foreign key references Employees (Id),
    DateOccupied  datetime2,
    AccountNumber int
        constraint OccupanciesAccNumber_FK foreign key references Customers (AccountNumber),
    RoomNumber    int
        constraint OccupanciesRoomNumer_FK foreign key references Rooms (RoomNumber),
    RateApplied   decimal(10, 2) not null,
    PhoneCharge   decimal(10, 2),
    Notes         nvarchar(max)
)
insert into Occupancies(employeeid, dateoccupied, accountnumber,
                        roomnumber, rateapplied, phonecharge, notes)
values (1, '2022-01-01', 1, 1, 10, null, null),
       (1, '2022-01-01', 1, 1, 10, null, null),
       (1, '2022-01-01', 1, 1, 10, null, null)

--16.Create SoftUni Database

create database SoftUni

use SoftUni

create table Towns
(
    Id     int primary key identity (1,1),
    [Name] nvarchar(50) not null
)

create table Addresses
(
    Id          int primary key identity (1,1),
    AddressText nvarchar(50) not null,
    TownId      int foreign key references Towns (Id),
)

create table Departments
(
    Id     int primary key identity (1,1),
    [Name] nvarchar(50) not null
)

create table Employees
(
    Id           int primary key identity (1,1),
    FirstName    nvarchar(50)   not null,
    MiddleName   nvarchar(50),
    LastName     nvarchar(50),
    JobTitle     nvarchar(50),
    DepartmentId int foreign key references Departments (Id),
    HireDate     datetime2      not null,
    Salary       decimal(10, 2) not null,
    AddressId    int foreign key references Addresses (Id)
)
--16.Create SoftUni Database

--17.Backup Database
--done
--17.Backup Database

--18.Basic Insert
--Towns: Sofia, Plovdiv, Varna, Burgas
insert into Towns(Name)
values ('Sofia'),
       ('Plovdiv'),
       ('varna'),
       ('Burgas')

update Towns
set Name = 'Varna'
where Id = 3

--Departments: Engineering, Sales, Marketing, Software Development, Quality Assurance
insert into Departments(Name)
values ('Engineering'),
       ('Sales'),
       ('Marketing'),
       ('Software Development'),
       ('Quality Assurance')

--Name	Job Title	Department	Hire Date	Salary
--Ivan Ivanov Ivanov	.NET Developer	Software Development	01/02/2013	3500.00
--Petar Petrov Petrov	Senior Engineer	Engineering	02/03/2004	4000.00
--Maria Petrova Ivanova	Intern	Quality Assurance	28/08/2016	525.25
--Georgi Teziev Ivanov	CEO	Sales	09/12/2007	3000.00
--Peter Pan Pan	Intern	Marketing	28/08/2016	599.88
insert into Employees(firstname, jobtitle,
                      departmentid, hiredate,
                      salary)
values ('Ivan Ivanov Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
       ('Petar Petrov Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
       ('Maria Petrova Ivanova', 'Intern', 5, '2016-08-28', 525.25),
       ('Georgi Teziev Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
       ('Peter Pan Pan', 'Intern', 3, '2016-08-28', 599.88)
--18.Basic Insert

--19.Basic Select All Fields
--use SoftUni
select *
from Departments
select *
from Towns
select *
from Employees
--19.Basic Select All Fields

--20.Basic Select All Fields and Order Them
use SoftUni
select *
from Towns
order by Name
select *
from Departments
order by Name
select *
from Employees
order by Salary desc

--20.Basic Select All Fields and Order Them

--21.Basic Select Some Fields
select Name
from Towns
order by Name
select Name
from Departments
order by Name
select FirstName, LastName, JobTitle, Salary
from Employees
order by Salary desc
--21.Basic Select Some Fields

--22.Increase Employees Salary
update Employees
set Salary += Salary * 0.10
select Salary
from Employees
--22.Increase Employees Salary

--23.Decrease Tax Rate
--query for finding the table name
use Hotel
Select * from  INFORMATION_SCHEMA.COLUMNS
where COLUMN_NAME LIKE 'TaxRate'
-- table name => Payments
update Payments set TaxRate -=  TaxRate*0.03
select TaxRate from Payments
--23.Decrease Tax Rate

--24.Delete All Records
--Use Hotel database and delete all records from the
-- Occupancies table. Use SQL query.
truncate table Occupancies
--24.Delete All Records
