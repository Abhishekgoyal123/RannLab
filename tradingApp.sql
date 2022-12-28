create database tradingApp

use tradingApp

create table Registeruser(
userId int primary key Identity,
userName varchar(20),
Email varchar(20),
UserPassword varchar(50),
photo varchar(100),
emailVerified bit

);