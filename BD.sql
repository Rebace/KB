use Recipe
IF NOT EXISTS( SELECT TOP 1 1 FROM sys.tables WHERE [name] = 'Recipe' )
BEGIN
	CREATE TABLE [Recipe] (
		[Id] INT IDENTITY(1,1) CONSTRAINT PK_todo PRIMARY KEY,
		[Title] NVARCHAR(255) NOT NULL,
		[Description] NVARCHAR(255) NOT NULL,
		[CookingTime] INT,
		[Portions] INT,
		[Stars] INT,
		[Likes] INT
	)
END