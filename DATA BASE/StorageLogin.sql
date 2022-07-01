--DROP PROCEDURE dbo.InsertLogin

alter PROC dbo.InsertLogin

	@CORREO AS NVARCHAR(150) = NULL,
	@NOMBRE AS NVARCHAR(150) = NULL
	AS 
	SET NOCOUNT ON;
	BEGIN TRY
	BEGIN TRANSACTION

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 

	DECLARE @IdParte AS UNIQUEIDENTIFIER

	SET @IdParte = (SELECT IdParte FROM Persona WHERE DireccionElectronica = @CORREO)

	IF @IdParte IS NULL
	BEGIN

		SET @IdParte = NEWID()
		INSERT INTO dbo.Parte(IdParte)VALUES(@IdParte)
		INSERT INTO dbo.Persona
		(IdParte,Nombre,DireccionElectronica)
		VALUES
		(@IdParte,@NOMBRE,@CORREO)

		INSERT INTO RollElemento				
		(IdParte,IdTipoRollElemento,FechaInicial)
		SELECT temp.IdParte,tre.IdTipoRollElemento,GETDATE() FROM dbo.Persona TEMP
		INNER JOIN dbo.TipoRollElemento tre ON tre.Descripcion = 'Cliente'
		where temp.IdParte = @IdParte

	END

	INSERT INTO LoginUsuario				
	(IdParte,FechaSesion)
	SELECT temp.IdParte,GETDATE() FROM dbo.Persona TEMP
	WHERE TEMP.IdParte = @IdParte

	SELECT TOP 1 RR.IdRollElemento FROM LoginUsuario temp
	INNER JOIN RollElemento RR ON RR.IdParte = temp.IdParte
	WHERE temp.IdParte = @IdParte ORDER BY TEMP.FechaSesion DESC

	SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

	COMMIT TRANSACTION
	--ROLLBACK TRANSACTION
	END TRY
	BEGIN CATCH
	    PRINT 'Error '      + CONVERT(varchar(50), ERROR_NUMBER())   +
	          ', Severity ' + CONVERT(varchar(5),  ERROR_SEVERITY()) +
	          ', State '    + CONVERT(varchar(5),  ERROR_STATE())    +
	          ', Line '     + CONVERT(varchar(5),  ERROR_LINE())     PRINT ERROR_MESSAGE();        
	      IF XACT_STATE() <> 0 BEGIN
	        ROLLBACK TRANSACTION
	      END
	END CATCH
	SET NOCOUNT OFF;
GO

