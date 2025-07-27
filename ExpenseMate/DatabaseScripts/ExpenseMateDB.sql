-- create database
create database expensimatedb;
go

-- use database
use expensimatedb;
go

-- create expense table
create table expense (
    id int primary key identity(1,1),
    expensedate date not null,
    categoryname nvarchar(100) not null,
    description nvarchar(255),
    amount decimal(10,2) not null
);
go

-- create income table
create table income (
    id int primary key identity(1,1),
    incomedate date not null,
    source nvarchar(100) not null,
    description nvarchar(255),
    amount decimal(10,2) not null
);
go

-- insert original personal expense data (example entries — replace with your real ones if needed)
insert into expense (expensedate, categoryname, description, amount)
values 
('2025-07-01', 'food', 'lunch at home', 80.00),
('2025-07-02', 'travel', 'bus pass recharge', 250.00),
('2025-07-03', 'groceries', 'monthly grocery', 1800.00),
('2025-07-04', 'health', 'medicines', 220.00),
('2025-07-05', 'entertainment', 'youtube premium', 139.00);
go

-- insert original personal income data
insert into income (incomedate, source, description, amount)
values 
('2025-07-01', 'salary', 'monthly salary', 16000.00),
('2025-07-10', 'freelancing', 'client project', 4500.00);
go
