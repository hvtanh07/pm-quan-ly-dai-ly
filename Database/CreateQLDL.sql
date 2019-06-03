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
<<<<<<< HEAD
(
	[maMatHang] int NOT NULL PRIMARY KEY,
	[soluong]	int NOT NULL,
	[tenmathang] nvarchar(50) NOT NULL,
	[khoiluong] int NOT NULL,
=======
<<<<<<< HEAD
(
	[maMatHang] int NOT NULL PRIMARY KEY,
	[tenmathang] nvarchar(50) NOT NULL,
=======
(	
	[tenmathang] nvarchar(50) NOT NULL PRIMARY KEY,		
>>>>>>> 2c1cf5c3b667b69b5ed958f77697579c5513afae
>>>>>>> parent of a4faa10... Revert "Update CreateQLDL.sql"
	[hanSuDung] datetime2(7) NOT NULL,
	[gia]		int NOT NULL,
	[donViTinh] nvarchar(50)
)
<<<<<<< HEAD
CREATE TABLE [dbo].[tblDaiLy]
(
	[maDaiLy]	int NOT NULL PRIMARY KEY,
	[tenDaiLy]	nvarchar(50) NOT NULL,
=======
CREATE TABLE [dbo].[tblHoSoDaiLy]
<<<<<<< HEAD
(
	[maDaiLy]	int NOT NULL PRIMARY KEY,
	[tenDaiLy]	nvarchar(50) NOT NULL,
=======
(	
	[tenDaiLy]	nvarchar(50) NOT NULL PRIMARY KEY,
>>>>>>> 2c1cf5c3b667b69b5ed958f77697579c5513afae
>>>>>>> parent of a4faa10... Revert "Update CreateQLDL.sql"
	[diachi]	nvarchar(50) NOT NULL,
	[email]		nvarchar(30),
	[loaiDaiLy]	int	NOT NULL,
	[dientich] int NOT NULL,
	[sonhanvien] int NOT NULL,
	[ngayTiepNhan]	datetime2(7) NOT NULL,
	[quan]		nvarchar(20) NOT NULL,
<<<<<<< HEAD
	[dienthoai]	int NOT NULL
)
CREATE TABLE [dbo].[tblDanhSachDaiLy]
(
	[maDaiLy] int NOT NULL PRIMARY KEY,
	[loai]	int NOT NULL,
	[quan]	nvarchar(15) NOT NULL,
	[tienno]	int NOT NULL
=======
<<<<<<< HEAD
	[dienthoai]	int NOT NULL,
	[nohientai] int
=======
	[dienthoai]	nvarchar(20) NOT NULL,
	[nohientai] int NOT NULL,
	FOREIGN KEY (loaiDaiLy) REFERENCES tblLoaiDaiLy(loaiDaiLy),
>>>>>>> 2c1cf5c3b667b69b5ed958f77697579c5513afae
>>>>>>> parent of a4faa10... Revert "Update CreateQLDL.sql"
)
CREATE TABLE [dbo].[tblPhieuThuTien]
(
	[maPhieu]	int	NOT NULL PRIMARY KEY,
<<<<<<< HEAD
	[maDaiLy]	int NOT NULL,
	[tenDaiLy]	nvarchar(50) NOT NULL,
	[diachi]	nvarchar(50) NOT NULL,
	[email]		nvarchar(30),
	[dienthoai]	int NOT NULL,
	[ngayThuTien] datetime2(7) NOT NULL,
	[soTienThu] int NOT NULL,
=======
<<<<<<< HEAD
	[maDaiLy]	int NOT NULL,
	[ngayThuTien] datetime2(7) NOT NULL,
	[soTienThu] int NOT NULL,
=======
	[tenDaiLy]	nvarchar(50) NOT NULL,	
	[ngayThuTien] datetime NOT NULL,
	[soTienThu] int NOT NULL
	FOREIGN KEY (tenDaiLy) REFERENCES tblHoSoDaiLy(tenDaiLy),
>>>>>>> 2c1cf5c3b667b69b5ed958f77697579c5513afae
>>>>>>> parent of a4faa10... Revert "Update CreateQLDL.sql"
)
CREATE TABLE [dbo].[tblPhieuXuatHang]
(
	[maXuatHang]	int NOT NULL PRIMARY KEY,
<<<<<<< HEAD
	[maDaiLy]		int NOT NULL,
	[ngayLapPhieu]	datetime2(7) NOT NULL,
	[thanhtien]		int NOT NULL
=======
<<<<<<< HEAD
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
=======
	[tenDaiLy]	nvarchar(50) NOT NULL,
	[ngayLapPhieu]	datetime NOT NULL,
	[tongtien]		int NOT NULL,
	FOREIGN KEY (tenDaiLy) REFERENCES tblHoSoDaiLy(tenDaiLy),
>>>>>>> parent of a4faa10... Revert "Update CreateQLDL.sql"
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
<<<<<<< HEAD
	[maLoaiDaiLy] int NOT NULL PRIMARY KEY,
	[tenLoaiDaiLy]	nvarchar(30) NOT NULL
=======
	[maPhieu] int NOT NULL PRIMARY KEY,			
	[thang] int NOT NULL	
>>>>>>> 2c1cf5c3b667b69b5ed958f77697579c5513afae
>>>>>>> parent of a4faa10... Revert "Update CreateQLDL.sql"
)
CREATE TABLE [dbo].[tblNoDaiLy]
(
<<<<<<< HEAD
	[maDaiLy]	int NOT NULL PRIMARY KEY,
	[nodau]		int,
	[nocuoi]	int,
	[phatsinh]	int,
	[thang]		datetime NOT NULL
=======
<<<<<<< HEAD
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
=======
	[maPhieu] int NOT NULL PRIMARY KEY,		
	[tongDoanhThu]	int NOT NULL,	
	[thang] int NOT NULL	
>>>>>>> parent of a4faa10... Revert "Update CreateQLDL.sql"
)
CREATE TABLE [dbo].[tblDoanhThuDaiLy]
(
	[maDaiLy]	int NOT NULL PRIMARY KEY,
	[sophieuxuat]	int NOT NULL,
	[tongtrigia]	int NOT NULL,
	[tyle]			float NOT NULL,
	[thang]		datetime NOT NULL
)
CREATE TABLE [dbo].[tblQuyDinh]
(
	[MaxDL1] int,
	[MaxDL2] int,
	[SoluongMH] int,
	[SoluongDVT] int,
	[NoMaxDL1]	int,
	[NoMaxDL2]	int
)
USE [QLDL]
GO
ALTER TABLE [dbo].[tblHoSoDaiLy]
ADD CONSTRAINT FK_LOAIDL FOREIGN KEY (loaiDaiLy) REFERENCES [dbo].[tblLoaiDaiLy](maLoaiDaiLy)
GO
ALTER TABLE [dbo].[tblDanhSachDaiLy]
ADD CONSTRAINT FK_MADL FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblHoSoDaiLy](maDaiLy)
GO
ALTER TABLE [dbo].[tblNoDaiLy]
ADD CONSTRAINT FK_MADL_NDL FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblDanhSachDaiLy](maDaiLy)
GO
ALTER TABLE [dbo].[tblDoanhThuDaiLy]
ADD CONSTRAINT FK_MADL_DTDL FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblDanhSachDaiLy](maDaiLy)
GO
ALTER TABLE [dbo].[tblPhieuThuTien]
ADD CONSTRAINT FK_MADL_PTT FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblHoSoDaiLy](maDaiLy)
GO
ALTER TABLE [dbo].[tblPhieuXuatHang]
ADD CONSTRAINT FK_MADL_PXH FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblHoSoDaiLy](maDaiLy)
GO
ALTER TABLE [dbo].[tblChiTietPhieuXH]
ADD CONSTRAINT FK_MAXH FOREIGN KEY (maXuatHang) REFERENCES [dbo].[tblPhieuXuatHang](maXuatHang)

<<<<<<< HEAD
SET DATEFORMAT DMY 
GO
GO
INSERT INTO [dbo].[tblLoaiDaiLy] VALUES ('1','Loai Dai Ly 1')
GO
INSERT INTO [dbo].[tblLoaiDaiLy] VALUES ('2','Loai Dai Ly 2')
GO
INSERT INTO [dbo].[tblLoaiDaiLy] VALUES ('3','Loai Dai Ly 3')
GO
INSERT INTO [dbo].[tblHoSoDaiLy] ([maDaiLy], [tenDaiLy], [diachi],[email], [loaiDaiLy], [dientich],[sonhanvien], [ngayTiepNhan],[quan], [dienthoai]) 
VALUES ('1','Dai Ly A','Dia Chi Dai Ly A','DLA@email.com','1','120','5','20/03/1999','12','0909111222')
GO
INSERT INTO [dbo].[tblHoSoDaiLy] VALUES ('2','Dai Ly B','Dia Chi Dai Ly B','DLB@email.com','2','150','10','30/04/1975','9','0909222333')
GO
INSERT INTO [dbo].[tblHoSoDaiLy] VALUES ('3','Dai Ly C','Dia Chi Dai Ly C','DLC@email.com','3','132','9','19/05/1890','9','0930041975')
GO
UPDATE tblHoSoDaiLy SET [tenDaiLy] = 'test', [diachi] = 'test', [email] = 'test', [loaiDaiLy] = '1', [quan] = '2', [dienthoai] = '123', [dientich] = '30', [sonhanvien] = '7' WHERE [maDaiLy] = '9'
DELETE FROM tblHoSoDaiLy WHERE [maDaiLy] = '1'
=======
>>>>>>> 2c1cf5c3b667b69b5ed958f77697579c5513afae
>>>>>>> parent of a4faa10... Revert "Update CreateQLDL.sql"
