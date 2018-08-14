create database MyCRM

go

use MyCRM

go

create table Employees
(
	id int primary key identity(1,1),
	empNo nvarchar(8) not null unique,
	pwd varchar(64)
)

go

CREATE TABLE customers
(
	id int primary key identity(1,1),
	name nvarchar(4) not null,
	gender bit default(0) ,		--0代表女
	_address nvarchar(32),
	phone char(11),
	emaile varchar(32),
	birthday datetime,
	company nvarchar(16),
	title nvarchar(8),
	photoUrl varchar(32),
	empId int ,
	isDel bit default(0)  --0表示未删除，1表示已删除。软删除
)


--身份验证
create proc up_Validate
@empNo nvarchar(8),
@pwd varchar(64)
as
begin

	if(exists(select id from Employees where  empNo=@empNo and pwd=@pwd))

	begin
		select 1
	end

	else

	begin
			if(exists(select id from Employees where  empNo=@empNo ))

			begin

				select 0

			end

			else

			begin

				select -1

			end
	end

end

insert into Employees values('012','110')

select id ,name,gender,_address,phone,email,birthday,company,title,photoUrl,empId from Customers where empId=1

select * from Customers where MONTH(birthday)=MONTH(GETDATE()) and (DAY(birthday)-DAY(GETDATE())) in(1,2,3)


insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('特朗普',1,'美国','11111111111','123456789@qq.com','1930-5-9','美国','总统',null,1,0)
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('比尔盖茨',1,'西雅图','11111111111','123456789@qq.com','1930-5-9','美国','前任总裁',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('马克思',1,'德国','11111111111','123456789@qq.com','1930-5-9','德国','思想家',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('习近平',1,'北京','11111111111','123456789@qq.com','1930-5-9','中国','国家主席',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('朴槿惠',1,'韩国','11111111111','123456789@qq.com','1930-5-9','韩国','前总统',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('孙悟空',1,'中国','11111111111','123456789@qq.com','1930-5-9','西游记','齐天大圣',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('唐僧',1,'中国','11111111111','123456789@qq.com','1930-5-9','西游记','功德佛',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('猪八戒',1,'中国','11111111111','123456789@qq.com','1930-5-9','西游记','净坛使者',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('沙悟净',1,'中国','11111111111','123456789@qq.com','1930-5-9','西游记','金身罗汉',null,1,0) 

























create proc up_GetCustomersByPage
@pageSize int,
@currentPage int,
@totalpages int output

as
begin
	select top(@pageSize) * from Customers where id not in
	(select top(@pageSize*(@currentPage-1)) id from Customers order by id)
	declare @totalCounts int 
	select @totalCounts = COUNT(id) from Customers 
	set @totalpages=CEILING(@totalCounts *1.0/@pageSize)
	 
end



declare @totalPages int
exec up_GetCustomersByPage 6,2,@totalPages output
select @totalPages