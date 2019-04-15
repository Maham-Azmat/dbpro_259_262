USE [DB64]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 15/04/2019 11:49:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmailId] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Document]    Script Date: 15/04/2019 11:49:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[LoanId] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[RequiredDocuments] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 15/04/2019 11:49:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Contact] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Rank] [nvarchar](50) NOT NULL,
	[Salary] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeLoan]    Script Date: 15/04/2019 11:49:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLoan](
	[EmployeeId] [int] NOT NULL,
	[LoanId] [int] NOT NULL,
	[PolicyId] [int] NOT NULL,
	[InstallementId] [int] NOT NULL,
	[AssignDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_EmployeeLoan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Installement]    Script Date: 15/04/2019 11:49:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Installement](
	[Id] [int] NOT NULL,
	[LoanId] [int] NOT NULL,
	[InstallementPlan] [int] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Installement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Loan]    Script Date: 15/04/2019 11:49:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[TermsAndConditions] [nvarchar](max) NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Loan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 15/04/2019 11:49:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookup](
	[LookupId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[LookupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PolicyAndRules]    Script Date: 15/04/2019 11:49:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PolicyAndRules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoanId] [int] NOT NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[Rank] [nvarchar](50) NOT NULL,
	[Salary] [int] NOT NULL,
 CONSTRAINT [PK_PolicyAndRules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RepaymentSchedule]    Script Date: 15/04/2019 11:49:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RepaymentSchedule](
	[EmployeeId] [int] NOT NULL,
	[InstallementId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_RepaymentSchedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Request]    Script Date: 15/04/2019 11:49:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[LoanId] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalaryDeduction]    Script Date: 15/04/2019 11:49:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryDeduction](
	[EmployeeId] [int] NOT NULL,
	[LoanId] [int] NOT NULL,
	[InstallementId] [int] NOT NULL,
	[SalaryAfterDeduction] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SalaryDeduction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (1, N'Approve', N'LOAN_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (2, N'Disapprove', N'LOAN_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (3, N'Accept', N'REQUEST_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (4, N'Reject', N'REQUEST_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (5, N'Paid', N'INSTALLEMENT_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (8, N'Due', N'INSTALLEMENT_STATUS')
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Employee]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Loan] FOREIGN KEY([LoanId])
REFERENCES [dbo].[Loan] ([Id])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Loan]
GO
ALTER TABLE [dbo].[EmployeeLoan]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeLoan_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeLoan] CHECK CONSTRAINT [FK_EmployeeLoan_Employee]
GO
ALTER TABLE [dbo].[EmployeeLoan]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeLoan_Installement] FOREIGN KEY([InstallementId])
REFERENCES [dbo].[Installement] ([Id])
GO
ALTER TABLE [dbo].[EmployeeLoan] CHECK CONSTRAINT [FK_EmployeeLoan_Installement]
GO
ALTER TABLE [dbo].[EmployeeLoan]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeLoan_Loan] FOREIGN KEY([LoanId])
REFERENCES [dbo].[Loan] ([Id])
GO
ALTER TABLE [dbo].[EmployeeLoan] CHECK CONSTRAINT [FK_EmployeeLoan_Loan]
GO
ALTER TABLE [dbo].[EmployeeLoan]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeLoan_PolicyAndRules] FOREIGN KEY([PolicyId])
REFERENCES [dbo].[PolicyAndRules] ([Id])
GO
ALTER TABLE [dbo].[EmployeeLoan] CHECK CONSTRAINT [FK_EmployeeLoan_PolicyAndRules]
GO
ALTER TABLE [dbo].[Installement]  WITH CHECK ADD  CONSTRAINT [FK_Installement_Loan] FOREIGN KEY([LoanId])
REFERENCES [dbo].[Loan] ([Id])
GO
ALTER TABLE [dbo].[Installement] CHECK CONSTRAINT [FK_Installement_Loan]
GO
ALTER TABLE [dbo].[PolicyAndRules]  WITH CHECK ADD  CONSTRAINT [FK_PolicyAndRules_Loan] FOREIGN KEY([LoanId])
REFERENCES [dbo].[Loan] ([Id])
GO
ALTER TABLE [dbo].[PolicyAndRules] CHECK CONSTRAINT [FK_PolicyAndRules_Loan]
GO
ALTER TABLE [dbo].[RepaymentSchedule]  WITH CHECK ADD  CONSTRAINT [FK_RepaymentSchedule_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[RepaymentSchedule] CHECK CONSTRAINT [FK_RepaymentSchedule_Employee]
GO
ALTER TABLE [dbo].[RepaymentSchedule]  WITH CHECK ADD  CONSTRAINT [FK_RepaymentSchedule_Installement] FOREIGN KEY([InstallementId])
REFERENCES [dbo].[Installement] ([Id])
GO
ALTER TABLE [dbo].[RepaymentSchedule] CHECK CONSTRAINT [FK_RepaymentSchedule_Installement]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Employee]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Loan] FOREIGN KEY([LoanId])
REFERENCES [dbo].[Loan] ([Id])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Loan]
GO
ALTER TABLE [dbo].[SalaryDeduction]  WITH CHECK ADD  CONSTRAINT [FK_SalaryDeduction_Emloyee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[SalaryDeduction] CHECK CONSTRAINT [FK_SalaryDeduction_Emloyee]
GO
ALTER TABLE [dbo].[SalaryDeduction]  WITH CHECK ADD  CONSTRAINT [FK_SalaryDeduction_Installement] FOREIGN KEY([InstallementId])
REFERENCES [dbo].[Installement] ([Id])
GO
ALTER TABLE [dbo].[SalaryDeduction] CHECK CONSTRAINT [FK_SalaryDeduction_Installement]
GO
ALTER TABLE [dbo].[SalaryDeduction]  WITH CHECK ADD  CONSTRAINT [FK_SalaryDeduction_Loan] FOREIGN KEY([LoanId])
REFERENCES [dbo].[Loan] ([Id])
GO
ALTER TABLE [dbo].[SalaryDeduction] CHECK CONSTRAINT [FK_SalaryDeduction_Loan]
GO
