USE [DB64]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 28/04/2019 9:04:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 28/04/2019 9:04:45 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 28/04/2019 9:04:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 28/04/2019 9:04:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 28/04/2019 9:04:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 28/04/2019 9:04:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 28/04/2019 9:04:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Document]    Script Date: 28/04/2019 9:04:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Document](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[LoanId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[RequiredDocuments] [varchar](max) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 28/04/2019 9:04:45 PM ******/
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
/****** Object:  Table [dbo].[EmployeeLoan]    Script Date: 28/04/2019 9:04:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLoan](
	[EmployeeId] [int] NOT NULL,
	[LoanId] [int] NOT NULL,
	[InstallementId] [int] NOT NULL,
	[AssignDate] [datetime] NULL,
	[Status] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_EmployeeLoan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Installement]    Script Date: 28/04/2019 9:04:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Installement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoanId] [int] NOT NULL,
	[InstallementPlan] [int] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Installement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Loan]    Script Date: 28/04/2019 9:04:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[TermsAndConditions] [nvarchar](max) NOT NULL,
	[Amount] [int] NOT NULL,
	[DocumentRequired] [nvarchar](max) NULL,
 CONSTRAINT [PK_Loan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 28/04/2019 9:04:45 PM ******/
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
/****** Object:  Table [dbo].[PolicyAndRules]    Script Date: 28/04/2019 9:04:45 PM ******/
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
/****** Object:  Table [dbo].[RepaymentSchedule]    Script Date: 28/04/2019 9:04:45 PM ******/
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
/****** Object:  Table [dbo].[Request]    Script Date: 28/04/2019 9:04:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[LoanId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Details] [nvarchar](max) NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalaryDeduction]    Script Date: 28/04/2019 9:04:45 PM ******/
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
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'193989ce-b02d-4977-9068-871caee42acc', N'maham@gmail.com', 0, N'AMKLETl+YYjBJ/VAKmXMAs77EunfYrHyZ7VVJ4r1o101E8Gs+ggFZ8rNtplSyC6eCA==', N'a371fd19-795f-43ef-9cab-56e7fe263f87', NULL, 0, 0, NULL, 1, 0, N'maham@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9f63ef15-f629-467b-9480-e5b28484f711', N'yo@gmail.com', 0, N'AK0PMaHPiNBwr/iV4Ik/rITFR3Na59cqAAzEItBzCZ3xYO5ToLOvLAxFeCxEQ/8QMg==', N'7a349fcc-58f2-4872-9963-cb99c7ad8bb2', NULL, 0, 0, NULL, 1, 0, N'yo@gmail.com')
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [Contact], [Email], [Rank], [Salary]) VALUES (1, N'maham', N'azmat', N'03324301479', N'maham@gmail.com', N'Manager', 13000000)
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [Contact], [Email], [Rank], [Salary]) VALUES (2, N'yo', N'yoyu', N'03324301479', N'yo@gmail.com', N'Intermediate Staff', 13000000)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[EmployeeLoan] ON 

INSERT [dbo].[EmployeeLoan] ([EmployeeId], [LoanId], [InstallementId], [AssignDate], [Status], [Id]) VALUES (1, 3, 4, NULL, 2, 2)
INSERT [dbo].[EmployeeLoan] ([EmployeeId], [LoanId], [InstallementId], [AssignDate], [Status], [Id]) VALUES (1, 3, 4, NULL, 2, 3)
INSERT [dbo].[EmployeeLoan] ([EmployeeId], [LoanId], [InstallementId], [AssignDate], [Status], [Id]) VALUES (1, 3, 4, NULL, 2, 4)
SET IDENTITY_INSERT [dbo].[EmployeeLoan] OFF
SET IDENTITY_INSERT [dbo].[Installement] ON 

INSERT [dbo].[Installement] ([Id], [LoanId], [InstallementPlan], [Amount]) VALUES (2, 2, 6, 75000)
INSERT [dbo].[Installement] ([Id], [LoanId], [InstallementPlan], [Amount]) VALUES (3, 3, 7, 64285)
INSERT [dbo].[Installement] ([Id], [LoanId], [InstallementPlan], [Amount]) VALUES (4, 3, 11, 40909)
INSERT [dbo].[Installement] ([Id], [LoanId], [InstallementPlan], [Amount]) VALUES (5, 4, 10, 32555)
SET IDENTITY_INSERT [dbo].[Installement] OFF
SET IDENTITY_INSERT [dbo].[Loan] ON 

INSERT [dbo].[Loan] ([Id], [Detail], [TermsAndConditions], [Amount], [DocumentRequired]) VALUES (2, N'fgfg', N'gfgfg', 450000, NULL)
INSERT [dbo].[Loan] ([Id], [Detail], [TermsAndConditions], [Amount], [DocumentRequired]) VALUES (3, N'hhghgdhs', N' nSbdn', 450000, N'cnic, metric result card
')
INSERT [dbo].[Loan] ([Id], [Detail], [TermsAndConditions], [Amount], [DocumentRequired]) VALUES (4, N'hghgh', N'hghghh', 325555, N'cnic')
SET IDENTITY_INSERT [dbo].[Loan] OFF
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (1, N'Approve', N'LOAN_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (2, N'Disapprove', N'LOAN_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (3, N'Accept', N'REQUEST_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (4, N'Reject', N'REQUEST_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (5, N'Pending', N'REQUEST_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (6, N'Paid', N'INSTALLEMENT_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (7, N'Due', N'INSTALLEMENT_STATUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (8, N'NotVerified', N'DOCUMENT_STAUS')
INSERT [dbo].[Lookup] ([LookupId], [Name], [Category]) VALUES (9, N'Verified', N'DOCUMENT_STATUS')
SET IDENTITY_INSERT [dbo].[PolicyAndRules] ON 

INSERT [dbo].[PolicyAndRules] ([Id], [LoanId], [Detail], [Rank], [Salary]) VALUES (5, 2, N'dd', N'Senior Staff', 455555)
INSERT [dbo].[PolicyAndRules] ([Id], [LoanId], [Detail], [Rank], [Salary]) VALUES (6, 3, N'ghsuduias', N'Senior Director', 4509)
INSERT [dbo].[PolicyAndRules] ([Id], [LoanId], [Detail], [Rank], [Salary]) VALUES (7, 4, N'hkhhghgbh', N'Senior Staff', 13000000)
SET IDENTITY_INSERT [dbo].[PolicyAndRules] OFF
SET IDENTITY_INSERT [dbo].[Request] ON 

INSERT [dbo].[Request] ([Id], [EmployeeId], [LoanId], [Status], [Details]) VALUES (3, 1, 2, 3, N'Request is accepted because salary fulfills the policy of this loan')
INSERT [dbo].[Request] ([Id], [EmployeeId], [LoanId], [Status], [Details]) VALUES (4, 2, 2, 3, N'Request is accepted because salary fulfills the policy of this loan')
INSERT [dbo].[Request] ([Id], [EmployeeId], [LoanId], [Status], [Details]) VALUES (5, 1, 3, 3, N'Request is accepted because salary fulfills the policy of this loan')
INSERT [dbo].[Request] ([Id], [EmployeeId], [LoanId], [Status], [Details]) VALUES (6, 1, 4, 3, N'Request is accepted because salary fulfills the policy of this loan')
INSERT [dbo].[Request] ([Id], [EmployeeId], [LoanId], [Status], [Details]) VALUES (7, 1, 2, 3, N'Request is accepted because salary fulfills the policy of this loan')
SET IDENTITY_INSERT [dbo].[Request] OFF
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
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
