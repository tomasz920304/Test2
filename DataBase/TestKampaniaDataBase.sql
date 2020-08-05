--create database TestKampaniaDataBase;

create table Kampania(
Id int primary key identity(1,1) not null,
Nazwa varchar(50),
Koszt int
);

insert into Kampania values
('Nazwa1', 1),
('Nazwa2', 2),
('Nazwa3', 3),

('Nazwa4', 4),
('Nazwa5', 5),
('Nazwa6', 6);