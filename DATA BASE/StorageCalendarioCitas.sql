--EXEC dbo.InsertLogin 'fox_290888@hotmail.com','Alexx Beltran Lga'

--EXEC dbo.InsertLogin fox_290888@hotmail.com,Alexx Beltran Lga

--drop procedure dbo.CalendarioCitas

CREATE PROC dbo.CalendarioCitas

	@MEDICO AS INT = NULL,
	@FECHA  AS DATE = NULL
	AS 
	SET NOCOUNT ON;
	BEGIN TRY
	BEGIN TRANSACTION

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 


		;WITH CalendarioDoctor AS
		(
			SELECT 
			  TEMP.*,
			  p.Nombre AS 'NombreCompleto' ,
			  p.DireccionElectronica
			  FROM CalendarioCita TEMP
		INNER JOIN RollElemento RE ON RE.IdRollElemento = TEMP.IdRollCliente
		INNER JOIN Persona      p  ON P.IdParte = RE.IdParte
			 WHERE TEMP.IdRollMedico = @MEDICO
		       AND TEMP.FechaCita    = @FECHA
		)
		SELECT 
		TEMP.*,
		IIF(CD.IdCalendario IS NULL,'Disponible','Ocupado') AS 'Estatus',
		CD.IdCalendario,
		CD.NombreCompleto,
		CD.DireccionElectronica,
		CD.FechaCita,
		CD.IdRollMedico
		FROM HoraCita TEMP
		LEFT JOIN CalendarioDoctor CD ON CD.IdHoraCita = TEMP.IdHoraCita

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

