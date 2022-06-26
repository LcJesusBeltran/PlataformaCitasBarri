--CREA LA TABLA ANTES DEL SCRIPT
--CREATE DATABASE PlataformaCitas

BEGIN TRY
BEGIN TRANSACTION

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; 

		/******************************************************/
		--TABLAS PARA PLATAFORMA DE CITAS
		/******************************************************/
		
		-- se usa clustered para que los indices de la tabla se reordenen fisicamente
		-- cuando coinsida con el mismo
		
		-- non-clustered se usa cuando los indices de la tabla no coinciden con el orden
		-- de almacenamiento fisicoD
		
		--TABLA PARTE PARA CONTROL DE ELEMENTOS INICIALES
		CREATE TABLE dbo.Parte
		(
			IdParte UNIQUEIDENTIFIER NOT NULL,
			PRIMARY KEY CLUSTERED (IdParte)
		)
		
		--TABLA PERSONA TANTO PARA CLIENTES COMO PARA EMPLEADOS
		CREATE TABLE dbo.Persona
		(
			IdParte               UNIQUEIDENTIFIER NOT NULL,
			Nombre                NVARCHAR(150) NOT NULL,
			Paterno               NVARCHAR(150) NULL,
			Materno               NVARCHAR(150) NULL,
			DireccionElectronica  NVARCHAR(150) NOT NULL,
			img                   NVARCHAR(255) NULL 
			PRIMARY KEY CLUSTERED (IdParte)
		)
		ALTER TABLE dbo.Persona ADD CONSTRAINT fk_Persona_a_Parte FOREIGN KEY (IdParte) REFERENCES dbo.Parte (IdParte)
		
		--CATALOGO DE ROLES DE LOS ELEMENTOS
		CREATE TABLE dbo.TipoRollElemento
		(
			IdTipoRollElemento int NOT NULL IDENTITY(1,1),
			Descripcion nvarchar(255) NULL,
			Activo BIT NOT NULL,
			PRIMARY KEY CLUSTERED (IdTipoRollElemento)
		)
		
		--ROLES DE LOS ELEMENTOS
		CREATE TABLE dbo.RollElemento
		(
			IdRollElemento		INT NOT NULL IDENTITY(1,1),
			IdParte				UNIQUEIDENTIFIER NOT NULL,
			IdTipoRollElemento  INT NOT NULL,
			FechaInicial        DATE NOT NULL,
			FechaFinal          DATE NULL
			PRIMARY KEY CLUSTERED (IdRollElemento)
		)
		
		ALTER TABLE dbo.RollElemento ADD CONSTRAINT fk_RollElemento_a_Parte FOREIGN KEY (IdParte) REFERENCES dbo.Parte (IdParte)
		ALTER TABLE dbo.RollElemento ADD CONSTRAINT fk_RollElemento_a_TipoRollElemento FOREIGN KEY (IdTipoRollElemento) REFERENCES dbo.TipoRollElemento (IdTipoRollElemento)
		
		CREATE TABLE dbo.LoginUsuario
		(
			Id		INT NOT NULL IDENTITY(1,1),
			IdParte UNIQUEIDENTIFIER NOT NULL,
			FechaSesion DATETIME NOT NULL
			PRIMARY KEY CLUSTERED (Id)
		)
		
		ALTER TABLE dbo.LoginUsuario ADD CONSTRAINT fk_LoginUsuario_a_Parte FOREIGN KEY (IdParte) REFERENCES dbo.Parte (IdParte)
		
		CREATE TABLE dbo.HoraCita
		(
			IdHoraCita INT NOT NULL IDENTITY(1,1),
			HoraInicio INT NOT NULL,
			HoraFin    INT NOT NULL,
			Descripcion NVARCHAR(150) NULL
			PRIMARY KEY CLUSTERED (IdHoraCita)
		)
		
		CREATE TABLE dbo.CalendarioCita
		(
			IdCalendario   INT NOT NULL IDENTITY(1,1),
			IdRollCliente  INT NOT NULL,
			IdRollMedico   INT NOT NULL,
			IdHoraCita     INT NOT NULL,
			FechaCita	   DATE NOT NULL
			PRIMARY KEY CLUSTERED (IdCalendario)
		)
		
		ALTER TABLE dbo.CalendarioCita ADD CONSTRAINT fk_CalendarioCita_a_RollCliente FOREIGN KEY (IdRollCliente) REFERENCES dbo.RollElemento (IdRollElemento)
		ALTER TABLE dbo.CalendarioCita ADD CONSTRAINT fk_CalendarioCita_a_RollMedico  FOREIGN KEY (IdRollMedico)  REFERENCES dbo.RollElemento (IdRollElemento)
		ALTER TABLE dbo.CalendarioCita ADD CONSTRAINT fk_CalendarioCita_a_HoraCita    FOREIGN KEY (IdHoraCita)    REFERENCES dbo.HoraCita (IdHoraCita)

		--DROP TABLE dbo.CalendarioCita
		--DROP TABLE dbo.HoraCita
		--DROP TABLE dbo.LoginUsuario		
		--DROP TABLE dbo.Persona
		--DROP TABLE dbo.RollElemento
		--DROP TABLE dbo.TipoRollElemento
		--DROP TABLE dbo.Parte
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

