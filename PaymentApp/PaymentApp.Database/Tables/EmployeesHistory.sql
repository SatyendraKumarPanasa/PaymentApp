CREATE TABLE [dbo].[EmployeesHistory]
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
    CONSTRAINT [FK_EmployeesHistory_Locations_LocationID] FOREIGN KEY ([LocationID]) REFERENCES [Locations]([ID]), 
    CONSTRAINT [FK_EmployeesHistory_VisaStatus_VisaStatusID] FOREIGN KEY ([VisaStatusID]) REFERENCES [VisaStatus]([ID]), 
    CONSTRAINT [FK_EmployeesHistory_EmployeeType_EmployeeTypeID] FOREIGN KEY ([EmployeeTypeID]) REFERENCES [EmployeeType]([ID])
)
