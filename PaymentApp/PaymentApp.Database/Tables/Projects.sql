CREATE TABLE [dbo].[Projects]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NULL, 
    [StartDate] DATETIME NULL, 
    [EndDate] DATETIME NULL, 
    [Status] BIT NULL
)
