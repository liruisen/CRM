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
	gender bit default(0) ,		--0����Ů
	_address nvarchar(32),
	phone char(11),
	emaile varchar(32),
	birthday datetime,
	company nvarchar(16),
	title nvarchar(8),
	photoUrl varchar(32),
	empId int ,
	isDel bit default(0)  --0��ʾδɾ����1��ʾ��ɾ������ɾ��
)


--�����֤
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


insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('������',1,'����','11111111111','123456789@qq.com','1930-5-9','����','��ͳ',null,1,0)
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('�ȶ��Ǵ�',1,'����ͼ','11111111111','123456789@qq.com','1930-5-9','����','ǰ���ܲ�',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('���˼',1,'�¹�','11111111111','123456789@qq.com','1930-5-9','�¹�','˼���',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('ϰ��ƽ',1,'����','11111111111','123456789@qq.com','1930-5-9','�й�','������ϯ',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('���Ȼ�',1,'����','11111111111','123456789@qq.com','1930-5-9','����','ǰ��ͳ',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('�����',1,'�й�','11111111111','123456789@qq.com','1930-5-9','���μ�','�����ʥ',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('��ɮ',1,'�й�','11111111111','123456789@qq.com','1930-5-9','���μ�','���·�',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('��˽�',1,'�й�','11111111111','123456789@qq.com','1930-5-9','���μ�','��̳ʹ��',null,1,0) 
insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values('ɳ��',1,'�й�','11111111111','123456789@qq.com','1930-5-9','���μ�','�����޺�',null,1,0) 

























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