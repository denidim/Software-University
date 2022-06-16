--Part I - Queries for Bank Database
use Bank
--1.Create Table Logs
create table Logs
(
    [LogId]     int PRIMARY KEY identity,
    [AccountId] int references Accounts (id),
    [OldSum]    decimal(15, 2),
    [NewSum]    decimal(15, 2)
)

CREATE TRIGGER tr_AddToLogsOnAccountUpdate
    ON Accounts
    FOR UPDATE
    AS
    INSERT INTO Logs(AccountId, OldSum, NewSum)
    SELECT i.Id, d.Balance, i.Balance
    FROM inserted AS i
             JOIN deleted AS d ON i.Id = d.Id
    WHERE i.Balance != d.Balance
GO

--1.Create Table Logs

--2.Create Table Emails
create table NotificationEmails
(
    [Id]        int PRIMARY KEY identity,
    [Recipient] int references Accounts (id),
    [Subject]   nvarchar(max),
    [Body]      nvarchar(max)
)

create trigger tr_AddLogsAndEmailsAfterInsert
    on Logs
    for insert
    as
begin
    insert into NotificationEmails(recipient, [subject], body)
    select i.AccountId,
           concat('Balance change for account: ', i.AccountId),
           concat('On date', getdate(), 'your balance was changed from ', i.OldSum, 'to', i.NewSum)
    from inserted as i
end
--2.Create Table Emails
go
--3.Deposit Money
create or alter procedure usp_DepositMoney(@AccountId int, @MoneyAmount decimal(15, 4))
as
    --begin transaction
declare
    @acc int = (select id
                from Accounts
                where id = @AccountId)
    if (@MoneyAmount <= 0 or @MoneyAmount is null or @acc is null)
        --begin
        --  rollback
        return
    --end
update Accounts
set Balance += @MoneyAmount
where Id = @AccountId
--commit
go
exec usp_DepositMoney 1, 10
go
select *
from Accounts
where id = 1
--3.Deposit Money
go
--4.Withdraw Money
create or alter procedure usp_WithdrawMoney(@AccountId int, @MoneyAmount decimal(15, 4))
as
declare
    @acc int = (select id
                from Accounts
                where id = @AccountId)
declare
    @currBalance decimal = (select Balance
                            from Accounts
                            where id = @AccountId)
    if (@MoneyAmount <= 0 or @MoneyAmount is null or @acc is null or (@currBalance - @MoneyAmount < 0))
        return
update Accounts
set Balance -= @MoneyAmount
where Id = @AccountId
--4.Withdraw Money
go
--5.Money Transfer
-- create procedure usp_TransferMoney(@SenderId int, @ReceiverId int, @Amount decimal(15, 4))
-- as
-- begin
--     if (exists(select * from Accounts where id  =@SenderId) and exists(select * from Accounts where id  =@ReceiverId))
--         begin
--             exec dbo.usp_WithdrawMoney @SenderId, @Amount
--             exec dbo.usp_DepositMoney @ReceiverId, @Amount
--         end
--     else
--         raiserror ('Error!',16,3)
-- end

create procedure usp_TransferMoney(@SenderId int, @ReceiverId int , @Amount decimal(15,4))
as
    begin transaction
    exec dbo.usp_WithdrawMoney  @SenderId,@Amount
    exec dbo.usp_DepositMoney  @ReceiverId,@Amount
commit
--5.Money Transfer

--Part II - Queries for Diablo Database

--6.Trigger
--6.Trigger

--7.*Massive Shopping
--7.*Massive Shopping

--Part III - Queries for SoftUni Database

--8.Employees with Three Projects
create or alter proc usp_AssignProject(@EmployeeID int, @ProjectID int)
as
begin transaction
    declare @employee int = (select EmployeeID from Employees where EmployeeID = @EmployeeID)
    declare @project int = (select @ProjectID from Projects where ProjectID = @ProjectID)
    if (@employee is null or @project is null)
        begin
            rollback
            return
        end
        declare @employeeProjectNumber int
        set @employeeProjectNumber = (select count(*) from EmployeesProjects where EmployeeID = @EmployeeID)
        if (@employeeProjectNumber >= 3)
            begin
                rollback
                raiserror ('The employee has too many projects!',16,1)
            end
        insert into EmployeesProjects Values (@employee, @project)
commit
--8.Employees with Three Projects

--9.Delete Employees
create table Deleted_Employees(
    EmployeeId int primary key ,
    FirstName nvarchar(50),
    LastName nvarchar(50),
    MiddleName nvarchar(50),
    JobTitle nvarchar(50),
    DepartmentId int ,
    Salary decimal(15,2))

go

create or alter trigger tr_DeletedEmployees on Employees for delete
    as
    insert into Deleted_Employees
    select FirstName,LastName,MiddleName,JobTitle,DepartmentID,Salary from deleted
--9.Delete Employees
