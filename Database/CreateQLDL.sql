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
	[soluong]	int NOT NULL,
	[tenmathang] nvarchar(50) NOT NULL,
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
	[quan]	nvarchar(15) NOT NULL,
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
	[tenLoaiDaiLy]	nvarchar(30) NOT NULL
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

GO
INSERT INTO [dbo].[tblLoaiDaiLy] VALUES ('1','Loai Dai Ly 1')
GO
INSERT INTO [dbo].[tblLoaiDaiLy] VALUES ('2','Loai Dai Ly 2')
GO
INSERT INTO [dbo].[tblLoaiDaiLy] VALUES ('3','Loai Dai Ly 3')
GO
INSERT INTO [dbo].[tblHoSoDaiLy] ([maDaiLy], [tenDaiLy], [diachi],[email], [loaiDaiLy], [ngayTiepNhan], [quan], [dienthoai]) 
VALUES ('1','Dai Ly A','Dia Chi Dai Ly A','DLA@email.com','1','20/03/1999','12','0909111222')
GO
INSERT INTO [dbo].[tblHoSoDaiLy] VALUES ('2','Dai Ly B','Dia Chi Dai Ly B','DLB@email.com','2','30/04/1975','9','0909222333')
GO
INSERT INTO [dbo].[tblHoSoDaiLy] VALUES ('3','Dai Ly C','Dia Chi Dai Ly C','DLC@email.com','3','19/05/1890','9','0930041975')
UPDATE tblHoSoDaiLy SET [tenDaiLy] = 'test', [diachi] = 'test', [email] = 'test', [loaiDaiLy] = '1', [quan] = '2', [dienthoai] = '123', [dientich] = '30', [sonhanvien] = '7' WHERE [maDaiLy] = '9'
DELETE FROM tblHoSoDaiLy WHERE [maDaiLy] = '1'