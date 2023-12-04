CREATE DATABASE QLBDGT
USE QLBDGT

CREATE TABLE LoaiSanPham(
	maLSP VARCHAR(5) PRIMARY KEY,
	tenLSP NVARCHAR(50) NOT NULL,
)

CREATE TABLE GioHang(
    maGH VARCHAR(5) PRIMARY KEY,
)

CREATE TABLE SanPham(
	maSP VARCHAR(5) PRIMARY KEY,
	maLSP VARCHAR(5) NOT NULL FOREIGN KEY REFERENCES LoaiSanPham(maLSP),
	tenSP NVARCHAR(100) NOT NULL,
	moTa NVARCHAR(200) NULL,
	donViTinh NVARCHAR(10) NOT NULL,
	donGia INT NOT NULL,
	anh VARCHAR(50) NOT NULL DEFAULT('guitar.png'),
) 

CREATE TABLE TaiKhoan(
    email VARCHAR(50) PRIMARY KEY,
    matKhau VARCHAR(30) NOT NULL,
    nhanVien bit NOT NULL DEFAULT(1), 
    --1: Nhân viên; 0: Khách hàng
)

CREATE TABLE KhachHang(
    maKH VARCHAR(5) PRIMARY KEY,
    hoKH NVARCHAR(50) NOT NULL,
    tenKH NVARCHAR(10) NOT NULL,
    sdt VARCHAR(10) NULL,
    email VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES TaiKhoan(email),
    diaChi NVARCHAR(100) NULL,
	maGH VARCHAR(5) NOT NULL FOREIGN KEY REFERENCES GioHang(maGH),
)

CREATE TABLE LoaiNhanVien(
    maLNV VARCHAR(5) PRIMARY KEY,
    tenLNV NVARCHAR(20) NOT NULL,
)

CREATE TABLE NhanVien(
    maNV VARCHAR(5) PRIMARY KEY,
    tenNV NVARCHAR(50) NOT NULL,
    sdt VARCHAR(10) NOT NULL,
    email VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES TaiKhoan(email),
    maLNV VARCHAR(5) NOT NULL FOREIGN KEY REFERENCES LoaiNhanVien(maLNV),
    gioiTinh bit NOT NULL DEFAULT(1),
    ngaySinh DATE NULL, 
)

CREATE TABLE HoaDon(
    maHD VARCHAR(5) PRIMARY KEY,
    maKH VARCHAR(5) NOT NULL FOREIGN KEY REFERENCES KhachHang(maKH),
    maNV VARCHAR(5) NOT NULL FOREIGN KEY REFERENCES NhanVien(maNV),
    ngayGiaoDich DATETIME NOT NULL,
)
CREATE TABLE CTHD(
    maHD VARCHAR(5) NOT NULL FOREIGN KEY REFERENCES HoaDon(maHD),
    maSP VARCHAR(5) NOT NULL FOREIGN KEY REFERENCES SanPham(maSP),
    soLuong TINYINT NOT NULL,
)

CREATE TABLE CTGH(
	maCTGH varchar(5) primary key,
    maGH VARCHAR(5) NOT NULL FOREIGN KEY REFERENCES GioHang(maGH),
    maSP VARCHAR(5) NOT NULL FOREIGN KEY REFERENCES SanPham(maSP),
    soLuong TINYINT NOT NULL,
    daThanhToan BIT NOT NULL DEFAULT(0),
    -- 0: chưa thanh toán; 1: đã thanh toán
)

INSERT INTO LoaiSanPham (maLSP, tenLSP) VALUES
('LSP01', 'Acoustic'),
('LSP02', 'Electric'),
('LSP03', 'Phụ kiện');

INSERT INTO SanPham (maSP, maLSP, tenSP, moTa, donViTinh, anh, donGia) VALUES
('SP001', 'LSP01', N'Guitar Acoustic Fender FA-115', N'Đàn guitar acoustic cho người mới học', N'Chiếc', 'fender_fa115.jpg', 3000000),
('SP002', 'LSP02', N'Guitar Electric Gibson Les Paul', N'Đàn guitar electric chất lượng cao', N'Chiếc', 'gibson_les_paul.jpg', 8000000),
('SP003', 'LSP03', N'Bộ phụ kiện đàn Guitar', N'Bao da, dây đàn, gảy đàn', N'Bộ', 'guitar_accessories.jpg', 500000),
('SP004', 'LSP01', N'Guitar Acoustic Yamaha FG800', N'Đàn guitar acoustic chất lượng cao', N'Chiếc', 'yamaha_fg800.jpg', 4000000),
('SP005', 'LSP02', N'Guitar Electric Ibanez RG550', N'Đàn guitar electric chất lượng cao', N'Chiếc', 'ibanez_rg550.jpg', 12000000),
('SP006', 'LSP01', N'Guitar Acoustic Taylor 214ce', N'Đàn guitar acoustic chất lượng cao', N'Chiếc', 'taylor_214ce.jpg', 8000000),
('SP007', 'LSP02', N'Guitar Electric PRS Custom 24', N'Đàn guitar electric chất lượng cao', N'Chiếc', 'prs_custom_24.jpg', 15000000),
('SP008', 'LSP01', N'Guitar Acoustic Martin D-28', N'Đàn guitar acoustic chất lượng cao', N'Chiếc', N'martin_d28.jpg', 12000000),
('SP009', 'LSP02', N'Guitar Electric Fender Stratocaster', N'Đàn guitar electric chất lượng cao', N'Chiếc', 'fender_stratocaster.jpg', 18000000),
('SP010', 'LSP01', N'Guitar Acoustic Fender SA-115', N'Đàn guitar acoustic cho người tầm trung', N'Chiếc', 'fender_Sa115.jpg', 4500000),
('SP011', 'LSP02', N'Guitar Electric Gibson Arti Brav', N'Đàn guitar electric chất lượng cao', N'Chiếc', 'gibson_arti_brav.jpg', 8200000),
('SP012', 'LSP01', N'Guitar Acoustic Yamaha FG900', N'Đàn guitar acoustic chất lượng cao', N'Chiếc', 'yamaha_fg900.jpg', 4500000),
('SP013', 'LSP02', N'Guitar Electric Zheng BL550', N'Đàn guitar electric chất lượng cao', N'Chiếc', 'zheng_bl550.jpg', 6000000),
('SP014', 'LSP01', N'Guitar Acoustic Taylor 351ce', N'Đàn guitar acoustic chất lượng cao', N'Chiếc', 'taylor_351ce.jpg', 8800000),
('SP015', 'LSP02', N'Guitar Electric SPR Cu LSP01, sNtom 12', N'Đàn guitar electric chất lượng cao', N'Chiếc', 'spr_cu LSP01,stNom_12.jpg', 17000000),
('SP016', 'LSP01', N'Guitar Acoustic Martin B-32', N'Đàn guitar acoustic chất lượng cao', N'Chiếc', 'martin_b32.jpg', 12490000),
('SP017', 'LSP02', N'Guitar Electric ZuDeDus S155', N'Đàn guitar electric chất lượng cao', N'Chiếc', 'zudedus_s155.jpg', 18900000),
('SP018', 'LSP01', N'Guitar Acoustic Flamenco Jx 25CE', N'Đàn guitar acoustic chất lượng cao', N'Chiếc', 'flamenco_25ce.jpg', 6500000),
('SP019', 'LSP01', N'Guitar Acoustic Conic AT130', N'Đàn guitar acoustic chất lượng cao', N'Chiếc', 'conic_at130.jpg', 1490000),
('SP020', 'LSP01', N'Guitar Acoustic ENYA EGA-Q1M', N'Đàn guitar acoustic chất lượng cao', N'Chiếc', 'enya_egaq1m.jpg', 1900000),
('SP021', 'LSP01', N'Guitar Acoustic ENYA X4 PRO', N'Đàn guitar acoustic chất lượng cao', N'Chiếc', 'enya_x4pro.jpg', 17000000),
('SP022', 'LSP01', N'Guitar Acoustic CORDOBA Stage Edge Burst', N'Đàn guitar acoustic chất lượng cao', N'Chiếc', 'cordoba_stage.jpg', 1900000),
('SP023', 'LSP01', N'Guitar Acoustic Natasha JC3', N'Đàn guitar acoustic chất lượng cao', N'Chiếc', 'natasha_jc3.jpg', 1900000),
('SP024', 'LSP03', N'Amply W-King K6L', N'Amplifier đàn chất lượng cao', N'Chiếc', 'amply_wking.jpg', 5700000),
('SP025', 'LSP03', N'Amply Acnos CS551 Plus', N'Amplifier đàn chất lượng cao', N'Chiếc', 'amply_acnos.jpg', 9200000),
('SP026', 'LSP03', N'AMPLY PARAMAX PASION 2C', N'Amplifier đàn chất lượng cao', N'Chiếc', 'amply_paramax.jpg', 5600000),
('SP027', 'LSP03', N'Amply Prosing W8 Kor', N'Amplifier đàn chất lượng cao', N'Chiếc', 'amply_prosing.jpg', 11500000),
('SP028', 'LSP02', N'Guitar Electric Tagima TG530', N'Đàn guitar electric chất lượng cao', N'Chiếc', 'tagima_tg530.jpg', 4500000),
('SP029', 'LSP02', N'Guitar Electric Ibanez AS63 - Artcore', N'Đàn guitar electric chất lượng cao', N'Chiếc', 'ibanez_as63_artcore.jpg', 9100000),
('SP030', 'LSP02', N'Guitar Electric Ibanez GRG220PA1 RG GIO', N'Đàn guitar electric chất lượng cao', N'Chiếc', 'ibanez_gr_gio.jpg', 7300000);

-- Thêm dữ liệu cho bảng TaiKhoan
INSERT INTO TaiKhoan (email, matKhau, nhanVien) VALUES
('nhanvien1@gmail.com', 'matkhau1', 1),
('nhanvien2@gmail.com', 'matkhau2', 1),
('nhanvien3@gmail.com', 'matkhau3', 1),
('nhanvien4@gmail.com', 'matkhau4', 1),
('nhanvien5@gmail.com', 'matkhau5', 1),
('khachhang1@gmail.com', 'matkhauKH1', 0),
('khachhang2@gmail.com', 'matkhauKH2', 0),
('khachhang3@gmail.com', 'matkhauKH3', 0),
('khachhang4@gmail.com', 'matkhauKH4', 0),
('khachhang5@gmail.com', 'matkhauKH5', 0);

-- Thêm dữ liệu cho bảng GioHang
INSERT INTO GioHang (maGH) VALUES
('GH001'),
('GH002'),
('GH003'),
('GH004'),
('GH005');

-- Thêm dữ liệu cho bảng KhachHang
INSERT INTO KhachHang (maKH, hoKH, tenKH, sdt, email, diaChi, maGH) VALUES
('KH001', N'Nguyễn Văn', N'Khách 1', '0987654321', 'khachhang1@gmail.com', N'123 Đường ABC', 'GH001'),
('KH002', N'Nguyễn Văn', N'Khách 2', '0987654322', 'khachhang2@gmail.com', N'456 Đường XYZ', 'GH002'),
('KH003', N'Trần Nguyễn', N'Khách 3', '123456123', 'khachhang3@gmail.com', N'789 Đường ZCX', 'GH003'),
('KH004', N'Lê Văn', N'Khách 4', '0123789457', 'khachhang4@gmail.com', N'049 Đường JKL', 'GH004'),
('KH005', N'Trần Thanh', N'Khách 5', '8527419630', 'khachhang5@gmail.com', N'852 Đường QWE', 'GH005');

-- Thêm dữ liệu cho bảng LoaiNhanVien
INSERT INTO LoaiNhanVien (maLNV, tenLNV) VALUES
('LNV01', N'Quản lý'),
('LNV02', N'Nhân viên bán hàng'),
('LNV03', N'Nhân viên kho');

-- Thêm dữ liệu cho bảng NhanVien
INSERT INTO NhanVien (maNV, tenNV, sdt, email, maLNV, gioiTinh, ngaySinh) VALUES
('NV001', N'Trần Thị Quản Lý', '0987654323', 'nhanvien1@gmail.com', 'LNV01', 0, '1990-01-01'),
('NV002', N'Nguyễn Văn Bán Hàng', '0987654324', 'nhanvien2@gmail.com', 'LNV02', 1, '1992-03-15'),
('NV003', N'Lê Thị Kế Toán', '0987654325', 'nhanvien3@gmail.com', 'LNV03', 0, '1988-05-20'),
('NV004', N'Hồ Văn IT', '0987654326', 'nhanvien4@gmail.com', 'LNV02', 1, '1995-09-10'),
('NV005', N'Ngọc Thanh Bảo Vệ', '9637410852', 'nhanvien5@gmail.com', 'LNV03', 1, '1995-09-10');

-- Thêm dữ liệu cho bảng HoaDon
INSERT INTO HoaDon (maHD, maKH, maNV, ngayGiaoDich) VALUES
('HD001', 'KH001', 'NV001', '2023-01-10 08:30:00'),
('HD002', 'KH002', 'NV002', '2023-01-11 09:45:00');

-- Thêm dữ liệu cho bảng CTHD
INSERT INTO CTHD (maHD, maSP, soLuong) VALUES
('HD001', 'SP001', 2),
('HD001', 'SP003', 1),
('HD002', 'SP002', 1),
('HD002', 'SP005', 3);

-- Thêm dữ liệu cho bảng CTGH
INSERT INTO CTGH (maCTGH, maGH, maSP, soLuong, daThanhToan) VALUES
('CT001', 'GH001', 'SP004', 1, 0),
('CT002','GH001', 'SP006', 2, 1),
('CT003','GH002', 'SP008', 1, 0),
('CT004','GH002', 'SP010', 3, 0),
('CT005','GH003', 'SP020', 3, 0),
('CT006','GH004', 'SP010', 3, 0),
('CT007','GH005', 'SP010', 3, 0);

select * from TaiKhoan