create database PepitoSchool
go
use PepitoSchool
go

create table Estudiante(
 Id int Primary key identity(1,1),
 Nombres varchar(40) not null,
 Apellidos varchar(40) not null,
 Carnet varchar(12) not null,
 Phone varchar(16) not null,
 Direccion varchar(200) not null,
 Correo varchar(100) not null,
 Matematica int not null,
 Contabilidad int not null,
 Programacion int not null,
 Estadistica int not null
 )
go