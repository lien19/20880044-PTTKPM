USE [master]
GO
/****** Object:  Database [e-Metro]    Script Date: 11/15/2021 20:33:32 ******/
CREATE DATABASE [e-Metro] ON  PRIMARY 
( NAME = N'e-Metro', FILENAME = N'D:\IT\HK1-Nhap mon lap trinh\repos\e-Metro.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'e-Metro_log', FILENAME = N'D:\IT\HK1-Nhap mon lap trinh\repos\e-Metro_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [e-Metro] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [e-Metro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [e-Metro] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [e-Metro] SET ANSI_NULLS OFF
GO
ALTER DATABASE [e-Metro] SET ANSI_PADDING OFF
GO
ALTER DATABASE [e-Metro] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [e-Metro] SET ARITHABORT OFF
GO
ALTER DATABASE [e-Metro] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [e-Metro] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [e-Metro] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [e-Metro] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [e-Metro] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [e-Metro] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [e-Metro] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [e-Metro] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [e-Metro] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [e-Metro] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [e-Metro] SET  DISABLE_BROKER
GO
ALTER DATABASE [e-Metro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [e-Metro] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [e-Metro] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [e-Metro] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [e-Metro] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [e-Metro] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [e-Metro] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [e-Metro] SET  READ_WRITE
GO
ALTER DATABASE [e-Metro] SET RECOVERY SIMPLE
GO
ALTER DATABASE [e-Metro] SET  MULTI_USER
GO
ALTER DATABASE [e-Metro] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [e-Metro] SET DB_CHAINING OFF
GO
USE [e-Metro]
GO
/****** Object:  Table [dbo].[Ga]    Script Date: 11/15/2021 20:33:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ga](
	[Id] [int] NOT NULL,
	[MaSoGa] [nchar](50) NOT NULL,
	[TenGa] [nchar](50) NULL,
	[ViTri] [nchar](50) NULL,
	[TinhTrangHoatDong] [nvarchar](50) NOT NULL,
	[BanDo] [nchar](50) NULL,
 CONSTRAINT [PK_Ga] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Ga] ([Id], [MaSoGa], [TenGa], [ViTri], [TinhTrangHoatDong], [BanDo]) VALUES (1, N'1                                                 ', N'a                                                 ', N'a                                                 ', N'Binh thuong', N'a                                                 ')
INSERT [dbo].[Ga] ([Id], [MaSoGa], [TenGa], [ViTri], [TinhTrangHoatDong], [BanDo]) VALUES (2, N'2                                                 ', N'a                                                 ', N'a                                                 ', N'Binh thuong', N'a                                                 ')
INSERT [dbo].[Ga] ([Id], [MaSoGa], [TenGa], [ViTri], [TinhTrangHoatDong], [BanDo]) VALUES (3, N'3                                                 ', N'b                                                 ', N'b                                                 ', N'Binh thuong', N'b                                                 ')
/****** Object:  Table [dbo].[CongTyTauDienNgam]    Script Date: 11/15/2021 20:33:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongTyTauDienNgam](
	[Id] [int] NOT NULL,
	[MaSoCongTyTDN] [nchar](50) NOT NULL,
	[TenCongTyTDN] [nchar](50) NULL,
	[DiaChiCongTyTDN] [nchar](50) NULL,
	[Website] [nchar](50) NULL,
	[SoDienThoai] [nchar](50) NULL,
 CONSTRAINT [PK_CongTyTauDienNgam_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (1, N'aaaa                                              ', N'kkkkk1                                            ', N'ffff                                              ', N'wwww1                                             ', N'eeee                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (2, N'bbbb                                              ', N'mmmm                                              ', N'pppp                                              ', N'nnnn                                              ', N'uuuu                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (3, N'dd                                                ', N'ggg                                               ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (5, N'222                                               ', N'ggg                                               ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (6, N'                                                  ', N'                                                  ', N'                                                  ', N'                                                  ', N'                                                  ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (7, N'3                                                 ', N'ggg                                               ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (9, N'4                                                 ', N'ggg1                                              ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (10, N'10                                                ', N'ggg                                               ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (11, N'11                                                ', N'ggg                                               ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (12, N'12                                                ', N'ggg                                               ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (14, N'14                                                ', N'ggg                                               ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (15, N'15                                                ', N'ggg                                               ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (16, N'16                                                ', N'ggg                                               ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (17, N'17                                                ', N'ggg                                               ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (18, N'18                                                ', N'ggg                                               ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (19, N'19                                                ', N'a1                                                ', N'a                                                 ', N'a                                                 ', N'a                                                 ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (20, N'20                                                ', N'a                                                 ', N'a                                                 ', N'a                                                 ', N'a                                                 ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (21, N'21                                                ', N'a                                                 ', N'a                                                 ', N'a                                                 ', N'a                                                 ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (22, N'22                                                ', N'a                                                 ', N'a                                                 ', N'a                                                 ', N'a                                                 ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (23, N'23                                                ', N'23                                                ', N'nnn                                               ', N'web                                               ', N'666                                               ')
INSERT [dbo].[CongTyTauDienNgam] ([Id], [MaSoCongTyTDN], [TenCongTyTDN], [DiaChiCongTyTDN], [Website], [SoDienThoai]) VALUES (24, N'24                                                ', N'ggg                                               ', N'nnn                                               ', N'web                                               ', N'5555                                              ')
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 11/15/2021 20:33:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[Id] [int] NOT NULL,
	[Email] [nchar](50) NOT NULL,
	[Password] [nchar](50) NOT NULL,
	[PhanLoai] [nchar](50) NOT NULL,
	[ThoiGian] [datetime] NOT NULL,
	[CongTyTDNId] [int] NULL,
	[QuanTriHeThong] [int] NOT NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (1, N'lienpham19@gmail.com                              ', N'123                                               ', N'CongTyTDN                                         ', CAST(0x0000ADBD00000000 AS DateTime), 1, 1)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (2, N'lienpham19.003@gmail.com                          ', N'123                                               ', N'CongTyTDN                                         ', CAST(0x0000ADBD00000000 AS DateTime), 1, 0)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (3, N'lienpham.19@gmail.com                             ', N'123                                               ', N'CongTyTDN                                         ', CAST(0x0000ADBD00000000 AS DateTime), 3, 0)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (4, N'lien.pham19@gmail.com                             ', N'123                                               ', N'CongTyTDN                                         ', CAST(0x0000ADC1001239F0 AS DateTime), 5, 0)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (5, N'eef@dw                                            ', N'123                                               ', N'CongTyTDN                                         ', CAST(0x0000ADC1001A3142 AS DateTime), 9, 0)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (6, N'lienpham1.9@gmail.com                             ', N'123                                               ', N'CongTyTDN                                         ', CAST(0x0000ADC100000000 AS DateTime), 10, 0)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (7, N'lienpham19@gmail.com                              ', N'123                                               ', N'Admin                                             ', CAST(0x0000ADCF00196562 AS DateTime), 0, 0)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (8, N'lienpham19@gmail.com                              ', N'123                                               ', N'SoGiaoThong                                       ', CAST(0x0000ADCF001CDA82 AS DateTime), 0, 1)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (9, N'lienpham1.9@gmail.com                             ', N'                                                  ', N'Admin                                             ', CAST(0x0000ADCF00246DF5 AS DateTime), 0, 0)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (10, N'eef@dw000                                         ', N'123                                               ', N'SoGiaoThong                                       ', CAST(0x0000ADE100EE8247 AS DateTime), 0, 0)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (11, N'eef@dw0                                           ', N'123                                               ', N'SoGiaoThong                                       ', CAST(0x0000ADE100F8A644 AS DateTime), 0, 0)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (12, N'eef@dw00                                          ', N'123                                               ', N'SoGiaoThong                                       ', CAST(0x0000ADE100F973D7 AS DateTime), 0, 0)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (13, N'eef@dw0000                                        ', N'123                                               ', N'SoGiaoThong                                       ', CAST(0x0000ADE101451167 AS DateTime), 0, 0)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (14, N'eef@dw11                                          ', N'123                                               ', N'CongTyTDN                                         ', CAST(0x0000ADE10145728F AS DateTime), 0, 0)
INSERT [dbo].[NguoiDung] ([Id], [Email], [Password], [PhanLoai], [ThoiGian], [CongTyTDNId], [QuanTriHeThong]) VALUES (15, N'eef@dw2                                           ', N'123                                               ', N'SoGiaoThong                                       ', CAST(0x0000ADE10147F8A6 AS DateTime), 0, 0)
/****** Object:  Table [dbo].[TuyenTau]    Script Date: 11/15/2021 20:33:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TuyenTau](
	[Id] [int] NOT NULL,
	[MaSoTuyenTau] [nchar](50) NOT NULL,
	[TenTuyenTau] [nchar](50) NULL,
	[GiaVeHienHanh] [float] NOT NULL,
	[GioBatDau] [nchar](10) NULL,
	[GioKetThuc] [nchar](10) NULL,
	[ThoiGianCho2Chuyen] [float] NOT NULL,
	[TinhTrang] [nchar](50) NOT NULL,
	[GaBatDauId] [int] NOT NULL,
	[GaKetThucId] [int] NOT NULL,
	[CongTyTDNId] [int] NOT NULL,
 CONSTRAINT [PK_TuyenTau] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TuyenTau] ([Id], [MaSoTuyenTau], [TenTuyenTau], [GiaVeHienHanh], [GioBatDau], [GioKetThuc], [ThoiGianCho2Chuyen], [TinhTrang], [GaBatDauId], [GaKetThucId], [CongTyTDNId]) VALUES (1, N'1                                                 ', N'a                                                 ', 0, N'20:30     ', N'21:30     ', 0, N'a                                                 ', 1, 1, 1)
INSERT [dbo].[TuyenTau] ([Id], [MaSoTuyenTau], [TenTuyenTau], [GiaVeHienHanh], [GioBatDau], [GioKetThuc], [ThoiGianCho2Chuyen], [TinhTrang], [GaBatDauId], [GaKetThucId], [CongTyTDNId]) VALUES (2, N'2                                                 ', N'2                                                 ', 2, N'2         ', N'2         ', 2, N'2                                                 ', 2, 2, 1)
INSERT [dbo].[TuyenTau] ([Id], [MaSoTuyenTau], [TenTuyenTau], [GiaVeHienHanh], [GioBatDau], [GioKetThuc], [ThoiGianCho2Chuyen], [TinhTrang], [GaBatDauId], [GaKetThucId], [CongTyTDNId]) VALUES (3, N'3                                                 ', N'3                                                 ', 3, N'3         ', N'3         ', 3, N'3                                                 ', 1, 2, 2)
INSERT [dbo].[TuyenTau] ([Id], [MaSoTuyenTau], [TenTuyenTau], [GiaVeHienHanh], [GioBatDau], [GioKetThuc], [ThoiGianCho2Chuyen], [TinhTrang], [GaBatDauId], [GaKetThucId], [CongTyTDNId]) VALUES (4, N'4                                                 ', N'4                                                 ', 4, N'4         ', N'4         ', 4, N'4                                                 ', 3, 2, 1)
INSERT [dbo].[TuyenTau] ([Id], [MaSoTuyenTau], [TenTuyenTau], [GiaVeHienHanh], [GioBatDau], [GioKetThuc], [ThoiGianCho2Chuyen], [TinhTrang], [GaBatDauId], [GaKetThucId], [CongTyTDNId]) VALUES (5, N'5                                                 ', N'5                                                 ', 5, N'5         ', N'5         ', 5, N'5                                                 ', 2, 3, 1)
/****** Object:  Table [dbo].[Ve]    Script Date: 11/15/2021 20:33:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ve](
	[Id] [int] NOT NULL,
	[MaSoVe] [nchar](10) NOT NULL,
	[Gia] [float] NOT NULL,
	[NgayBanVe] [datetime] NOT NULL,
	[TuyenTauId] [int] NOT NULL,
	[CongTyTDNId] [int] NOT NULL,
 CONSTRAINT [PK_Ve_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Ve] ([Id], [MaSoVe], [Gia], [NgayBanVe], [TuyenTauId], [CongTyTDNId]) VALUES (1, N'1         ', 6, CAST(0x0000ACA300000000 AS DateTime), 1, 1)
INSERT [dbo].[Ve] ([Id], [MaSoVe], [Gia], [NgayBanVe], [TuyenTauId], [CongTyTDNId]) VALUES (2, N'2         ', 2, CAST(0x0000ACB100000000 AS DateTime), 1, 1)
INSERT [dbo].[Ve] ([Id], [MaSoVe], [Gia], [NgayBanVe], [TuyenTauId], [CongTyTDNId]) VALUES (3, N'3         ', 3, CAST(0x0000ACA300000000 AS DateTime), 2, 1)
INSERT [dbo].[Ve] ([Id], [MaSoVe], [Gia], [NgayBanVe], [TuyenTauId], [CongTyTDNId]) VALUES (4, N'4         ', 4, CAST(0x0000ACA300000000 AS DateTime), 3, 3)
INSERT [dbo].[Ve] ([Id], [MaSoVe], [Gia], [NgayBanVe], [TuyenTauId], [CongTyTDNId]) VALUES (5, N'5         ', 0, CAST(0x0000ACA300000000 AS DateTime), 4, 1)
INSERT [dbo].[Ve] ([Id], [MaSoVe], [Gia], [NgayBanVe], [TuyenTauId], [CongTyTDNId]) VALUES (6, N'6         ', 6, CAST(0x0000AB3500000000 AS DateTime), 4, 1)
/****** Object:  Table [dbo].[TuyenTau_GaTrungGian]    Script Date: 11/15/2021 20:33:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TuyenTau_GaTrungGian](
	[Id] [int] NOT NULL,
	[TuyenTauId] [int] NOT NULL,
	[GaId] [int] NOT NULL,
	[ThoiGianDung] [int] NOT NULL,
 CONSTRAINT [PK_TuyenTau_GaTrungGian_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TuyenTau_GaTrungGian] ([Id], [TuyenTauId], [GaId], [ThoiGianDung]) VALUES (2, 2, 1, 1)
INSERT [dbo].[TuyenTau_GaTrungGian] ([Id], [TuyenTauId], [GaId], [ThoiGianDung]) VALUES (3, 3, 2, 1)
INSERT [dbo].[TuyenTau_GaTrungGian] ([Id], [TuyenTauId], [GaId], [ThoiGianDung]) VALUES (4, 2, 2, 15)
INSERT [dbo].[TuyenTau_GaTrungGian] ([Id], [TuyenTauId], [GaId], [ThoiGianDung]) VALUES (5, 5, 2, 0)
INSERT [dbo].[TuyenTau_GaTrungGian] ([Id], [TuyenTauId], [GaId], [ThoiGianDung]) VALUES (6, 4, 2, 10)
/****** Object:  Table [dbo].[VeThuong]    Script Date: 11/15/2021 20:33:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VeThuong](
	[Id] [int] NOT NULL,
	[VeId] [int] NOT NULL,
	[TrangThaiSuDung] [nchar](50) NOT NULL,
	[ThoiDiemSuDung] [datetime] NOT NULL,
 CONSTRAINT [PK_VeThuong_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[VeThuong] ([Id], [VeId], [TrangThaiSuDung], [ThoiDiemSuDung]) VALUES (1, 4, N'22                                                ', CAST(0x0000AF7B00000000 AS DateTime))
INSERT [dbo].[VeThuong] ([Id], [VeId], [TrangThaiSuDung], [ThoiDiemSuDung]) VALUES (2, 2, N'Đã bán                                            ', CAST(0x0000ACD600000000 AS DateTime))
INSERT [dbo].[VeThuong] ([Id], [VeId], [TrangThaiSuDung], [ThoiDiemSuDung]) VALUES (3, 3, N'Đã bán                                            ', CAST(0x0000AE1000000000 AS DateTime))
/****** Object:  Table [dbo].[VeThang]    Script Date: 11/15/2021 20:33:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VeThang](
	[Id] [int] NOT NULL,
	[VeId] [int] NOT NULL,
	[NgayHetHan] [datetime] NOT NULL,
 CONSTRAINT [PK_VeThang_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[VeThang] ([Id], [VeId], [NgayHetHan]) VALUES (1, 1, CAST(0x0000ACD600000000 AS DateTime))
INSERT [dbo].[VeThang] ([Id], [VeId], [NgayHetHan]) VALUES (2, 5, CAST(0x0000ACC100000000 AS DateTime))
INSERT [dbo].[VeThang] ([Id], [VeId], [NgayHetHan]) VALUES (3, 6, CAST(0x0000AB5300000000 AS DateTime))
/****** Object:  Table [dbo].[LichSuSuDung]    Script Date: 11/15/2021 20:33:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuSuDung](
	[Id] [int] NOT NULL,
	[VeThangId] [int] NOT NULL,
	[NgaySuDung] [datetime] NOT NULL,
 CONSTRAINT [PK_LichSuSuDung] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[LichSuSuDung] ([Id], [VeThangId], [NgaySuDung]) VALUES (1, 1, CAST(0x0000ACB600000000 AS DateTime))
/****** Object:  ForeignKey [FK_TuyenTau_CongTyTauDienNgam]    Script Date: 11/15/2021 20:33:34 ******/
ALTER TABLE [dbo].[TuyenTau]  WITH CHECK ADD  CONSTRAINT [FK_TuyenTau_CongTyTauDienNgam] FOREIGN KEY([CongTyTDNId])
REFERENCES [dbo].[CongTyTauDienNgam] ([Id])
GO
ALTER TABLE [dbo].[TuyenTau] CHECK CONSTRAINT [FK_TuyenTau_CongTyTauDienNgam]
GO
/****** Object:  ForeignKey [FK_TuyenTau_Ga]    Script Date: 11/15/2021 20:33:34 ******/
ALTER TABLE [dbo].[TuyenTau]  WITH CHECK ADD  CONSTRAINT [FK_TuyenTau_Ga] FOREIGN KEY([GaBatDauId])
REFERENCES [dbo].[Ga] ([Id])
GO
ALTER TABLE [dbo].[TuyenTau] CHECK CONSTRAINT [FK_TuyenTau_Ga]
GO
/****** Object:  ForeignKey [FK_TuyenTau_Ga1]    Script Date: 11/15/2021 20:33:34 ******/
ALTER TABLE [dbo].[TuyenTau]  WITH CHECK ADD  CONSTRAINT [FK_TuyenTau_Ga1] FOREIGN KEY([GaKetThucId])
REFERENCES [dbo].[Ga] ([Id])
GO
ALTER TABLE [dbo].[TuyenTau] CHECK CONSTRAINT [FK_TuyenTau_Ga1]
GO
/****** Object:  ForeignKey [FK_Ve_CongTyTauDienNgam]    Script Date: 11/15/2021 20:33:34 ******/
ALTER TABLE [dbo].[Ve]  WITH CHECK ADD  CONSTRAINT [FK_Ve_CongTyTauDienNgam] FOREIGN KEY([CongTyTDNId])
REFERENCES [dbo].[CongTyTauDienNgam] ([Id])
GO
ALTER TABLE [dbo].[Ve] CHECK CONSTRAINT [FK_Ve_CongTyTauDienNgam]
GO
/****** Object:  ForeignKey [FK_Ve_TuyenTau]    Script Date: 11/15/2021 20:33:34 ******/
ALTER TABLE [dbo].[Ve]  WITH CHECK ADD  CONSTRAINT [FK_Ve_TuyenTau] FOREIGN KEY([TuyenTauId])
REFERENCES [dbo].[TuyenTau] ([Id])
GO
ALTER TABLE [dbo].[Ve] CHECK CONSTRAINT [FK_Ve_TuyenTau]
GO
/****** Object:  ForeignKey [FK_TuyenTau_GaTrungGian_Ga]    Script Date: 11/15/2021 20:33:34 ******/
ALTER TABLE [dbo].[TuyenTau_GaTrungGian]  WITH CHECK ADD  CONSTRAINT [FK_TuyenTau_GaTrungGian_Ga] FOREIGN KEY([GaId])
REFERENCES [dbo].[Ga] ([Id])
GO
ALTER TABLE [dbo].[TuyenTau_GaTrungGian] CHECK CONSTRAINT [FK_TuyenTau_GaTrungGian_Ga]
GO
/****** Object:  ForeignKey [FK_TuyenTau_GaTrungGian_TuyenTau]    Script Date: 11/15/2021 20:33:34 ******/
ALTER TABLE [dbo].[TuyenTau_GaTrungGian]  WITH CHECK ADD  CONSTRAINT [FK_TuyenTau_GaTrungGian_TuyenTau] FOREIGN KEY([TuyenTauId])
REFERENCES [dbo].[TuyenTau] ([Id])
GO
ALTER TABLE [dbo].[TuyenTau_GaTrungGian] CHECK CONSTRAINT [FK_TuyenTau_GaTrungGian_TuyenTau]
GO
/****** Object:  ForeignKey [FK_VeThuong_Ve]    Script Date: 11/15/2021 20:33:34 ******/
ALTER TABLE [dbo].[VeThuong]  WITH CHECK ADD  CONSTRAINT [FK_VeThuong_Ve] FOREIGN KEY([VeId])
REFERENCES [dbo].[Ve] ([Id])
GO
ALTER TABLE [dbo].[VeThuong] CHECK CONSTRAINT [FK_VeThuong_Ve]
GO
/****** Object:  ForeignKey [FK_VeThang_Ve]    Script Date: 11/15/2021 20:33:34 ******/
ALTER TABLE [dbo].[VeThang]  WITH CHECK ADD  CONSTRAINT [FK_VeThang_Ve] FOREIGN KEY([VeId])
REFERENCES [dbo].[Ve] ([Id])
GO
ALTER TABLE [dbo].[VeThang] CHECK CONSTRAINT [FK_VeThang_Ve]
GO
/****** Object:  ForeignKey [FK_LichSuSuDung_VeThang]    Script Date: 11/15/2021 20:33:34 ******/
ALTER TABLE [dbo].[LichSuSuDung]  WITH CHECK ADD  CONSTRAINT [FK_LichSuSuDung_VeThang] FOREIGN KEY([VeThangId])
REFERENCES [dbo].[VeThang] ([Id])
GO
ALTER TABLE [dbo].[LichSuSuDung] CHECK CONSTRAINT [FK_LichSuSuDung_VeThang]
GO
