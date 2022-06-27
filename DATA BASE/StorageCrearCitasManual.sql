CREATE PROC dbo.CreaCitasManual
	@MEDICO  AS INT  = NULL,
	@FECHA   AS DATE = NULL,
	@ID      AS INT  = NULL,
	@CLIENTE AS INT  = NULL,	
	@NOMBRE AS NVARCHAR(150) = NULL,
	@CORREO AS NVARCHAR(150) = NULL
	AS 
	SET NOCOUNT ON;
	BEGIN TRY
	BEGIN TRANSACTION

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 

	DECLARE @IdParte AS UNIQUEIDENTIFIER
	DECLARE @IDCALENDARIO AS INT

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

		SET @CLIENTE = (SELECT IdRollElemento FROM RollElemento WHERE IdParte = @IdParte)

		SET @IDCALENDARIO = (SELECT TEMP.IdCalendario FROM CalendarioCita TEMP WHERE TEMP.FechaCita = @FECHA AND TEMP.IdRollMedico = @MEDICO AND IdHoraCita = @ID)

		IF @IDCALENDARIO IS NULL
		BEGIN
			INSERT INTO dbo.CalendarioCita
			(IdRollCliente,IdRollMedico,IdHoraCita,FechaCita)
			VALUES
			(@CLIENTE,@MEDICO,@ID,@FECHA)
		END

	END

	EXEC dbo.CalendarioCitas @MEDICO,@FECHA


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
