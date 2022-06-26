		--DECLARE @IdParte AS UNIQUEIDENTIFIER
		--SET @IdParte = NEWID()
		--INSERT INTO dbo.Parte(IdParte)VALUES(@IdParte)
		--INSERT INTO dbo.Persona
		--(IdParte,Nombre,Paterno,Materno,DireccionElectronica)
		--VALUES
		--(@IdParte,'Jesus','Beltran','Lizarraga','fox_290888@hotmail.com')

		
		--INSERT INTO dbo.RollElemento
		--(IdParte,IdTipoRollElemento,FechaInicial)
		--SELECT temp.IdParte,tre.IdTipoRollElemento,GETDATE() FROM dbo.Persona TEMP
		--INNER JOIN dbo.TipoRollElemento tre ON tre.Descripcion = 'Cliente'
		--left join dbo.RollElemento rr on rr.IdParte = temp.IdParte
		--where rr.IdParte is null 

		