create database Project_62133026
GO
USE Project_62133026 
CREATE DATABASE quanlybanhang;
USE quanlybanhang;
-- Tạo bảng LOAI_SAN_PHAM
CREATE TABLE LOAI_SAN_PHAM (
  MA_LOAI_SAN_PHAM VARCHAR(255) NOT NULL,
  TEN_LOAI_SAN_PHAM VARCHAR(255) NOT NULL,
  PRIMARY KEY (MA_LOAI_SAN_PHAM)
);
-- Tạo bảng SAN_PHAM
CREATE TABLE SAN_PHAM (
  MA_SP VARCHAR(255) NOT NULL,
  TEN_SP VARCHAR(255) NOT NULL,
  MO_TA_SAN_PHAM VARCHAR(255) NOT NULL,
  DON_VI_TINH VARCHAR(255) NOT NULL,
  ANH_SAN_PHAM VARCHAR(255),
  DON_GIA FLOAT NOT NULL,
  MA_LOAI_SAN_PHAM VARCHAR(255) NOT NULL,
  PRIMARY KEY (MA_SP),
  FOREIGN KEY (MA_LOAI_SAN_PHAM) REFERENCES LOAI_SAN_PHAM (MA_LOAI_SAN_PHAM)
);
-- Tạo bảng KHACH_HANG
CREATE TABLE KHACH_HANG (
  MA_KH VARCHAR(255) NOT NULL,
  HO_TEN VARCHAR(255) NOT NULL,
  EMAIL VARCHAR(255) NOT NULL,
  SO_DIEN_THOAI VARCHAR(255) NOT NULL,
  DIA_CHI VARCHAR(255) NOT NULL,
  MAT_KHAU VARCHAR(255) NOT NULL,
  PRIMARY KEY (MA_KH)
);
-- Tạo bảng NHAN_VIEN
CREATE TABLE NHAN_VIEN (
  MA_NV VARCHAR(255) NOT NULL,
  HO_TEN_NV VARCHAR(255) NOT NULL,
  SO_DIEN_THOAI VARCHAR(255) NOT NULL,
  EMAIL VARCHAR(255) NOT NULL,
  MAT_KHAU VARCHAR(255) NOT NULL,
  QUYEN_SU_DUNG INT NOT NULL,
  PRIMARY KEY (MA_NV)
);
-- Tạo bảng GIỎ_HÀNG
CREATE TABLE GIO_HANG (
  SO_HD VARCHAR (10),
  NGAY_DAT_HANG DATETIME NOT NULL,
  NGAY_GIAO_HANG DATETIME,
  MA_KH VARCHAR(255) NOT NULL,
  MA_NV_DUYET VARCHAR(255),
  MA_NV_GIAO_HANG VARCHAR(255),
  TINH_TRANG INT NOT NULL,
  PRIMARY KEY (SO_HD),
  FOREIGN KEY (MA_KH) REFERENCES KHACH_HANG (MA_KH),
  FOREIGN KEY (MA_NV_DUYET) REFERENCES NHAN_VIEN (MA_NV),
  FOREIGN KEY (MA_NV_GIAO_HANG) REFERENCES NHAN_VIEN (MA_NV)
);
-- Tạo bảng CHI_TIET_GH
CREATE TABLE CHI_TIET_GH (
  SO_HD VARCHAR (10) NOT NULL,
  MA_SP VARCHAR(255) NOT NULL,
  SO_LUONG INT NOT NULL,
  ĐON_GIA_BAN FLOAT NOT NULL,
  PRIMARY KEY (SO_HD, MA_SP),
  FOREIGN KEY (SO_HD) REFERENCES GIO_HANG (SO_HD),
  FOREIGN KEY (MA_SP) REFERENCES SAN_PHAM (MA_SP)
);
-- liên kết các dữ liệu
ALTER TABLE SAN_PHAM
ADD FOREIGN KEY (MA_LOAI_SAN_PHAM) REFERENCES LOAI_SAN_PHAM (MA_LOAI_SAN_PHAM);
ALTER TABLE GIO_HANG
ADD FOREIGN KEY (MA_KH) REFERENCES KHACH_HANG (MA_KH);
ALTER TABLE GIO_HANG
ADD FOREIGN KEY (MA_NV_DUYET) REFERENCES NHAN_VIEN (MA_NV);
ALTER TABLE GIO_HANG
ADD FOREIGN KEY (MA_NV_GIAO_HANG) REFERENCES NHAN_VIEN (MA_NV);
ALTER TABLE CHI_TIET_GH
ADD FOREIGN KEY (SO_HD) REFERENCES GIO_HANG (SO_HD);
-- chèn dữ liệu loai san pham 3 --
INSERT INTO LOAI_SAN_PHAM (MA_LOAI_SAN_PHAM)
VALUES ('Acoustic');
INSERT INTO LOAI_SAN_PHAM (MA_LOAI_SAN_PHAM)
VALUES ('Classic');
INSERT INTO LOAI_SAN_PHAM (MA_LOAI_SAN_PHAM)
VALUES ('Electric');
-- chèn dữ liệu san pham 20-- 
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP001', 'Đàn guitar acoustic', 'Đàn guitar acoustic chất lượng cao, âm thanh ấm, phù hợp với nhiều phong cách chơi nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/epiphone-hummingbird-guitar-01_1024x1024.jpg?v=1646331718', 12000000, 'Acoustic');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP002', 'Đàn guitar classic Yamaha F310', 'Đàn guitar classic chất lượng cao, âm thanh hay, phù hợp với người mới bắt đầu.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/guitar-classic-yamaha-f310_1024x1024.jpg?v=1646331718', 7000000, 'Classic');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP004', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP005', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP006', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP007', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP008', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP009', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP010', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP011', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP012', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP013', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP014', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP015', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP016', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP017', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP018', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP019', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP020', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP021', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP022', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP023', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP024', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP025', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP026', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP027', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP028', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP029', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)
VALUES ('SP030', 'Đàn guitar điện Fender Stratocaster', 'Đàn guitar điện nổi tiếng, âm thanh mạnh mẽ, phù hợp với nhiều thể loại nhạc.', 'Chiếc', 'https://cdn.shopify.com/s/files/1/0023/0196/7052/products/fender-stratocaster-guitar_1024x1024.jpg?v=1646331718', 20000000, 'Electric');
INSERT INTO SAN_PHAM (MA_SP, TEN_SP, MO_TA_SAN_PHAM, DON_VI_TINH, ANH_SAN_PHAM, DON_GIA, MA_LOAI_SAN_PHAM)

--	chèn dữ liệu KH 10 -- 
select DON_VI_TINH
from SAN_PHAM
INSERT INTO KHACH_HANG (MA_KH, HO_TEN, EMAIL, SO_DIEN_THOAI, DIA_CHI, MAT_KHAU)
VALUES ('KH001', 'Nguyễn Văn A', 'nguyenvana@gmail.com', '0912345678', 'Hà Nội', '123456789');
INSERT INTO KHACH_HANG (MA_KH, HO_TEN, EMAIL, SO_DIEN_THOAI, DIA_CHI, MAT_KHAU)
VALUES ('KH002', 'Trần Thị B', 'tranthib@gmail.com', '0923456789', 'Hồ Chí Minh', '987654321');
INSERT INTO KHACH_HANG (MA_KH, HO_TEN, EMAIL, SO_DIEN_THOAI, DIA_CHI, MAT_KHAU)
VALUES ('KH003', 'Lê Quang C', 'lequangc@gmail.com', '0934567890');
-- chèn dữ liệu nhan vien -- 
INSERT INTO NHAN_VIEN (MA_NV, HO_TEN_NV, SO_DIEN_THOAI, EMAIL, MAT_KHAU, QUYEN_SU_DUNG)
VALUES ('NV001', 'Nguyễn Văn A', '0912345678', 'nguyenvana@gmail.com', '123456789', 1);
INSERT INTO NHAN_VIEN (MA_NV, HO_TEN_NV, SO_DIEN_THOAI, EMAIL, MAT_KHAU, QUYEN_SU_DUNG)
VALUES ('NV002', 'Nguyễn Văn B', '0912345679', 'nguyenvanb@gmail.com', '123456788', 2);
INSERT INTO NHAN_VIEN (MA_NV, HO_TEN_NV, SO_DIEN_THOAI, EMAIL, MAT_KHAU, QUYEN_SU_DUNG)
VALUES ('NV003', 'Nguyễn Văn C', '0912345677', 'nguyenvanc@gmail.com', '123456787', 3);
-- chèn dữ liệu giỏ hàng 10 -- 
INSERT INTO GIO_HANG (SO_HD, NGAY_DAT_HANG, NGAY_GIAO_HANG, MA_KH, MA_NV_DUYET, MA_NV_GIAO_HANG, TINH_TRANG)
VALUES (1, '2023-07-22 12:00:00', NULL, 'KH001', NULL, NULL, 1);
INSERT INTO GIO_HANG (SO_HD, NGAY_DAT_HANG, NGAY_GIAO_HANG, MA_KH, MA_NV_DUYET, MA_NV_GIAO_HANG, TINH_TRANG)
VALUES (2, '2023-07-23 11:00:00', NULL, 'KH002', NULL, NULL, 1);
INSERT INTO GIO_HANG (SO_HD, NGAY_DAT_HANG, NGAY_GIAO_HANG, MA_KH, MA_NV_DUYET, MA_NV_GIAO_HANG, TINH_TRANG)
VALUES (3, '2023-07-24 10:00:00', NULL, 'KH003', NULL, NULL, 1);
-- chèn dữ liệu chi tiết giỏ hàng 30 -- 
INSERT INTO CHI_TIET_GH (SO_HD, MA_SP, SO_LUONG, ĐON_GIA_BAN)
VALUES (1, 'SP001', 2, 12000000);
INSERT INTO CHI_TIET_GH (SO_HD, MA_SP, SO_LUONG, ĐON_GIA_BAN)
VALUES (2, 'SP002', 2, 12000000);
INSERT INTO CHI_TIET_GH (SO_HD, MA_SP, SO_LUONG, ĐON_GIA_BAN)
VALUES (3, 'SP003', 2, 12000000);