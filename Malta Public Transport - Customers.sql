USE [Tallinja]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 25/07/2021 23:44:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[customer_id] [uniqueidentifier] NOT NULL,
	[customer_number] [int] NOT NULL,
	[date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[customer_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customers] ADD  DEFAULT (newid()) FOR [customer_id]
GO

ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [CK_CN_LEN] CHECK  ((len([customer_number])>=(6) AND len([customer_number])<=(8)))
GO

ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [CK_CN_LEN]
GO


