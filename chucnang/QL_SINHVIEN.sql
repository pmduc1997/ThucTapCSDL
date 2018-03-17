Create database Quan_ly_sinh_vien
Use Quan_ly_sinh_vien
Create table Phan_quyen(
	Ma_phan_quyen char(10) Primary key,
	Ten_phan_quyen nvarchar(50),
	Mo_ta nvarchar(50)
)
Create table Nguoi_dung(
	Id_user char(10)Primary key,
	Username varchar(20) not null,
	Pass varchar(20) not null,
	Ma_phan_quyen char(10) References Phan_quyen(Ma_phan_quyen)
)
Create table Khoa(
	Ma_khoa char (10) Primary key,
	Ten_khoa nvarchar(50),
	Ma_cnkhoa char(10)
)
Create table Giao_vien(
	Ma_giao_vien char(10) Primary key,
	Ten_giao_vien nvarchar(50),
	Gioi_tinh bit,
	Hoc_vi nvarchar(30),
	Dia_chi nvarchar(50),
	Ma_khoa char(10) References Khoa(Ma_khoa)
)
Create table Lop(
	Ma_lop char(10) Primary key,
	Ten_lop nvarchar(50),
	Ma_khoa char(10) References Khoa(Ma_khoa),
	Ma_giaoviencn char(10) References Giao_vien(Ma_giao_vien)
)
Create table Hoc_ky(
	Ma_hoc_ky char(10) Primary key,
	Ten_hoc_ky nvarchar(30),
	Thoi_gian_bat_dau date,
	Thoi_gian_ket_thuc date,
	Ma_lop char(10) References Lop(Ma_lop)
)
Create table Hoc_phan(
	Ma_hoc_phan char(10) Primary key,
	Ten_hoc_phan nvarchar(30),
	So_tin_chi int,
	Ma_hoc_ky char(10) References Hoc_ky(Ma_hoc_ky)
)
Create table Lop_hoc_phan(
	Ma_lop_hoc_phan char(10) Primary key,
	Ma_hoc_phan char(10) References Hoc_phan(Ma_hoc_phan),
	Ma_giao_vien char(10) References Giao_vien(Ma_giao_vien),
	So_sv_toi_da int,
	Ngay_bat_dau date,
	Thoi_gian_hoc nvarchar(50),
	Giang_duong nvarchar(20),
	Ngay_ket_thuc date,
	Ngay_thi date,
	Hinh_thuc_thi nvarchar(30)
)
Create table Sinh_vien(
	Ma_sinh_vien char(10) Primary key,
	Ten_sinh_vien nvarchar(50),
	Ngay_sinh date,
	Gioi_tinh bit,
	Dia_chi nvarchar(50),
	Ma_lop char(10) References Lop(Ma_lop)
)
Create table Bang_diem(
	Ma_sinh_vien char(10) References Sinh_vien(Ma_sinh_vien),
	Ma_hoc_phan char(10) References Hoc_phan(Ma_hoc_phan),
	Diem_chuyen_can int,
	Diem_thuong_xuyen int,
	Diem_cuoi_ky int,
	Constraint SV_HP Primary key(Ma_sinh_vien,Ma_hoc_phan)
)
Create table Phieu_dang_ky(
	Ma_phieu char(10) Primary key,
	Ma_sinh_vien char(10) References Sinh_vien(Ma_sinh_vien),
	Ma_lop_hoc_phan char(10),
	Lan_dang_ky int
)
----------------------------
Create proc Them_khoa(@Ma_khoa char(10),@Ten_khoa nvarchar(50),@Ma_cnkhoa char(10))
as
Begin tran
	if not exists (select Ma_khoa from Khoa where Ma_khoa=@Ma_khoa)
		Begin
		Insert into Khoa(Ma_khoa,Ten_khoa,Ma_cnkhoa)
		Values(@Ma_khoa,@Ten_khoa,@Ma_cnkhoa)
		Commit tran
		End
	else
		Begin
		Print 'MA KHOA DA TON TAI !'
		Rollback tran
		End
Return
---
Exec Them_khoa 'K08','KHOA 8','GV020'
---
Create proc suakhoa(@Ma_khoa char(10),@Ten_khoa nvarchar(50),@Ma_cnkhoa char(10))
as
Begin tran
	if exists (select Ma_khoa from Khoa where Ma_khoa=@Ma_khoa)
		Begin
		Update Khoa
		Set Ten_khoa=@Ten_khoa,Ma_cnkhoa=@Ma_cnkhoa
		Where Ma_khoa=@Ma_khoa
		Commit tran
		End
	else
		Begin
		Print 'MA KHOA KHONG TON TAI !'
		Rollback tran
		End
Return
---
Create proc Them_giao_vien(@Ma_gv char(10),@Ten_gv nvarchar(50),@Gioi_tinh bit,@Hoc_vi nchar(30),@Dia_chi nvarchar(50),@Ma_khoa char(10))
as
Begin tran
	if not exists (select Ma_giao_vien from Giao_vien where Ma_giao_vien=@Ma_gv)
	Begin
		if exists (select Ma_khoa from Khoa where Ma_khoa=@Ma_khoa)
			Begin
			Insert into Giao_vien(Ma_giao_vien,Ten_giao_vien,Gioi_tinh,Hoc_vi,Dia_chi,Ma_khoa)
			Values(@Ma_gv,@Ten_gv,@Gioi_tinh,@Hoc_vi,@Dia_chi,@Ma_khoa)
			End
		else
			Begin
			Print 'MAKHOA KHONG TON TAI!'
			Rollback tran
			End
	End
	else
		Begin
		Print 'MA GIAO VIEN DA TON TAI!'
		Rollback tran
		End
Return
---
Exec Them_giao_vien 'GV026', 'Nguyễn Văn Bình','0','Hà Nội','K04'
---
Create proc Them_sinh_vien(@Ma_sinh_vien char(10),@Ten_sinh_vien nvarchar(50),@Ngay_sinh date,@Gioi_tinh bit,@Dia_chi nvarchar(50),@Ma_lop char(10))
as
Begin tran
	if not exists (select Ma_sinh_vien from Sinh_vien where Ma_sinh_vien=@Ma_sinh_vien)
		Begin
		Insert into Sinh_vien(Ma_sinh_vien,Ten_sinh_vien,Ngay_sinh,Gioi_tinh,Dia_chi,Ma_lop)
		Values(@Ma_sinh_vien,@Ten_sinh_vien,@Ngay_sinh,@Gioi_tinh,@Dia_chi,@Ma_lop)
		Commit tran
		End
	else
		Begin
		Print 'MA SINH VIEN DA TON TAI !'
		Rollback tran
		End
Return
---
Create proc Sua_sinh_vien(@Ma_sinh_vien char(10),@Ten_sinh_vien nvarchar(50),@Ngay_sinh date,@Gioi_tinh bit,@Dia_chi nvarchar(50),@Ma_lop char(10))
as
Begin tran
	if exists (select Ma_sinh_vien from Sinh_vien where Ma_sinh_vien=@Ma_sinh_vien)
		Begin
		Update Sinh_vien
		Set Ten_sinh_vien=@Ten_sinh_vien,Ngay_sinh=@Ngay_sinh,Gioi_tinh=@Gioi_tinh,Dia_chi=@Dia_chi,Ma_lop=@Ma_lop
		Where Ma_sinh_vien=@Ma_sinh_vien
		Commit tran
		End
	else
		Begin
		Print 'MA SINH VIEN KHONG TON TAI !'
		Rollback tran
		End
Return
---
Create proc Xoa_sinh_vien(@Ma_sinh_vien char(10))
as
Begin tran
	if exists (select Ma_sinh_vien FROM Sinh_vien where Ma_sinh_vien=@Ma_sinh_vien)
		Begin
		Delete from Bang_diem where(Ma_sinh_vien=@Ma_sinh_vien)
		Delete from Phieu_dang_ky where(Ma_sinh_vien=@Ma_sinh_vien)
		Delete from Sinh_vien where(Ma_sinh_vien=@Ma_sinh_vien)
		Commit tran
		End
	else
		Begin
		Print 'KHONG TON TAI MASV NAY !'
		Rollback tran
		End
Return
---
Create proc Them_bang_diem(@Ma_sinh_vien char(10),@Ma_hoc_phan char(10),@Diem1 int,@Diem2 int,@Diem3 int)
as
Begin tran
	if not exists (select Ma_sinh_vien from Bang_diem where Ma_sinh_vien=@Ma_sinh_vien)
		Begin
		Insert into Bang_diem(Ma_sinh_vien,Ma_hoc_phan,Diem_chuyen_can,Diem_thuong_xuyen,Diem_cuoi_ky)
		Values(@Ma_sinh_vien,@Ma_hoc_phan,@Diem1,@Diem2,@Diem3)
		Commit tran
		end
	else
		Begin
		Print 'MA SINH VIEN DA TON TAI !'
		Rollback tran
		End
Return
---
Create proc Sua_bang_diem(@Ma_sinh_vien char(10),@Ma_hoc_phan char(10),@Diem1 int,@Diem2 int,@Diem3 int)
as
Begin tran
	if exists (select Ma_sinh_vien from Bang_diem where Ma_sinh_vien=@Ma_sinh_vien)
		Begin
		Update Bang_diem
		Set Ma_hoc_phan=@Ma_hoc_phan,Diem_chuyen_can=@Diem1,Diem_thuong_xuyen=@Diem2,Diem_cuoi_ky=@Diem3
		Where Ma_sinh_vien=@Ma_sinh_vien 
		Commit tran
		End
	else
		Begin
		Print 'MA SINH VIEN KHONG TON TAI !'
		Rollback tran
		End
Return
---
Create proc Xoa_bang_diem(@Ma_sinh_vien char(10))
as
Begin tran
	if exists (select Ma_sinh_vien from Bang_diem where Ma_sinh_vien=@Ma_sinh_vien)
		Begin
		Delete Bang_diem where(Ma_sinh_vien=@Ma_sinh_vien)
		Commit tran
		End
	else
		Begin	
		Print 'KHONG TON TAI MASV NAY !'
		Rollback tran
		End
Return
