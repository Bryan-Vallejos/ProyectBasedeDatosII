USE master
GO

CREATE DATABASE BibliotecaProyect_BDII
GO

Use BibliotecaProyect_BDII
go

CREATE SCHEMA Persona
go

CREATE SCHEMA Libro
go

CREATE SCHEMA Administrar
go


CREATE TABLE Persona.Tipo_Persona(
	IdTipoPersona  int primary key,
	Descripcion varchar(50),
	Estado bit default 1,
	Fecha_Creacion datetime default getdate()
)

CREATE TABLE Persona.Persona(
	IdPersona int primary key identity,
	PrimerNombre varchar(50) not null,
	SegundoNombre varchar(50),
	PrimerApellido varchar(50) not null,
	SegundoApellido varchar(50),
	Correo varchar(50) not null,
	Codigo varchar(50),
	IdTipoPersona int references Persona.Tipo_Persona(IdTipoPersona),
	IdUsuario int references Administrar.Registros(IdUsuario),
	Estado bit default 1,
	Fecha_Creacion datetime default getdate()
)

CREATE TABLE  Persona.Autor(
	IdAutor int primary key identity,
	NombreAutor varchar(50),
	Estado bit default 1,
	Fecha_Creacion datetime default getdate()
)

CREATE TABLE  Libro.Editorial(
	IdEditorial int primary key identity,
	NombreEditorial varchar(50),
	Estado bit default 1,
	Fecha_Creacion datetime default getdate()
)


CREATE TABLE  Libro.Categoria(
	IdCategoria int primary key identity,
	Descripcion varchar(50),
	Estado bit default 1,
	Fecha_Creacion datetime default getdate()
)

CREATE TABLE Libro.Libro(
	IdLibro int primary key identity,
	Titulo varchar(100),
	IdAutor int references Persona.Autor(IdAutor),
	IdCategoria int references Libro.Categoria(IdCategoria),
	IdEditorial int references Libro.Editorial(IdEditorial),
	Ubicacion varchar(50),
	Ejemplares int,
	Estado bit default 1,
	Fecha_Creacion datetime default getdate()
)

CREATE TABLE Administrar.EstadoPrestamos(
IdEstadoPrestamo int primary key,
Descripcion varchar(50),
Estado bit default 1,
)
GO

CREATE TABLE Administrar.Prestamo(
IdPrestamo int primary key identity,
IdEstadoPrestamo int references Administrar.EstadoPrestamos(IdEstadoPrestamo),
IdPersona int references Persona.Persona(IdPersona),
IdLibro int references Libro.Libro(IdLibro),
FechaDevolucion datetime,
FechaConfirmacionDevolucion datetime,
EstadoEntregado varchar(100),
EstadoRecibido varchar(100),
Estado bit default 1, 
)

CREATE TABLE Administrar.Registros(
IdUsuario int primary key,
Usuario varchar(50),
Contraseña varchar(50)
)
go

--Insertar datos a tablas de tipos

INSERT INTO Persona.Tipo_Persona(IdTipoPersona, Descripcion) values
(1,'Administrador'),
(2,'Empleado'),
(3,'Lector')

INSERT INTO Administrar.EstadoPrestamos(IdEstadoPrestamo,Descripcion) VALUES
(1,'Pendiente'),
(2,'Devuelto')

select * from Administrar.Registros