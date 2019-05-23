/****** To insert Vietnames:  ******/
/****** 1. make sure script in Unicode-16 ******/
/****** 2. Put N before Vietnames text ******/
/******    Example: N'Nguyễn Công Hoan' ******/

USE [master]
GO

WHILE EXISTS(select NULL from sys.databases where name='QLDL')
BEGIN
    DECLARE @SQL varchar(max)
    SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
    FROM MASTER..SysProcesses
    WHERE DBId = DB_ID(N'QLDL') AND SPId <> @@SPId
    EXEC(@SQL)
    DROP DATABASE [QLDL]
END
GO

/* Collation = SQL_Latin1_General_CP1_CI_AS */
CREATE DATABASE [QLDL]
GO
USE [QLDL]
GO
CREATE TABLE [dbo].[tblMatHang]
(
	[maMatHang] int NOT NULL PRIMARY KEY,
	[soluong]	int NOT NULL,
	[khoiluong] int NOT NULL,
	[hanSuDung] datetime NOT NULL,
	[gia]		int NOT NULL,
	[donViTinh] nvarchar(50)
)
CREATE TABLE [dbo].[tblHoSoDaiLy]
(
	[maDaiLy]	int NOT NULL PRIMARY KEY,
	[tenDaiLy]	nvarchar(50) NOT NULL,
	[diachi]	nvarchar(50) NOT NULL,
	[email]		nvarchar(30),
	[loaiDaiLy]	int	NOT NULL,
	[ngayTiepNhan]	datetime NOT NULL,
	[quan]		nvarchar(20) NOT NULL,
	[dienthoai]	int NOT NULL
)
CREATE TABLE [dbo].[tblDanhSachDaiLy]
(
	[STT]	int NOT NULL,
	[maDaiLy] int NOT NULL PRIMARY KEY,
	[loai]	int NOT NULL,
	[quan]	int NOT NULL,
	[tienno]	int NOT NULL
)
CREATE TABLE [dbo].[tblPhieuThuTien]
(
	[maPhieu]	int	NOT NULL PRIMARY KEY,
	[maDaiLy]	int NOT NULL,
	[tenDaiLy]	nvarchar(50) NOT NULL,
	[diachi]	nvarchar(50) NOT NULL,
	[email]		nvarchar(30),
	[dienthoai]	int NOT NULL,
	[ngayThuTien] datetime NOT NULL,
	[soTienThu] int NOT NULL,
)
CREATE TABLE [dbo].[tblPhieuXuatHang]
(
	[maXuatHang]	int NOT NULL PRIMARY KEY,
	[maDaiLy]		int NOT NULL,
	[ngayLapPhieu]	datetime NOT NULL,
	[thanhtien]		int NOT NULL
)
CREATE TABLE [dbo].[tblChiTietPhieuXH]
(
	[maXuatHang] int NOT NULL PRIMARY KEY,
	[maMatHang] int NOT NULL,
	[soluong]	int NOT NULL,
	[donViTinh]	nvarchar(50) NOT NULL,
	[dongia] int NOT NULL
)

CREATE TABLE [dbo].[tblLoaiDaiLy]
(
	[maLoaiDaiLy] int NOT NULL PRIMARY KEY,
	[tenLoaiDaiLy]	int NOT NULL
)
USE [QLDL]
GO
ALTER TABLE [dbo].[tblHoSoDaiLy]
ADD CONSTRAINT FK_LOAIDL FOREIGN KEY (loaiDaiLy) REFERENCES [dbo].[tblLoaiDaiLy](maLoaiDaiLy)
GO
ALTER TABLE [dbo].[tblDanhSachDaiLy]
ADD CONSTRAINT FK_MADL FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblHoSoDaiLy](maDaiLy)
GO
ALTER TABLE [dbo].[tblPhieuThuTien]
ADD CONSTRAINT FK_MADL_PTT FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblHoSoDaiLy](maDaiLy)
GO
ALTER TABLE [dbo].[tblPhieuXuatHang]
ADD CONSTRAINT FK_MADL_PXH FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblHoSoDaiLy](maDaiLy)
GO
ALTER TABLE [dbo].[tblChiTietPhieuXH]
ADD CONSTRAINT FK_MAXH FOREIGN KEY (maXuatHang) REFERENCES [dbo].[tblPhieuXuatHang](maXuatHang)
