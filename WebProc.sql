---------------------Web Proc-------------------------------
------------------------------------------------------------
------------------------------------------------------------�α��μ������� ���ν���
create procedure sp_WebLogin(@id varchar(max),@pw varchar(max))
as
      SET NOCOUNT ON; -- ����� ��� x (��Ȯ�Ѱ� �ƴ�) ���̳ʽ��ΰ�
DECLARE @LogonResult BIT
SET @LogonResult = (SELECT pwdcompare(@pw,pwdencrypt(cPassword)) FROM Client WHERE cID = @id and delYn = 'N')
IF(@LogonResult = 1) -- #�����̸�
begin
   select cNo,cName,cPName from Client where cID = @id and cPassword = @pw
   return
end
ELSE
begin
   select '' as cNo, '' as cName, '' as cPName
   RETURN 
end
SET NOCOUNT OFF;

exec sp_WebLogin 'root','1234';
exec sp_WebLogin 'root','14';

select * from Client;
------------------------------------------------------------�ŷ�ó��ȣ �������� ������ insert (�����ȣ �ڵ� ����)
create PROCEDURE sp_AddProduct(@cNo varchar(10),@pName varchar(30),@pWeight varchar(10),@EnterDate datetime,@OutDate datetime)
as
declare @pNum int = 0
set @pNum = (select ISNULL( MAX(pNum),0) as pNum from Product)
if(@pNum = 0)
begin
	set @pNum = @pNum + 1
	INSERT INTO Product(cNo,pNum,pName,pWeight,EnterDate,OutDate) VALUES (@cNo,@pNum,@pName,@pWeight,@EnterDate,@OutDate);
end
else if(@pNum != 0)
begin
	set @pNum = @pNum + 1
	INSERT INTO Product(cNo,pNum,pName,pWeight,EnterDate,OutDate) VALUES (@cNo,@pNum,@pName,@pWeight,@EnterDate,@OutDate);
end

exec sp_AddProduct '1','��������','2g','2019-03-14','2019-03-20';


select * from Product;
drop table Product;
------------------------------------------------------------�ŷ�ó��ȣ �������� ���� ��Ȳ �������
create procedure sp_WebProductSelect(@cNo int)
as
begin
	select pName,pWeight,EnterDate,OutDate,pNum,EnterCom,OutCom from Product where cNo = @cNo order by case when EnterCom='N' then 1
																									 when EnterCom='Y' and outCom='N' then 2
																									 when EnterCom='Y' and OutCom='Y' then 3 end;
end

exec sp_WebProductSelect 1;
------------------------------------------------------------