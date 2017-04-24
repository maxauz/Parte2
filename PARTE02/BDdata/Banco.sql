CREATE TABLE [dbo].[Banco]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [Nombre] VARCHAR(150) NULL, 
    [Direccion] VARCHAR(350) NULL, 
    [FechaRegistro] TIMESTAMP NOT NULL DEFAULT(GETDATE())
)
