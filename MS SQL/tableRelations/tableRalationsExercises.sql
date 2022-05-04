Create database TableRelationsDemo
use TableRelationsDemo

--1.One-To-One Relationship
create table Passports
(
    PasspotID      int primary key identity (100,1) not null,
    PassportNumber nvarchar(50)                     not null
)
insert into Passports(PassportNumber)
values ('N34FG21B'),
       ('K65LO4R7'),
       ('ZE657QP2')

create table Persons
(
    PersonID   int primary key identity not null,
    FirstName  nvarchar(50),
    Salary     decimal(10, 2),
    PassportID int foreign key references Passports (PasspotID)
)
--1.One-To-One Relationship

--2.One-To-Many Relationship
create table Manufacturers
(
    ManufacturerID int primary key identity,
    [Name]         nvarchar(50),
    EstablishedOn  datetime2
)
insert into Manufacturers(name, establishedon)
values ('BMW', '07/03/1916'),
       ('Tesla', '01/01/2003'),
       ('Lada', '01/05/1966')

create table Models
(
    ModelID        int primary key identity (100,1),
    [Name]         nvarchar(50),
    ManufacturerID int foreign key references Manufacturers (ManufacturerID)
)

insert into Models(name, manufacturerid)
values ('X1', 1),
       ('i6', 1),
       ('Model S', 2),
       ('Model X', 2),
       ('Model 3', 2),
       ('Nova', 3)
--2.One-To-Many Relationship

--3.Many-To-Many Relationship
create table Students
(
    StudentID int primary key identity,
    [Name]    nvarchar(50),
)
create table Exams
(
    ExamID int primary key identity,
    [Name] nvarchar(50),
)
create table StudentsExams
(
    StudentID int,
    ExamID    int,
    constraint PK_StudentsExams primary key (StudentID, ExamID),
    constraint FK_StudentsExams_Students foreign key (StudentID)
        references Students (StudentID),
    constraint FK_StudentsExams_Exams foreign key (ExamID)
        references Exams (ExamID)
)
insert into Students(Name)
values ('Mila'),
       ('Toni'),
       ('Ron')

insert into Exams(Name)
values ('SpringMVC'),
       ('Neo4j'),
       ('Oracle 11g')
--3.Many-To-Many Relationship

--4.Self-Referencing
create table Teachers(
    TeacherID int primary key identity (101,1),
    [Name] nvarchar(50),
    ManagerID int foreign key references Teachers(TeacherID)
)
insert into Teachers([name], managerid)
values ('John',null),
       ('Maya',106),
       ('Silvia',106),
       ('Ted',105),
       ('Mark',101),
       ('Greta',101)
--4.Self-Referencing


--5.Online Store Database
create database OnlineStoreDatabase
use OnlineStoreDatabase
create table Cities(
    CityID int primary key ,
    Name varchar(50)
)
create table Customers(
    CustomerID int primary key ,
    Name varchar(20),
    Birthday date,
    CityID int foreign key references Cities(cityid)
)

create table Orders(
    OrderID int primary key ,
    CustomerID int foreign key references Customers(CustomerID)
)

create table ItemTypes(
    ItemTypeID int primary key ,
    Name varchar(20)
)

create table Items(
    ItemID int primary key ,
    Name varchar(20),
    ItemTypeID int foreign key references ItemTypes(ItemTypeID)
)

create table OrderItems(
    OrderID int,
    ItemID int,
    constraint PK_OrderItems primary key (OrderID, ItemID),
    constraint FK_OrderItems_Orders foreign key (OrderID)
        references Orders (OrderID),
    constraint FK_OrderItems_Items foreign key (ItemID)
        references Items (ItemID)
)
--5.Online Store Database

--6.University Database
create database UniversityDatabase
use UniversityDatabase

create table Majors(
    MajorID int primary key ,
    Name varchar (20)
)

create table Subjects(
    SubjectID int primary key ,
    SubjectName varchar(20)
)

create table Students(
    StudentID int primary key ,
    StudentNumber int,
    StudentName varchar(20),
    MajorID int foreign key references Majors(MajorID)
)

create table Agenda(
    StudentID int,
    SubjectID int,
    constraint PK_Agenda primary key (StudentID,SubjectID),
    constraint FK_Agenda_Students foreign key (StudentID)
        references Students (StudentID),
    constraint FK_Agenda_Subjects foreign key (SubjectID)
        references Subjects (SubjectID)
)

create table Payments(
    PaymentID int primary key ,
    PaymentDate date,
    PaymentAmount decimal(10,2),
    StudentID int foreign key references Students(StudentID)
)
--6.University Database

--7.SoftUni Design
--7.SoftUni Design

--8.Geography Design
--8.Geography Design

--9.Peaks in Rila
use Geography
select m.MountainRange, p.PeakName, p.Elevation
from Mountains as m
         join Peaks as p on p.MountainId = m.Id
where m.MountainRange = 'Rila'
order by p.Elevation desc
--9.Peaks in Rila

