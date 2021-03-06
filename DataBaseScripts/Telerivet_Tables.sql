/****** Object:  Table [dbo].[Telerivet_Routes]    Script Date: 04/10/2016 00:33:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telerivet_Routes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TelerivetID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ProjectId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Telerivet_Routes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telerivet_Projects]    Script Date: 04/10/2016 00:33:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telerivet_Projects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TelerivetID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TimezoneId] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[UserID] [uniqueidentifier] NULL,
	[Phones] [int] NOT NULL,
	[Contacts] [int] NOT NULL,
	[DataTables] [int] NOT NULL,
	[Groups] [int] NOT NULL,
	[Labels] [int] NOT NULL,
	[Messages] [int] NOT NULL,
	[Receipts] [int] NOT NULL,
	[Routes] [int] NOT NULL,
	[ScheduledMessages] [int] NOT NULL,
	[Services] [int] NOT NULL,
 CONSTRAINT [PK_Telerivet_Projects] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telerivet_Phones]    Script Date: 04/10/2016 00:33:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telerivet_Phones](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TelerivetID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[PhoneType] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[TimeCreated] [bigint] NULL,
	[LastActiveTime] [bigint] NULL,
	[ProjectId] [nvarchar](50) NOT NULL,
	[Battery] [int] NULL,
	[Charging] [bit] NULL,
	[AppVersion] [nvarchar](50) NULL,
	[AndroidSdk] [int] NULL,
	[Mccmnc] [nvarchar](50) NULL,
	[Manufacturer] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[SendLimit] [int] NULL,
	[Messages] [int] NOT NULL,
 CONSTRAINT [PK_Telerivet_Phones] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telerivet_Messages]    Script Date: 04/10/2016 00:33:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telerivet_Messages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TelerivetID] [nvarchar](50) NOT NULL,
	[Direction] [nvarchar](10) NOT NULL,
	[Status] [nvarchar](15) NOT NULL,
	[MessageType] [nvarchar](4) NOT NULL,
	[Source] [nvarchar](10) NULL,
	[TimeCreated] [bigint] NULL,
	[TimeSent] [bigint] NULL,
	[FromNumber] [nvarchar](50) NULL,
	[ToNumber] [nvarchar](50) NULL,
	[Content] [nvarchar](max) NULL,
	[Starred] [bit] NULL,
	[Simulated] [bit] NOT NULL,
	[ErrorMessage] [nvarchar](max) NULL,
	[ExternalId] [nvarchar](50) NULL,
	[Price] [decimal](18, 6) NULL,
	[PriceCurrency] [nvarchar](50) NULL,
	[PhoneId] [nvarchar](50) NULL,
	[ContactId] [nvarchar](50) NULL,
	[ProjectId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Telerivet_Messages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telerivet_Groups]    Script Date: 04/10/2016 00:33:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telerivet_Groups](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TelerivetID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[NumMembers] [int] NOT NULL,
	[ProjectId] [nvarchar](50) NOT NULL,
	[TimeCreated] [bigint] NOT NULL,
	[Contacts] [int] NOT NULL,
	[ScheduledMessages] [int] NOT NULL,
 CONSTRAINT [PK_Telerivet_Groups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telerivet_Contacts]    Script Date: 04/10/2016 00:33:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telerivet_Contacts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TelerivetID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[TimeCreated] [bigint] NOT NULL,
	[LastMessageTime] [bigint] NULL,
	[LastMessageId] [nvarchar](50) NULL,
	[DefaultRouteId] [nvarchar](50) NULL,
	[GroupIds] [nvarchar](max) NULL,
	[ProjectId] [nvarchar](50) NULL,
	[Messages] [int] NOT NULL,
	[Groups] [int] NOT NULL,
	[ScheduledMessages] [int] NOT NULL,
	[DataRows] [int] NOT NULL,
	[ServiceStates] [int] NOT NULL,
 CONSTRAINT [PK_Telerivet_Contacts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Default [DF_Telerivet_Contacts_Messages]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Contacts] ADD  CONSTRAINT [DF_Telerivet_Contacts_Messages]  DEFAULT ((0)) FOR [Messages]
GO
/****** Object:  Default [DF_Telerivet_Contacts_Groups]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Contacts] ADD  CONSTRAINT [DF_Telerivet_Contacts_Groups]  DEFAULT ((0)) FOR [Groups]
GO
/****** Object:  Default [DF_Telerivet_Contacts_ScheduledMessages]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Contacts] ADD  CONSTRAINT [DF_Telerivet_Contacts_ScheduledMessages]  DEFAULT ((0)) FOR [ScheduledMessages]
GO
/****** Object:  Default [DF_Telerivet_Contacts_DataRows]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Contacts] ADD  CONSTRAINT [DF_Telerivet_Contacts_DataRows]  DEFAULT ((0)) FOR [DataRows]
GO
/****** Object:  Default [DF_Telerivet_Contacts_ServiceStates]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Contacts] ADD  CONSTRAINT [DF_Telerivet_Contacts_ServiceStates]  DEFAULT ((0)) FOR [ServiceStates]
GO
/****** Object:  Default [DF_Telerivet_Groups_NumMembers]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Groups] ADD  CONSTRAINT [DF_Telerivet_Groups_NumMembers]  DEFAULT ((0)) FOR [NumMembers]
GO
/****** Object:  Default [DF_Telerivet_Groups_Contacts]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Groups] ADD  CONSTRAINT [DF_Telerivet_Groups_Contacts]  DEFAULT ((0)) FOR [Contacts]
GO
/****** Object:  Default [DF_Telerivet_Groups_ScheduledMessages]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Groups] ADD  CONSTRAINT [DF_Telerivet_Groups_ScheduledMessages]  DEFAULT ((0)) FOR [ScheduledMessages]
GO
/****** Object:  Default [DF_Telerivet_Messages_Starred]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Messages] ADD  CONSTRAINT [DF_Telerivet_Messages_Starred]  DEFAULT ((0)) FOR [Starred]
GO
/****** Object:  Default [DF_Telerivet_Messages_Simulated]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Messages] ADD  CONSTRAINT [DF_Telerivet_Messages_Simulated]  DEFAULT ((0)) FOR [Simulated]
GO
/****** Object:  Default [DF_Telerivet_Phones_Messages]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Phones] ADD  CONSTRAINT [DF_Telerivet_Phones_Messages]  DEFAULT ((0)) FOR [Messages]
GO
/****** Object:  Default [DF_Telerivet_Project_Active]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Projects] ADD  CONSTRAINT [DF_Telerivet_Project_Active]  DEFAULT ((0)) FOR [Active]
GO
/****** Object:  Default [DF_Telerivet_Project_UserID]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Projects] ADD  CONSTRAINT [DF_Telerivet_Project_UserID]  DEFAULT (NULL) FOR [UserID]
GO
/****** Object:  Default [DF_Telerivet_Projects_Phones]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Projects] ADD  CONSTRAINT [DF_Telerivet_Projects_Phones]  DEFAULT ((0)) FOR [Phones]
GO
/****** Object:  Default [DF_Telerivet_Projects_Contacts]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Projects] ADD  CONSTRAINT [DF_Telerivet_Projects_Contacts]  DEFAULT ((0)) FOR [Contacts]
GO
/****** Object:  Default [DF_Telerivet_Projects_DataTables]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Projects] ADD  CONSTRAINT [DF_Telerivet_Projects_DataTables]  DEFAULT ((0)) FOR [DataTables]
GO
/****** Object:  Default [DF_Telerivet_Projects_Groups]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Projects] ADD  CONSTRAINT [DF_Telerivet_Projects_Groups]  DEFAULT ((0)) FOR [Groups]
GO
/****** Object:  Default [DF_Telerivet_Projects_Labels]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Projects] ADD  CONSTRAINT [DF_Telerivet_Projects_Labels]  DEFAULT ((0)) FOR [Labels]
GO
/****** Object:  Default [DF_Telerivet_Projects_Messages]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Projects] ADD  CONSTRAINT [DF_Telerivet_Projects_Messages]  DEFAULT ((0)) FOR [Messages]
GO
/****** Object:  Default [DF_Telerivet_Projects_Receipts]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Projects] ADD  CONSTRAINT [DF_Telerivet_Projects_Receipts]  DEFAULT ((0)) FOR [Receipts]
GO
/****** Object:  Default [DF_Telerivet_Projects_Routes]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Projects] ADD  CONSTRAINT [DF_Telerivet_Projects_Routes]  DEFAULT ((0)) FOR [Routes]
GO
/****** Object:  Default [DF_Telerivet_Projects_ScheduledMessages]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Projects] ADD  CONSTRAINT [DF_Telerivet_Projects_ScheduledMessages]  DEFAULT ((0)) FOR [ScheduledMessages]
GO
/****** Object:  Default [DF_Telerivet_Projects_Services]    Script Date: 04/10/2016 00:33:08 ******/
ALTER TABLE [dbo].[Telerivet_Projects] ADD  CONSTRAINT [DF_Telerivet_Projects_Services]  DEFAULT ((0)) FOR [Services]
GO
