# MVCFormsAuthentication_SoftDelete
SQL SERVER DATABASE
-------------------
create database MVCAuthentication

use MVCAuthentication

--EMPLOYEE TABLE
CREATE TABLE [dbo].[Employee](  
    [Id] [int] IDENTITY(1,1) NOT NULL,  
    [Name] [nvarchar](50) NULL,  
    [Gender] [char](10) NULL,  
    [Age] [int] NULL,  
    [Position] [nvarchar](50) NULL,  
    [Office] [nvarchar](50) NULL,  
    [HireDate] [datetime] NULL,  
    [Salary] [int] NULL,  
    [DepartmentId] [int] NULL,  
PRIMARY KEY CLUSTERED   
(  
    [Id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
GO  

--DEPARTMENT TABLE
CREATE TABLE [dbo].[Department](  
    [Id] [int] IDENTITY(1,1) NOT NULL,  
    [DepartmentName] [nvarchar](50) NULL,  
PRIMARY KEY CLUSTERED   
(  
    [Id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
GO  
  
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([DepartmentId])  
REFERENCES [dbo].[Department] ([Id])  
GO  

--USERS TABLE
CREATE TABLE [dbo].[Users](  
    [Id] [int] IDENTITY(1,1) NOT NULL,  
    [Username] [nvarchar](50) NULL,  
    [Password] [nvarchar](50) NULL,  
PRIMARY KEY CLUSTERED   
(  
    [Id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
GO  

--ROLES TABLE
CREATE TABLE [dbo].[Roles](  
    [Id] [int] IDENTITY(1,1) NOT NULL,  
    [RoleName] [nvarchar](50) NULL,  
PRIMARY KEY CLUSTERED   
(  
    [Id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
GO  

--USERROLESMAPPING TBALE
CREATE TABLE [dbo].[UserRolesMapping](  
    [Id] [int] IDENTITY(1,1) NOT NULL,  
    [UserId] [int] NULL,  
    [RoleId] [int] NULL,  
PRIMARY KEY CLUSTERED   
(  
    [Id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
GO  
  
ALTER TABLE [dbo].[UserRolesMapping]  WITH CHECK ADD FOREIGN KEY([RoleId])  
REFERENCES [dbo].[Roles] ([Id])  
GO  
  
ALTER TABLE [dbo].[UserRolesMapping]  WITH CHECK ADD FOREIGN KEY([RoleId])  
REFERENCES [dbo].[Roles] ([Id])  
GO  
  
ALTER TABLE [dbo].[UserRolesMapping]  WITH CHECK ADD FOREIGN KEY([UserId])  
REFERENCES [dbo].[Users] ([Id])  
GO  

SELECT * FROM USERS
SELECT * FROM EMPLOYEE

SELECT * FROM DEPARTMENT
INSERT INTO DEPARTMENT VALUES('DEVELOPER'),('TESTER'),('ADMIN'),('HR'),('TRAINER')

ALTER TABLE EMPLOYEE
  ADD Status varchar(10) NOT NULL DEFAULT 'Active';
GO

CREATE OR ALTER TRIGGER SoftDelete_Employee ON EMPLOYEE
  INSTEAD OF DELETE AS
BEGIN
SET NOCOUNT ON;
UPDATE EMPLOYEE
  SET Status = 'InActive'
  WHERE Id IN (SELECT Id FROM deleted);
END
GO

---------------------
ASP.NET MVC
-----------
1. DATABASE FIRST APPROACH USING ENTITY FRAMEWORK
2. FORMS AUTHENTICATION
3. SOFT DELETE
4. CRUD
