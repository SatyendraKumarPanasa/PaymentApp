
Create table Locations(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
Name varchar(50)  NULL,
Code varchar(50)  Null
)

Create table VisaStatus	(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
Name varchar(50)  NULL,
Description varchar(50)  Null
)

Create table EmployeeType(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
Name varchar(50)  NULL,
Description varchar(50)  Null
)

Create table ProjectStatus(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
Name varchar(50)  NULL,
Description varchar(50)  Null
)

Create table Roles(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
Name varchar(50)  NULL,
Description varchar(50)  Null
)

Create table Vendors(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
Name varchar(50)  NULL,
StartDate Datetime  Null,
EndDate Datetime  Null,
Status Bit  Null
)

Create table Projects(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
Name varchar(50)  NULL,
StartDate Datetime  Null,
EndDate Datetime  Null,
Status Bit  Null
)

Create table Clients(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
Name varchar(50)  NULL,
StartDate Datetime  Null,
EndDate Datetime  Null,
Status Bit  Null
)

Create table Benfits(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
Year Int  Null,
Insurance int  Null,
Pto Int  Null,
401K Bit  Null
)

Create table Employees(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
AdpFileNumber Varchar(10)  Null,
FirstName Varchar(50)  Null,
LastName Varchar(50)  Null,
LocationID int FOREIGN KEY REFERENCES Locations(ID),
VisaStatusID int FOREIGN KEY REFERENCES VisaStatus(ID),
MarkettingBy int  null,
ReferredBy Varchar(50)  Null,
DOJ DateTime  Null,
EmployeeTypeID int FOREIGN KEY REFERENCES EmployeeType(ID),
DOL DateTime  Null,
Status Bit  null,
)

Create table EmployeeProjects(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
EmployeeID int Foreign Key References Employees(ID),
ProjectID int Foreign Key References Projects(ID),
Vendor1ID int Foreign Key References Vendors(ID),
Vendor2ID int Foreign Key References Vendors(ID),
EndClientID int Foreign Key References Clients(ID),
StartDate DateTime  Null,
EndDate DateTime  Null,
)



Create table EmployeeProjectPayDetails(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
EmployeeProjectID int Foreign Key References EmployeeProjects(ID),
SalaryTypeID int Foreign Key References SalaryType(ID),
BillRate Decimal  null,
H1Wages Decimal  Null,
SalaryOffered Decimal  Null,
PayPercentage Decimal  Null,
HourlyRate Decimal  Null,
PTO Bit  Null,
InsurenceByUs Bit  Null
)

Create table EmployeeNotes(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
EmployeeID int Foreign Key References Employees(ID),
Notes Varchar(MAX)
 
)

Create table Users(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
FirstName Varchar(50)  Null,
LastName Varchar(50)  Null,
RoleID int Foreign Key References Roles(ID),
StartDate DateTime  Null,
EndDate DateTime  Null,
Status Bit  Null
)

Create table EmployeeProjectsHistory(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
EmployeeID int Foreign Key References Employees(ID),
ProjectID int Foreign Key References Projects(ID),
Vendor1ID int Foreign Key References Vendors(ID),
Vendor2ID int Foreign Key References Vendors(ID),
EndClientID int Foreign Key References Clients(ID),
StartDate DateTime  Null,
EndDate DateTime  Null
)

Create table EmployeeProjectPayDetailsHistory(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
EmployeeID int Foreign Key References Employees(ID),
SalaryTypeID int Foreign Key References SalaryType(ID),
BillRate Decimal  null,
H1Wages Decimal  null,
SalaryOffered Decimal  null,
PayPercentage Decimal  null,
HourlyRate Decimal  null,
PTO Bit  Null,
InsuranceByUs Bit  Null
)

Create table EmployeePayments(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
EmployeeID int Foreign Key References Employees(ID),
StartDate DateTime  null,
EndDate DateTime  null,
PayDate DateTime  null,
STDHours int  null,
RegHoursWorked int  null,
OTHours int  null,
PTOHours int  null,
Status Bit  null
)

Create table SalaryType(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
Name Varchar(50)  Null,
Description Varchar(50)  Null
)

Create table EmployeesHistory(
ID int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
AdpFileNumber Varchar(10)  Null,
FirstName Varchar(50)  Null,
LastName Varchar(50)  Null,
LocationID int FOREIGN KEY REFERENCES Locations(ID),
VisaStatusID int FOREIGN KEY REFERENCES VisaStatus(ID),
MarkettingBy int  null,
ReferredBy Varchar(50)  Null,
DOJ DateTime  Null,
EmployeeTypeID int FOREIGN KEY REFERENCES Employees(ID),
DOL DateTime  Null,
Status Bit  null
)



