CREATE TABLE [dbo].[EmployeePayments]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [EmployeeID] INT NULL, 
    [StartDate] DATETIME NULL, 
    [EndDate] DATETIME NULL, 
    [PayDate] DATETIME NULL, 
    [STDHours] INT NULL, 
    [RegHoursWorked] INT NULL, 
    [OTHours] INT NULL, 
    [PTOHours] INT NULL, 
    [Status] BIT NULL, 
    CONSTRAINT [FK_EmployeePayments_Employees_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [Employees]([ID])
)
