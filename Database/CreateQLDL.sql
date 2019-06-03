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
CREATE TABLE [dbo].[tblLoaiDaiLy]
(	
	[loaiDaiLy]	int NOT NULL PRIMARY KEY,	
	[maxno] int NOT NULL
)
CREATE TABLE [dbo].[tblMatHang]
<<<<<<< HEAD
(
	[maMatHang] int NOT NULL PRIMARY KEY,
	[tenmathang] nvarchar(50) NOT NULL,
=======
(	
	[tenmathang] nvarchar(50) NOT NULL PRIMARY KEY,		
>>>>>>> 2c1cf5c3b667b69b5ed958f77697579c5513afae
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
(	
	[tenDaiLy]	nvarchar(50) NOT NULL PRIMARY KEY,
>>>>>>> 2c1cf5c3b667b69b5ed958f77697579c5513afae
	[diachi]	nvarchar(50) NOT NULL,
	[email]		nvarchar(30),
	[loaiDaiLy]	int	NOT NULL,
	[ngayTiepNhan]	datetime2(7) NOT NULL,
	[quan]		nvarchar(20) NOT NULL,
<<<<<<< HEAD
	[dienthoai]	int NOT NULL,
	[nohientai] int
=======
	[dienthoai]	nvarchar(20) NOT NULL,
	[nohientai] int NOT NULL,
	FOREIGN KEY (loaiDaiLy) REFERENCES tblLoaiDaiLy(loaiDaiLy),
>>>>>>> 2c1cf5c3b667b69b5ed958f77697579c5513afae
)
CREATE TABLE [dbo].[tblPhieuThuTien]
(
	[maPhieu]	int	NOT NULL PRIMARY KEY,
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
)
CREATE TABLE [dbo].[tblPhieuXuatHang]
(
	[maXuatHang]	int NOT NULL PRIMARY KEY,
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
)
CREATE TABLE [dbo].[tblNoDaiLy]
(		
	[tenDaiLy]	nvarchar(50) NOT NULL PRIMARY KEY,
	[noDau]	int NOT NULL,
	[noCuoi]	int NOT NULL,
	[phatSinh]	int NOT NULL,
	FOREIGN KEY (tenDaiLy) REFERENCES tblHoSoDaiLy(tenDaiLy),
)
CREATE TABLE [dbo].[tblPhieubaocaoCongNo]
(
	[maPhieu] int NOT NULL PRIMARY KEY,			
	[thang] int NOT NULL	
>>>>>>> 2c1cf5c3b667b69b5ed958f77697579c5513afae
)
CREATE TABLE [dbo].[tblPhieubaocaoDoanhThu]
(
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
)
CREATE TABLE [dbo].[tblQuiDinh]
(
	[getkey] int NOT NULL primary key,
	[maxloaidl]    int NOT NULL,	
	[soluongmathang]	int NOT NULL,
	[soluongdvt]	int NOT NULL,	
	[maxdl]	int NOT NULL,--max so dl trong 1 quan
)	

--drop table tblMatHang
--drop table tblHoSoDaiLy
--drop table tblPhieuThuTien
--drop table tblPhieuXuatHang
--drop table tblNoDaiLy
--drop table tblPhieubaocaoCongNo
--drop table tblPhieubaocaoDoanhThu
--drop table tblQuiDinh


--dữ liệu có trước--
SET DATEFORMAT dmy;  
INSERT INTO tblLoaiDaiLy (loaiDaiLy, maxno)
VALUES (1, 20000);
INSERT INTO tblLoaiDaiLy (loaiDaiLy, maxno)
VALUES (2, 50);

INSERT INTO tblQuiDinh (getkey, maxloaidl, soluongmathang, soluongdvt, maxdl)
VALUES (1, 2, 5, 3, 4);

INSERT INTO tblDonvi (donViTinh)
VALUES ('dv1');
INSERT INTO tblDonvi (donViTinh)
VALUES ('dv2');
INSERT INTO tblDonvi (donViTinh)
VALUES ('dv3');


INSERT INTO tblMatHang (tenmathang, hanSuDung, gia, donViTinh) 
VALUES ( 'mh1', '9/10/2020', 3000, 'dv1');
INSERT INTO tblMatHang (tenmathang, hanSuDung, gia, donViTinh)
VALUES ( 'mh2', '7/9/2020', 4000, 'dv2');
INSERT INTO tblMatHang (tenmathang, hanSuDung, gia, donViTinh)
VALUES ( 'mh3', '17/6/2020', 5000, 'dv1');
INSERT INTO tblMatHang (tenmathang, hanSuDung, gia, donViTinh)
VALUES ( 'mh4', '6/12/2020', 6000, 'dv3');
INSERT INTO tblMatHang (tenmathang, hanSuDung, gia, donViTinh)
VALUES ( 'mh5', '20/8/2020', 7000, 'dv3');

INSERT INTO tblHoSoDaiLy (tenDaiLy, diachi, email, loaiDaiLy, ngayTiepNhan, quan, dienthoai, nohientai)
VALUES ('dl1', 'dc1', 'dl1@gmail.com', 1, '2/6/2019', N'Quận 7', 3243443, 0);
INSERT INTO tblHoSoDaiLy (tenDaiLy, diachi, email, loaiDaiLy, ngayTiepNhan, quan, dienthoai, nohientai)
VALUES ('dl2', 'dc2', 'dl2@gmail.com', 2, '12/9/2019', N'Quận 10', 33443, 10);
INSERT INTO tblHoSoDaiLy (tenDaiLy, diachi, email, loaiDaiLy, ngayTiepNhan, quan, dienthoai, nohientai)
VALUES ('dl3', 'dc3', 'dl3@gmail.com', 2, '3/7/2019', N'Quận 4', 3243443, 5);
INSERT INTO tblHoSoDaiLy (tenDaiLy, diachi, email, loaiDaiLy, ngayTiepNhan, quan, dienthoai, nohientai)
VALUES ('dl4', 'dc4', 'dl4@gmail.com', 1, '20/12/2019', N'Quận Bình Thạnh', 324233, 400);
INSERT INTO tblHoSoDaiLy (tenDaiLy, diachi, email, loaiDaiLy, ngayTiepNhan, quan, dienthoai, nohientai)
VALUES ('dl5', 'dc5', 'dl5@gmail.com', 2, '9/2/2019', N'Quận Thủ Đức', 3903443, 15);


--USE [QLDL]
--GO
--ALTER TABLE [dbo].[tblPhieuXuatHang]
--ADD CONSTRAINT FK_LOAIDL FOREIGN KEY (loaiDaiLy) REFERENCES [dbo].[tblLoaiDaiLy](maLoaiDaiLy)
--GO
--ALTER TABLE [dbo].[tblDanhSachDaiLy]
--ADD CONSTRAINT FK_MADL FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblHoSoDaiLy](maDaiLy)
--GO
--ALTER TABLE [dbo].[tblPhieuThuTien]
--ADD CONSTRAINT FK_MADL_PTT FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblHoSoDaiLy](maDaiLy)
--GO
--ALTER TABLE [dbo].[tblPhieuXuatHang]
--ADD CONSTRAINT FK_MADL_PXH FOREIGN KEY (maDaiLy) REFERENCES [dbo].[tblHoSoDaiLy](maDaiLy)
--GO
--ALTER TABLE [dbo].[tblChiTietPhieuXH]
--ADD CONSTRAINT FK_MAXH FOREIGN KEY (maXuatHang) REFERENCES [dbo].[tblPhieuXuatHang](maXuatHang)


>>>>>>> 2c1cf5c3b667b69b5ed958f77697579c5513afae
