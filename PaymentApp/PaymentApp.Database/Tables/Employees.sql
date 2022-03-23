CREATE TABLE [dbo].[Employees]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [AdpFileNumber] VARCHAR(10) NULL, 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [LocationID] INT NULL, 
    [VisaStatusID] INT NULL, 
    [MarkettingBy] INT NULL, 
    [ReferredBy] VARCHAR(50) NULL, 
    [DOJ] DATETIME NULL, 
    [EmployeeTypeID] INT NULL, 
    [DOL] DATETIME NULL, 
    [Status] BIT NULL, 
    CONSTRAINT [FK_Employee_Location_LocationID] FOREIGN KEY ([LocationID]) REFERENCES [Locations]([ID]), 
    CONSTRAINT [FK_Employee_VisaStatuse_VisaStatusID] FOREIGN KEY ([VisaStatusID]) REFERENCES [VisaStatus]([ID]), 
    CONSTRAINT [FK_Employees_EmployeeType_EmployeeTypeID] FOREIGN KEY ([EmployeeTypeID]) REFERENCES [EmployeeType]([ID])
)
