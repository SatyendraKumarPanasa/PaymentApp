CREATE TABLE [dbo].[EmployeeNotes]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [EmployeeID] INT NULL, 
    [Notes] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_EmployeeNotes_Employees_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [Employees]([ID])
)
