-- DB đề thi số 1
CREATE DATABASE DeThiSo1_TaiKhoan;
GO
USE DeThiSo1_TaiKhoan;
GO
DROP TABLE IF EXISTS TaiKhoan;
CREATE TABLE TaiKhoan(
Id INT PRIMARY KEY,
TenTK NVARCHAR(50) UNIQUE DEFAULT NULL,
MatKhau VARCHAR(50) DEFAULT NULL,
GioiTinh INT DEFAULT 0,
TrangThai BIT DEFAULT 1,
IdChucVu INT,
);
DROP TABLE IF EXISTS LoaiTaiKhoan;
CREATE TABLE LoaiTaiKhoan(
Id  INT PRIMARY KEY,
MaTK NVARCHAR(100) UNIQUE DEFAULT NULL,
TenTK NVARCHAR(100) DEFAULT NULL
);

ALTER TABLE TaiKhoan
ADD CONSTRAINT FK_TaiKhoanLoaiTaiKhoan
FOREIGN KEY(IdChucVu) REFERENCES LoaiTaiKhoan(Id);

INSERT INTO LoaiTaiKhoan(Id,MaTK,TenTK)
VALUES (1,'TP',N'Trưởng Phòng'),
		(2,'PP',N'Phó Phòng'),
        (3,'NV',N'Nhân Viên');

INSERT INTO TaiKhoan(Id,TenTK,MatKhau,GioiTinh,TrangThai,IdChucVu)
VALUES (1,N'Dũng',123,1,1,1),
		(2,N'Trang',1234,0,0,2),
        (3,N'Kiều',12345,0,1,3),
		(4,N'Nguyên',2222,0,1,3);

-- DB Đề thi số 2
CREATE DATABASE DeThiSo2_SanPham;
GO
USE DeThiSo2_SanPham;
GO
DROP TABLE IF EXISTS SanPham;
CREATE TABLE SanPham(
Id INT PRIMARY KEY,
MaSP VARCHAR(50) UNIQUE DEFAULT NULL,
TenSP NVARCHAR(50) DEFAULT NULL,
TrongLuong FLOAT DEFAULT NULL,
TrangThai BIT DEFAULT 1,
IdTheLoai INT,
);
DROP TABLE IF EXISTS TheLoai;
CREATE TABLE TheLoai(
Id  INT PRIMARY KEY,
MaTL NVARCHAR(100) UNIQUE DEFAULT NULL,
TenTL NVARCHAR(100) DEFAULT NULL
);

ALTER TABLE SanPham
ADD CONSTRAINT FK_SanPhamTheLoai
FOREIGN KEY(IdTheLoai) REFERENCES TheLoai(Id);

INSERT INTO TheLoai(Id,MaTL,TenTL)
VALUES (1,'LT',N'Laptop'),
		(2,'DT',N'Điện thoại'),
        (3,'MTB',N'Máy tính bảng');

INSERT INTO SanPham(Id,MaSP,TenSP,TrongLuong,TrangThai,IdTheLoai)
VALUES (1,'IP11',N'Iphone 11',0.5,1,2),
		(2,'MCP',N'Macbook Pro',1.5,0,1),
        (3,'MCA',N'Macbook Air',1.1,1,1),
		(4,'IP12',N'Iphone 12',0.4,1,2);		

-- DB Đề thi số 3
CREATE DATABASE DeThiSo3_SinhVien;
GO
USE DeThiSo3_SinhVien;
GO
DROP TABLE IF EXISTS SinhVien;
CREATE TABLE SinhVien(
Id INT PRIMARY KEY,
MaSV VARCHAR(50) UNIQUE DEFAULT NULL,
TenSV NVARCHAR(50) DEFAULT NULL,
NamSinh VARCHAR(100) DEFAULT NULL,
TrangThai BIT DEFAULT 1,
IdNganh INT,
);
DROP TABLE IF EXISTS Nganh;
CREATE TABLE Nganh(
Id  INT PRIMARY KEY,
MaNganh NVARCHAR(100) UNIQUE DEFAULT NULL,
TenNganh NVARCHAR(100) DEFAULT NULL
);

ALTER TABLE SinhVien
ADD CONSTRAINT FK_SinhVienNganh
FOREIGN KEY(IdNganh) REFERENCES Nganh(Id);

INSERT INTO Nganh(Id,MaNganh,TenNganh)
VALUES (1,'WEB',N'TK Website'),
		(2,'UD1',N'Ứng Dụng .Net'),
        (3,'UD2',N'Ứng Dụng Java');

INSERT INTO SinhVien(Id,MaSV,TenSV,NamSinh,TrangThai,IdNganh)
VALUES (1,'Dungna',N'Nguyễn Anh Dũng','1989',1,2),
		(2,'MinhDq',N'Đặng Quang Minh','2000',1,3),
        (3,'TienNH',N'Nguyễn Hoàng Tiến','1990',0,1),
		(4,'Datlt',N'Lê Trọng Đạt ','1992',1,1);