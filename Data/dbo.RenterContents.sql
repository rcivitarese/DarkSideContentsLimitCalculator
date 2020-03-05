CREATE TABLE [dbo].[RenterContents]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ItemName] NCHAR(255) NOT NULL, 
    [Value] MONEY NOT NULL, 
    [CategoryID] INT NOT NULL
)
