CREATE TABLE [dbo].[menus]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(30) NOT NULL, 
    [Indication] NCHAR(30) NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [Count] INT NOT NULL
)
