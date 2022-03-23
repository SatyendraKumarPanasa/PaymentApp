CREATE TABLE [dbo].[EmployeeProjectsHistory]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [EmployeeID] INT NULL, 
    [ProjectID] INT NULL, 
    [Vendor1ID] INT NULL, 
    [Vendor2ID] INT NULL, 
    [EndClientID] INT NULL, 
    [StartDate] DATETIME NULL, 
    [EndDate] DATETIME NULL, 
    CONSTRAINT [FK_EmployeeProjectsHistory_Projects_ProjectID] FOREIGN KEY ([ProjectID]) REFERENCES [Projects]([ID]), 
    CONSTRAINT [FK_EmployeeProjectsHistory_Vendors_Vendor1ID] FOREIGN KEY ([Vendor1ID]) REFERENCES [Vendors]([ID]), 
    CONSTRAINT [FK_EmployeeProjectsHistory_Vendors_Vendor2ID] FOREIGN KEY ([Vendor2ID]) REFERENCES [Vendors]([ID]), 
    CONSTRAINT [FK_EmployeeProjectsHistory_Clients_EndClientID] FOREIGN KEY ([EndClientID]) REFERENCES [Clients]([ID])
)
