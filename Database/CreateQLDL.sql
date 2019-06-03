/****** To insert Vietnames:  ******/
/****** 1. make sure script in Unicode-16 ******/
/****** 2. Put N before Vietnames text ******/
/******    Example: N'Nguy?n Công Hoan' ******/

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
	[tenmathang] nvarchar(50) NOT NULL,
	[hanSuDung] datetime2(7) NOT NULL,
	[gia]		int NOT NULL,
	[donViTinh] nvarchar(50)
)
CREATE TABLE [dbo].[tblDaiLy]
(
	[maDaiLy]	int NOT NULL PRIMARY KEY,
	[tenDaiLy]	nvarchar(50) NOT NULL,
	[diachi]	nvarchar(50) NOT NULL,
	[email]		nvarchar(30),
	[loaiDaiLy]	int	NOT NULL,
	[dientich] int NOT NULL,
	[sonhanvien] int NOT NULL,
	[ngayTiepNhan]	datetime2(7) NOT NULL,
	[quan]		nvarchar(20) NOT NULL,
	[dienthoai]	int NOT NULL,
	[nohientai] int
)
CREATE TABLE [dbo].[tblPhieuThuTien]
(
	[maPhieu]	int	NOT NULL PRIMARY KEY,
	[maDaiLy]	int NOT NULL,
	[ngayThuTien] datetime2(7) NOT NULL,
	[soTienThu] int NOT NULL,
)
CREATE TABLE [dbo].[tblPhieuXuatHang]
(
	[maXuatHang]	int NOT NULL PRIMARY KEY,
	[maDaiLy]		int NOT NULL,
	[ngayLapPhieu]	datetime2(7) NOT NULL
)
CREATE TABLE [dbo].[tblChiTietPhieuXH]
(
	[maXuatHang] int NOT NULL PRIMARY KEY,
	[maMatHang] int NOT NULL,
	[soluong]	int NOT NULL,
	[donViTinh]	nvarchar(50) NOT NULL,
	[dongia] int NOT NULL,
	[thanhtien] int NOT NULL
)
CREATE TABLE [dbo].[tblLoaiDaiLy]
(
	[maLoaiDaiLy] int NOT NULL PRIMARY KEY,
	[tenLoaiDaiLy]	nvarchar(30) NOT NULL,
	[notoida]	int NOT NULL
)
CREATE TABLE [dbo].[tblNoDaiLy]
(
	[maDaiLy]	int NOT NULL PRIMARY KEY,
	[nodau]		int,
	[nocuoi]	int,
	[phatsinh]	int
)
CREATE TABLE [dbo].[PhieuBaoCaoCongNo]
{
	[maPhieuBaoCao] int NOT NULL PRIMARY KEY,
	[thang] datetime
}
CREATE TABLE [dbo].[tblDoanhThuDaiLy]
(
	[maBaoCao]	int NOT NULL PRIMARY KEY,
	[maDaiLy]	int NOT NULL,
	[sophieuxuat]	int NOT NULL,
	[tongtrigia]	int NOT NULL,
	[tyle]			float NOT NULL,
	[thang]		datetime NOT NULL
)
CREATE TABLE [dbo].[tblQuyDinh]
(
	[MaxLoaiDaiLy] int,
	[MaxTrongQuan] int,
	[SoluongMH] int,
	[SoluongDVT] int
)
USE [QLDL]
GO
ALTER TABLE [dbo].[tblDaiLy]
ADD CONSTRAINT FK_LOAIDL FOREIGN KEY (loaiDaiLy) REFERENCES [dbo].[tblLoaiDaiLy](maLoaiDaiLy)
GO
ALTER TABLE [dbo].[tblNoDaiLy]
ADD CONSTRAINT FK_MADL_NDL FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblDaiLy](maDaiLy)
GO
ALTER TABLE [dbo].[tblDoanhThuDaiLy]
ADD CONSTRAINT FK_MADL_DTDL FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblDaiLy](maDaiLy)
GO
ALTER TABLE [dbo].[tblPhieuThuTien]
ADD CONSTRAINT FK_MADL_PTT FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblDaiLy](maDaiLy)
GO
ALTER TABLE [dbo].[tblPhieuXuatHang]
ADD CONSTRAINT FK_MADL_PXH FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblDaiLy](maDaiLy)
GO
ALTER TABLE [dbo].[tblChiTietPhieuXH]
ADD CONSTRAINT FK_MAXH FOREIGN KEY (maXuatHang) REFERENCES [dbo].[tblPhieuXuatHang](maXuatHang)
GO
ALTER TABLE [dbo].[tblChiTietPhieuXH]
ADD CONSTRAINT FK_MAMH FOREIGN KEY (maMatHang) REFERENCES [dbo].[tblMatHang] (maMatHang)

SET DATEFORMAT DMY 
GO
GO
INSERT INTO [dbo].[tblLoaiDaiLy] VALUES ('1','Loai Dai Ly 1','30000000')
GO
INSERT INTO [dbo].[tblLoaiDaiLy] VALUES ('2','Loai Dai Ly 2','40000000')
GO
INSERT INTO [dbo].[tblLoaiDaiLy] VALUES ('3','Loai Dai Ly 3','65000000')
GO
INSERT INTO [dbo].[tblDaiLy] ([maDaiLy], [tenDaiLy], [diachi],[email], [loaiDaiLy], [dientich],[sonhanvien], [ngayTiepNhan],[quan], [dienthoai],[nohientai]) 
VALUES ('1','Dai Ly A','Dia Chi Dai Ly A','DLA@email.com','1','120','5','20/03/1999','12','0909111222','10000000')
GO
INSERT INTO [dbo].[tblDaiLy] VALUES ('2','Dai Ly B','Dia Chi Dai Ly B','DLB@email.com','2','150','10','30/04/1975','9','0909222333','15000000')
GO
INSERT INTO [dbo].[tblDaiLy] VALUES ('3','Dai Ly C','Dia Chi Dai Ly C','DLC@email.com','3','132','9','19/05/1890','9','0930041975','25000000')
GO