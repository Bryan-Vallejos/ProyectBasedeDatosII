use BibliotecaProyect_BDII
go

CREATE PROCEDURE dbo.usp_Registrar 
@IdPersona int,
@Usuario varchar(50),
@Contraseņa varchar(50)
as BEGIN
INSERT INTO Registros VALUES(@IdPersona, @Usuario , @Contraseņa)
end
go

CREATE PROCEDURE dbo.usp_Login
@Usuario varchar(50),
@Contraseņa varchar(50)
as BEGIN
SELECT * FROM Registros WHERE Usuario = @Usuario and Contraseņa = @Contraseņa
end