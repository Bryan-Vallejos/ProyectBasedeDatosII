use BibliotecaProyect_BDII
go

CREATE PROCEDURE dbo.usp_Registrar 
@IdPersona int,
@Usuario varchar(50),
@Contrase�a varchar(50)
as BEGIN
INSERT INTO Registros VALUES(@IdPersona, @Usuario , @Contrase�a)
end
go

CREATE PROCEDURE dbo.usp_Login
@Usuario varchar(50),
@Contrase�a varchar(50)
as BEGIN
SELECT * FROM Registros WHERE Usuario = @Usuario and Contrase�a = @Contrase�a
end