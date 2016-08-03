USE [master]
GO

--Create Database--
CREATE DATABASE [PeopleSearch]

go
--End of Create Database--

--Create Tables--
use [PeopleSearch]

create table Person
(
	Id bigint not null constraint PK_Person primary key identity,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	Birthday datetime not null,
	AvatarUrl varchar(500) null 
)
go
create table [Address]
(
	Id bigint not null constraint FK_Address_Person foreign key references Person(Id),
    [Address] varchar(5000) not null,
)

create table Interest
(
	Id bigint not null constraint FK_Interest_Person foreign key references Person(Id),
	Interest varchar(5000) not null
)

--End of Create Tables--

-- Create Test Data--
insert into Person (FirstName, LastName, Birthday, AvatarUrl)
values ('James', 'Bond', '07/01/1901', '/Content/Avatar/avatar1.jpg'),
       ('Hello', 'Kitty', '11/12/1981', '/Content/Avatar/avatar2.jpg'),
       ('Koby', 'Bryan', '03/25/1984', '/Content/Avatar/avatar3.jpg'),
       ('Will', 'Smith', '05/28/1990', '/Content/Avatar/avatar4.jpg'),
	   ('James', 'Cooper', '12/01/1971', '/Content/Avatar/avatar5.jpg');

insert into [Address] ([Address], Id)
values ('123, Main Street, SLC, UT 84101', (select Id from Person where Id = 1)),
	   ('888, State Street, SLC, UT 84101', (select Id from Person where Id = 1)),
       ('456, Main Street, SLC, UT 84101', (select Id from Person where Id = 2)),
       ('789, Main Street, SLC, UT 84101', (select Id from Person where Id = 3)),
       ('12345677, Main Street, SLC, UT 84101', (select Id from Person where Id = 4)),
	   ('test, Broadway, Draper, UT 84111', (select Id from Person where Id = 5))

insert into Interest(Interest, Id)
values ('Description 1', (select Id from Person where Id = 1)),
       ('Description 2', (select Id from Person where Id = 2)),
       ('Description 3', (select Id from Person where Id = 3)),
       ('Description 4', (select Id from Person where Id = 4)),
	   ('Description 5', (select Id from Person where Id = 1)),
       ('Description 6', (select Id from Person where Id = 2)),
       ('Description 7', (select Id from Person where Id = 3)),
       ('Description 8', (select Id from Person where Id = 1)),
	   ('Description 9', (select Id from Person where Id = 5));
--End of Test Data--
