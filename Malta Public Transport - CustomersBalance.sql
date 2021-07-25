USE [Tallinja]
GO

/****** Object:  Table [dbo].[CustomersBalance]    Script Date: 25/07/2021 23:45:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomersBalance](
	[customer_id] [uniqueidentifier] NOT NULL,
	[balance] [decimal](6, 2) NOT NULL,
	[date] [date] NOT NULL,
 CONSTRAINT [PK_CustomersBalance] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CustomersBalance] ADD  DEFAULT (newid()) FOR [customer_id]
GO

ALTER TABLE [dbo].[CustomersBalance]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customers] ([customer_id])
GO

ALTER TABLE [dbo].[CustomersBalance]  WITH CHECK ADD CHECK  (([balance]<(0)))
GO


