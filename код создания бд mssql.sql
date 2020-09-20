CREATE DATABASE STAFF

USE STAFF;
CREATE TABLE Pasport
(
	Id					integer PRIMARY KEY IDENTITY ( 1,1 ),
	Type				varchar(20) NOT NULL, 
	Number				varchar(10) NOT NULL UNIQUE
)

CREATE TABLE Staff
( 
	Id					integer PRIMARY KEY IDENTITY ( 1,1 ),
	Name				varchar(20)  NOT NULL ,
	Surname				varchar(20)  NOT NULL ,
	Phone				varchar(15),
	CompanyId			integer  NOT NULL,
	PasportId			integer  NOT NULL FOREIGN KEY REFERENCES Pasport(Id),
)
