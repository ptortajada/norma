﻿MERGE INTO [norma].[Actions] AS Target
USING ( VALUES 
	('Listar'),
	('Consultar'),
	('Edit'),
	('Delete')
)
AS Source (Name)
ON Target.[Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Name])
	VALUES ([Name]);