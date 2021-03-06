USE [BDPRUEBA]
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 24/04/2017 6:16:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Banco](
	[idBanco] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
	[Descripcion] [varchar](350) NULL,
	[FechaRegistro] [datetime] NOT NULL CONSTRAINT [DF_Banco_FechaRegistro]  DEFAULT (getdate()),
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[idBanco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenPago]    Script Date: 24/04/2017 6:16:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrdenPago](
	[idOrdenPago] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[Moneda] [char](1) NOT NULL,
	[FechaPago] [datetime] NOT NULL CONSTRAINT [DF_OrdenPago_FechaPago]  DEFAULT (getdate()),
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_OrdenPago] PRIMARY KEY CLUSTERED 
(
	[idOrdenPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 24/04/2017 6:16:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursal](
	[idSucursal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
	[Direccion] [varchar](350) NULL,
	[FechaRegistro] [datetime] NOT NULL CONSTRAINT [DF_Sucursal_FechaRegistro]  DEFAULT (getdate()),
	[idBanco] [int] NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[idSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sucursal_OrdenPago]    Script Date: 24/04/2017 6:16:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal_OrdenPago](
	[idSucursal] [int] NULL,
	[idOrdenPago] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Banco] ON 

INSERT [dbo].[Banco] ([idBanco], [Nombre], [Descripcion], [FechaRegistro]) VALUES (1, N'aaa', N'bbbb', CAST(N'2017-04-22 15:26:38.100' AS DateTime))
INSERT [dbo].[Banco] ([idBanco], [Nombre], [Descripcion], [FechaRegistro]) VALUES (2, N'banco2', N'descripcion2', CAST(N'2017-04-22 15:26:38.100' AS DateTime))
INSERT [dbo].[Banco] ([idBanco], [Nombre], [Descripcion], [FechaRegistro]) VALUES (3, N'banco 3', N'descripcion 3', CAST(N'2017-04-22 15:26:38.100' AS DateTime))
INSERT [dbo].[Banco] ([idBanco], [Nombre], [Descripcion], [FechaRegistro]) VALUES (4, N'banco 4', N'descripcion 4', CAST(N'2017-04-22 15:26:38.100' AS DateTime))
INSERT [dbo].[Banco] ([idBanco], [Nombre], [Descripcion], [FechaRegistro]) VALUES (5, N'banco 6', N'descripcion 65', CAST(N'2017-04-22 15:26:38.100' AS DateTime))
SET IDENTITY_INSERT [dbo].[Banco] OFF
SET IDENTITY_INSERT [dbo].[OrdenPago] ON 

INSERT [dbo].[OrdenPago] ([idOrdenPago], [Monto], [Moneda], [FechaPago], [Estado]) VALUES (1, CAST(2000.00 AS Decimal(18, 2)), N'd', CAST(N'2017-04-22 21:10:46.587' AS DateTime), N'p')
INSERT [dbo].[OrdenPago] ([idOrdenPago], [Monto], [Moneda], [FechaPago], [Estado]) VALUES (2, CAST(2000.00 AS Decimal(18, 2)), N's', CAST(N'2017-04-22 21:11:29.123' AS DateTime), N'p')
INSERT [dbo].[OrdenPago] ([idOrdenPago], [Monto], [Moneda], [FechaPago], [Estado]) VALUES (3, CAST(888.00 AS Decimal(18, 2)), N's', CAST(N'2017-04-22 21:15:58.710' AS DateTime), N'f')
INSERT [dbo].[OrdenPago] ([idOrdenPago], [Monto], [Moneda], [FechaPago], [Estado]) VALUES (5, CAST(600.00 AS Decimal(18, 2)), N's', CAST(N'2017-04-22 21:21:59.417' AS DateTime), N'f')
INSERT [dbo].[OrdenPago] ([idOrdenPago], [Monto], [Moneda], [FechaPago], [Estado]) VALUES (6, CAST(999.00 AS Decimal(18, 2)), N's', CAST(N'2017-04-22 21:22:09.480' AS DateTime), N'd')
SET IDENTITY_INSERT [dbo].[OrdenPago] OFF
SET IDENTITY_INSERT [dbo].[Sucursal] ON 

INSERT [dbo].[Sucursal] ([idSucursal], [Nombre], [Direccion], [FechaRegistro], [idBanco]) VALUES (1, N'sucursal1', N'dessucursal1', CAST(N'2017-04-22 16:02:05.093' AS DateTime), 2)
INSERT [dbo].[Sucursal] ([idSucursal], [Nombre], [Direccion], [FechaRegistro], [idBanco]) VALUES (5, N'ffffffffffffffffff', N'fdfvdf', CAST(N'2017-04-22 17:25:58.210' AS DateTime), 5)
SET IDENTITY_INSERT [dbo].[Sucursal] OFF
INSERT [dbo].[Sucursal_OrdenPago] ([idSucursal], [idOrdenPago]) VALUES (5, NULL)
INSERT [dbo].[Sucursal_OrdenPago] ([idSucursal], [idOrdenPago]) VALUES (5, 1)
INSERT [dbo].[Sucursal_OrdenPago] ([idSucursal], [idOrdenPago]) VALUES (5, 2)
INSERT [dbo].[Sucursal_OrdenPago] ([idSucursal], [idOrdenPago]) VALUES (5, 3)
INSERT [dbo].[Sucursal_OrdenPago] ([idSucursal], [idOrdenPago]) VALUES (1, 5)
INSERT [dbo].[Sucursal_OrdenPago] ([idSucursal], [idOrdenPago]) VALUES (1, 6)
ALTER TABLE [dbo].[Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_Banco] FOREIGN KEY([idBanco])
REFERENCES [dbo].[Banco] ([idBanco])
GO
ALTER TABLE [dbo].[Sucursal] CHECK CONSTRAINT [FK_Sucursal_Banco]
GO
ALTER TABLE [dbo].[Sucursal_OrdenPago]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_OrdenPago_OrdenPago] FOREIGN KEY([idOrdenPago])
REFERENCES [dbo].[OrdenPago] ([idOrdenPago])
GO
ALTER TABLE [dbo].[Sucursal_OrdenPago] CHECK CONSTRAINT [FK_Sucursal_OrdenPago_OrdenPago]
GO
ALTER TABLE [dbo].[Sucursal_OrdenPago]  WITH CHECK ADD  CONSTRAINT [FK_Sucursal_OrdenPago_Sucursal] FOREIGN KEY([idSucursal])
REFERENCES [dbo].[Sucursal] ([idSucursal])
GO
ALTER TABLE [dbo].[Sucursal_OrdenPago] CHECK CONSTRAINT [FK_Sucursal_OrdenPago_Sucursal]
GO
