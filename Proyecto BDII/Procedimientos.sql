use BibliotecaProyect_BDII
go

CREATE PROCEDURE dbo.usp_Registrar 
@IdPersona int,
@Usuario varchar(50),
@Contraseña varchar(50)
as BEGIN
INSERT INTO Registros VALUES(@IdPersona, @Usuario , @Contraseña)
end
go

CREATE PROCEDURE dbo.usp_Login
@Usuario varchar(50),
@Contraseña varchar(50)
as BEGIN
SELECT * FROM Registros WHERE Usuario = @Usuario and Contraseña = @Contraseña
end