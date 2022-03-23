CREATE TABLE [dbo].[EmployeeProjectPayDetailsHistory]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [EmployeeProjectID] INT NULL, 
    [SalaryTypeID] INT NULL, 
    [BillRate] DECIMAL NULL, 
    [H1Wages] DECIMAL NULL, 
    [SalaryOffered] DECIMAL NULL, 
    [PayPercentage] DECIMAL NULL, 
    [HourlyRate] DECIMAL NULL, 
    [PTO] BIT NULL, 
    [InsurenceByUs] BIT NULL, 
    CONSTRAINT [FK_EmployeeProjectPayDetailsHistory_EmployeeProjects_EmployeeProjectID] FOREIGN KEY ([EmployeeProjectID]) REFERENCES [EmployeeProjects]([ID]), 
    CONSTRAINT [FK_EmployeeProjectPayDetailsHistory_SalaryType_SalaryTypeID] FOREIGN KEY ([SalaryTypeID]) REFERENCES [SalaryType]([ID])
)
