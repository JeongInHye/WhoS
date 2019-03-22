--�ŷ�ó
create table Client(
	cNo int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	cName varchar(30) NOT NULL,
	cPName varchar(30) NOT NULL,
	cCall varchar(20) NOT NULL,
	cAddress varchar(50),
	cID varchar(20) NOT NULL,
	cPassword varchar(20) NOT NULL,
	delYn varchar(1) NOT NULL default 'N'
);

--��ǰ ���̺�
create table Product(
	pNo int identity(1,1) not null primary key,
	cNo int foreign key references Client(cNo),
	lNo int foreign key references Location(lno), --�����ȣ
	pNum varchar(10) not null,	-- �����ȣ
	pName varchar(30) not null,
	pWeight varchar(10) not null,
	EnterDate datetime not null,
	OutDate datetime not null,
	pNumSender varchar(30),
	EnterCom varchar(1) default 'N',
	OutCom varchar(1) default 'N',
	OutDateCom datetime default getDate()	
);

--������ġ
create table Location(
	lno int identity(1,1) not null primary key,
	lNum int not null,
	located varchar(1) not null default 'N'
);