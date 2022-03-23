CREATE TABLE [dbo].[Clients]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NULL, 
    [StartDate] DATETIME NULL, 
    [EndDate] DATETIME NULL, 
    [Status] BIT NULL
)
