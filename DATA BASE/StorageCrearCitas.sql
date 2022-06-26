--EXEC dbo.InsertLogin 'fox_290888@hotmail.com','Alexx Beltran Lga'

--EXEC dbo.InsertLogin fox_290888@hotmail.com,Alexx Beltran Lga

--DROP PROCEDURE dbo.CrearCitas

CREATE PROC dbo.CrearCitas

	@MEDICO  AS INT  = NULL,
	@FECHA   AS DATE = NULL,
	@ID      AS INT  = NULL,
	@CLIENTE AS INT  = NULL
	AS 
	SET NOCOUNT ON;
	BEGIN TRY
	BEGIN TRANSACTION

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 

	DECLARE @IDCALENDARIO AS INT

	SET @IDCALENDARIO = (SELECT TEMP.IdCalendario FROM CalendarioCita TEMP WHERE TEMP.FechaCita = @FECHA AND TEMP.IdRollMedico = @MEDICO AND IdHoraCita = @ID)

	IF @IDCALENDARIO IS NULL
	BEGIN
		INSERT INTO dbo.CalendarioCita
		(IdRollCliente,IdRollMedico,IdHoraCita,FechaCita)
		VALUES
		(@CLIENTE,@MEDICO,@ID,@FECHA)
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

