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
	[maLoaiDaiLy] nvarchar(10) NOT NULL PRIMARY KEY,
	[loaiDaiLy]	int NOT NULL,	
	[maxno] int NOT NULL
)
CREATE TABLE [dbo].[tblDonvi]
(
	[donViTinh]  nvarchar(20) NOT NULL primary key,	
)	
CREATE TABLE [dbo].[tblMatHang]
(	
	[maMatHang] nvarchar(10) NOT NULL PRIMARY KEY,
	[tenmathang] nvarchar(50) NOT NULL,		
	[hanSuDung] datetime2(7) NOT NULL,
	[gia]		int NOT NULL,
	[donViTinh] nvarchar(20),
	FOREIGN KEY (donViTinh) REFERENCES tblDonvi(donViTinh),
)
CREATE TABLE [dbo].[tblHoSoDaiLy]
(	
	[maDaiLy]	nvarchar(10) NOT NULL PRIMARY KEY,
	[tenDaiLy]	nvarchar(50) NOT NULL,
	[diachi]	nvarchar(50) NOT NULL,
	[email]		nvarchar(30),
	[maloaiDaiLy]	nvarchar(10)	NOT NULL,
	[ngayTiepNhan]	datetime2(7) NOT NULL,
	[quan]		nvarchar(20) NOT NULL,
	[dienthoai]	nvarchar(20) NOT NULL,
	[nohientai] int NOT NULL,
	FOREIGN KEY (maloaiDaiLy) REFERENCES tblLoaiDaiLy(maloaiDaiLy),
)
CREATE TABLE [dbo].[tblPhieuThuTien]
(
	[maPhieu]	nvarchar(10)	NOT NULL PRIMARY KEY,
	[maDaiLy]	nvarchar(10) NOT NULL,	
	[ngayThuTien] datetime2(7) NOT NULL,
	[soTienThu] int NOT NULL
	FOREIGN KEY (maDaiLy) REFERENCES tblHoSoDaiLy(maDaiLy),
)
CREATE TABLE [dbo].[tblPhieuXuatHang]
(
	[maXuatHang]	 nvarchar(10) NOT NULL PRIMARY KEY,
	[maDaiLy]	     nvarchar(10) NOT NULL,
	[ngayLapPhieu]	 datetime2(7) NOT NULL,
	[tongtien]		 int,--tong toan bo phieu xuat--
	FOREIGN KEY (maDaiLy) REFERENCES tblHoSoDaiLy(maDaiLy),
)
CREATE TABLE [dbo].[tblChitietPhieuXuatHang]
(	
	[maXuatHang]	 nvarchar(10) NOT NULL,
	[maMatHang]	     nvarchar(10) NOT NULL,
	[soluong]	int NOT NULL,
	[tongtien]		 int NOT NULL,--tong cua mat hang--
	FOREIGN KEY ([maXuatHang]) REFERENCES [tblPhieuXuatHang]([maXuatHang]),
	FOREIGN KEY ([maMatHang]) REFERENCES [tblMatHang]([maMatHang]),
)
CREATE TABLE [dbo].[tblNoThangtruoc]
(		
	[maDaiLy]	nvarchar(10) NOT NULL PRIMARY KEY,
	[nothangT] 	int NOT NULL,	
	FOREIGN KEY (maDaiLy) REFERENCES tblHoSoDaiLy(maDaiLy),
)
CREATE TABLE [dbo].[tblPhieubaocaoCongNo]
(
	[maPhieu] nvarchar(10) NOT NULL PRIMARY KEY,		
	[ngayLapPhieu]	 datetime2(7) NOT NULL,	
)
CREATE TABLE [dbo].[tblCTPhieubaocaoCongNo]
(		
	[maPhieu] nvarchar(10) NOT NULL,
	[maDaiLy]	nvarchar(10) NOT NULL PRIMARY KEY,
	[noDau] 	int NOT NULL,
	[noCuoi]	int NOT NULL,
	[phatSinh]	int NOT NULL,
	FOREIGN KEY (maPhieu) REFERENCES tblPhieubaocaoCongNo(maPhieu),
	FOREIGN KEY (maDaiLy) REFERENCES tblHoSoDaiLy(maDaiLy),
)
CREATE TABLE [dbo].[tblPhieubaocaoDoanhThu]
(
	[maPhieu] nvarchar(10) NOT NULL PRIMARY KEY,	
	[tongDoanhThu]	int NOT NULL,	
	[ngayLapPhieu]	 datetime2(7) NOT NULL,	
)
CREATE TABLE [dbo].[tblChitietPhieubaocaoDT]
(
	[maPhieu] nvarchar(10) NOT NULL,	
	[maDaiLy]	nvarchar(10) NOT NULL,
	[soPhieuXuat] int NOT NULL,			
	[tongDoanhThu]	int NOT NULL,
	[Tyle] float NOT NULL		
	FOREIGN KEY (maPhieu) REFERENCES tblPhieubaocaoDoanhThu(maPhieu),
	FOREIGN KEY (maDaiLy) REFERENCES tblHoSoDaiLy(maDaiLy),	
)
CREATE TABLE [dbo].[tblQuiDinh]
(
	[getkey] int NOT NULL primary key,
	[maxloaidl]    int NOT NULL,	
	[soluongmathang]	int NOT NULL,
	[soluongdvt]	int NOT NULL,	
	[maxdl]	int NOT NULL,--max so dl trong 1 quan
)	

--drop table tblLoaiDaiLy
--drop table tblMatHang
--drop table tblHoSoDaiLy
--drop table tblPhieuThuTien
--drop table tblPhieuXuatHang
--drop table tblChitietPhieuXuatHang
--drop table tblNoDaiLy
--drop table tblPhieubaocaoCongNo
--drop table tblCTPhieubaocaoCongNo
--drop table tblPhieubaocaoDoanhThu
--drop table tblChitietPhieubaocaoDT
--drop table tblQuiDinh


--dữ liệu có trước--
SET DATEFORMAT dmy;  
INSERT INTO tblLoaiDaiLy (maLoaiDaiLy, loaiDaiLy, maxno)
VALUES ('loai1', 1, 20000);
INSERT INTO tblLoaiDaiLy (maLoaiDaiLy, loaiDaiLy, maxno)
VALUES ('loai2', 2, 50);

INSERT INTO tblDonvi(donViTinh)
VALUES ('dv1');
INSERT INTO tblDonvi(donViTinh)
VALUES ('dv2');
INSERT INTO tblDonvi(donViTinh)
VALUES ('dv3');

INSERT INTO tblQuiDinh (getkey, maxloaidl, soluongmathang, soluongdvt, maxdl)
VALUES (1, 2, 5, 3, 4);

INSERT INTO tblMatHang (maMatHang, tenmathang, hanSuDung, gia, donViTinh) 
VALUES ('mh1', N'Sữa', '9/10/2020', 3, 'dv1');
INSERT INTO tblMatHang (maMatHang, tenmathang, hanSuDung, gia, donViTinh)
VALUES ('mh2', N'Đường', '7/9/2020', 4, 'dv2');
INSERT INTO tblMatHang (maMatHang, tenmathang, hanSuDung, gia, donViTinh)
VALUES ('mh3', N'Muối', '17/6/2020', 5, 'dv1');
INSERT INTO tblMatHang (maMatHang, tenmathang, hanSuDung, gia, donViTinh)
VALUES ('mh4', 'Snack', '6/12/2020', 6, 'dv3');
INSERT INTO tblMatHang (maMatHang, tenmathang, hanSuDung, gia, donViTinh)
VALUES ('mh5', 'Kem', '20/8/2020', 7, 'dv3');

INSERT INTO tblHoSoDaiLy (maDaiLy, tenDaiLy, diachi, email, maloaiDaiLy, ngayTiepNhan, quan, dienthoai, nohientai)
VALUES ('dl1', N'Đại lý 1', 'dc1', 'dl1@gmail.com', 'loai1', '2/6/2019', N'Quận 7', 3243443, 0);
INSERT INTO tblHoSoDaiLy (maDaiLy, tenDaiLy, diachi, email, maloaiDaiLy, ngayTiepNhan, quan, dienthoai, nohientai)
VALUES ('dl2', N'Đại lý 2', 'dc2', 'dl2@gmail.com', 'loai2', '12/9/2019', N'Quận 10', 33443, 10);
INSERT INTO tblHoSoDaiLy (maDaiLy, tenDaiLy, diachi, email, maloaiDaiLy, ngayTiepNhan, quan, dienthoai, nohientai)
VALUES ('dl3', N'Đại lý 3', 'dc3', 'dl3@gmail.com', 'loai2', '3/7/2019', N'Quận 4', 3243443, 5);
INSERT INTO tblHoSoDaiLy (maDaiLy, tenDaiLy, diachi, email, maloaiDaiLy, ngayTiepNhan, quan, dienthoai, nohientai)
VALUES ('dl4', N'Đại lý 4', 'dc4', 'dl4@gmail.com', 'loai1', '20/12/2019', N'Quận Bình Thạnh', 324233, 400);
INSERT INTO tblHoSoDaiLy (maDaiLy, tenDaiLy, diachi, email, maloaiDaiLy, ngayTiepNhan, quan, dienthoai, nohientai)
VALUES ('dl5', N'Đại lý 5', 'dc5', 'dl5@gmail.com', 'loai2', '9/2/2019', N'Quận Thủ Đức', 3903443, 15);

INSERT INTO [tblPhieuXuatHang] ([maXuatHang], [maDaiLy], [ngayLapPhieu], [tongtien])
VALUES ('xh1', 'dl1', '9/2/2019', 15);
INSERT INTO [tblPhieuXuatHang] ([maXuatHang], [maDaiLy], [ngayLapPhieu], [tongtien])
VALUES ('xh2', 'dl4', '6/7/2019', 20);
INSERT INTO [tblPhieuXuatHang] ([maXuatHang], [maDaiLy], [ngayLapPhieu], [tongtien])
VALUES ('xh3', 'dl3', '10/9/2019', 300);
INSERT INTO [tblPhieuXuatHang] ([maXuatHang], [maDaiLy], [ngayLapPhieu])
VALUES ('xh4', 'dl3', '11/9/2019', 0);

INSERT INTO [tblPhieuThuTien] ([maPhieu], [maDaiLy], [ngayThuTien], [soTienThu])
VALUES ('ptt1', 'dl4', '6/7/2019', 200);

INSERT INTO [tblNoThangtruoc] (maDaiLy, nothangT)
VALUES ('dl2', 10);
INSERT INTO [tblNoThangtruoc] (maDaiLy, nothangT)
VALUES ('dl1', 100);
INSERT INTO [tblNoThangtruoc] (maDaiLy, nothangT)
VALUES ('dl3', 70);
INSERT INTO [tblNoThangtruoc] (maDaiLy, nothangT)
VALUES ('dl4', 200);
INSERT INTO [tblNoThangtruoc] (maDaiLy, nothangT)
VALUES ('dl5', 50);
----TESTING----
SELECT COUNT(*) as [soldl]
FROM tblLoaiDaiLy

