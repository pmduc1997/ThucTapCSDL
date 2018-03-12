create table tbl_user(
id_user char(10) primary key,
username varchar(40),
pass varchar(40)
)
create table permission(
id_per char(10) primary key,
name_per nvarchar(40),
des_per nvarchar(40)
)
create table relationship(
id_rel char(10) primary key,
id_user char(10) references tbl_user(id_user),
id_per char(10) references permission(id_per)
)
create table per_detail(
id_pd char(10) primary key,
code_action varchar(40),
id_per char(10) references permission(id_per)
)