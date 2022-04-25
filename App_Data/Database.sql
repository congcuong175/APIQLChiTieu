create DATABASE QLCHITEU
GO
use QLCHITEU
go
CREATE TABLE LOAICHITIEU
(
    maLoaiCT int identity primary key,
	iCon int,
	tenLoaiTN nvarchar(30)
)
CREATE TABLE LOAITHUNHAP(
maLoaiTN int identity primary key,
	icon int,
	tenLoaiTN nvarchar(30)
)
create TABLE DBOChiTieu(
	maChiTieu int identity primary key,
	maLoaiChiTieu int not null,
    thoiGian ntext,
	ngayThang ntext not null,
	tien int,
	ghiChu ntext,
	isChiTieu bit
)


CREATE TABLE THUNHAP(
	maThuNhap int identity primary key,
	maLoaiThuNhap int not null,
	ngayThang ntext,
	ghiChu ntext
)

CREATE TABLE CHITIETTHUNHAP(
	maThuNhap int not null,
	tenThuNhap int,
	tien int,
	ghiChu ntext
)

