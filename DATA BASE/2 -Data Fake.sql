--CREA LA TABLA ANTES DEL SCRIPT
--CREATE DATABASE PlataformaCitas

BEGIN TRY
BEGIN TRANSACTION

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 

	DECLARE @IdParte AS UNIQUEIDENTIFIER

		/**********************************************************************/
		--DOCTORES FAKE
		/**********************************************************************/
		SET @IdParte = NEWID()
		INSERT INTO dbo.Parte(IdParte)VALUES(@IdParte)
		INSERT INTO dbo.Persona
		(IdParte,Nombre,Paterno,Materno,DireccionElectronica)
		VALUES
		(@IdParte,'Raul','Degollado','Gallardo','rdegollado@datafake.com')

		SET @IdParte = NEWID()
		INSERT INTO dbo.Parte(IdParte)VALUES(@IdParte)
		INSERT INTO dbo.Persona
		(IdParte,Nombre,Paterno,Materno,DireccionElectronica)
		VALUES
		(@IdParte,'Julio','Osuna','Osuna','josuna@datafake.com')

		SET @IdParte = NEWID()
		INSERT INTO dbo.Parte(IdParte)VALUES(@IdParte)
		INSERT INTO dbo.Persona
		(IdParte,Nombre,Paterno,Materno,DireccionElectronica)
		VALUES
		(@IdParte,'Karen','Ruelas','Corona','kruelas@datafake.com')
		/**********************************************************************/
		--TIPO ROLL ELEMENTO
		/**********************************************************************/
		INSERT INTO dbo.TipoRollElemento(Descripcion,Activo)VALUES('Medico',1)	
		INSERT INTO dbo.TipoRollElemento(Descripcion,Activo)VALUES('Cliente',1)	
		/**********************************************************************/
		--ROLL ELEMENTO PARA DATA FAKE
		/**********************************************************************/
		INSERT INTO dbo.RollElemento
		(IdParte,IdTipoRollElemento,FechaInicial)
		SELECT temp.IdParte,tre.IdTipoRollElemento,GETDATE() FROM dbo.Persona TEMP
		INNER JOIN dbo.TipoRollElemento tre ON tre.Descripcion = 'Medico'
		/**********************************************************************/
		--HORA CITA
		/**********************************************************************/
		INSERT INTO dbo.HoraCita(HoraInicio,HoraFin,Descripcion)VALUES(10,11,'10:00 am a 11:00 am')
		INSERT INTO dbo.HoraCita(HoraInicio,HoraFin,Descripcion)VALUES(11,12,'11:00 am a 12:00 pm')
		INSERT INTO dbo.HoraCita(HoraInicio,HoraFin,Descripcion)VALUES(12,1,'12:00 pm a 1:00 pm')
		INSERT INTO dbo.HoraCita(HoraInicio,HoraFin,Descripcion)VALUES(1,2,'1:00 pm a 2:00 pm')
		INSERT INTO dbo.HoraCita(HoraInicio,HoraFin,Descripcion)VALUES(2,3,'2:00 pm a 3:00 pm')
		INSERT INTO dbo.HoraCita(HoraInicio,HoraFin,Descripcion)VALUES(3,4,'3:00 pm a 4:00 pm')
		INSERT INTO dbo.HoraCita(HoraInicio,HoraFin,Descripcion)VALUES(4,5,'4:00 pm a 5:00 pm')		
		
		
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

