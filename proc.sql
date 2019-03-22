-----------------------WinForm proc-------------------------
------------------------------------------------------------
------------------------------------------------------------�������� ���� �ŷ�ó �������
create PROCEDURE sp_ClientSelect
AS
select cNo,cName,cPName,cCall,cAddress from Client where delYn='N';

exec sp_ClientSelect;
------------------------------------------------------------�ŷ�ó �߰�
create PROCEDURE sp_ClientAdd(@cName varchar(30), @cPName varchar(30),@cCall varchar(20),@cAddress varchar(50),@cID varchar(20),@cPassword varchar(20))
as
begin
	INSERT INTO Client (cName,cPName,cCall,cAddress,cID,cPassword) VALUES (@cName,@cPName,@cCall,@cAddress,@cID,@cPassword);
end

exec sp_ClientAdd '����','������','01045671234','����Ư����','root','1234';
-----------------------------------------------------------------------------------�ŷ�ó ���� Ŭ���� form�ȿ� ����
create procedure sp_ClientEditSelect(@cNo int)
as
begin
	select cName,cPName,cCall,cAddress,cID,cPassword from Client where cNo=@cNo;
end

exec sp_ClientEditSelect 2;
-----------------------------------------------------------------------------------�ŷ�ó ����
create PROCEDURE sp_ClientEdit(@cNo int,@cName varchar(30), @cPName varchar(30),@cCall varchar(20),@cAddress varchar(50),@cID varchar(20),@cPassword varchar(20))
as
begin
	UPDATE Client SET cName=@cName,cPName=@cPName,cCall=@cCall,cAddress=@cAddress,cID=@cID,cPassword=@cPassword WHERE cNo=@cNo;
end

exec sp_ClientEdit 2,'�׽�Ʈ','��ǥ','010','�ּ�','id','1234';
-----------------------------------------------------------------------------------�ŷ�ó ����
create procedure sp_ClientDelete(@cNo int)
as
begin
	update Client set delYn='Y' where cNo=@cNo;
end

exec sp_ClientDelete 1;
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------����ȭ�� listview
create procedure sp_MainSelect(@date datetime)
as
begin
	select '',cName,pName,pWeight,pNum,EnterCom,OutCom from Client inner join Product on Client.cNo = Product.cNo where EnterDate = @date or OutDate = @date;

end

exec sp_MainSelect '2019-03-13';
select * from Product;
----------------------------------------------------------------------------------����ȭ�� textbox ��ȸ (�ŷ�ó�̸�, �����ȣ)
create procedure sp_MainSelectNum(@pNum varchar(10),@cName varchar(30))
as
begin
	select '',cName,pName,pWeight,pNum,EnterCom,OutCom from Client inner join Product on Client.cNo = Product.cNo where pNum = @pNum or cName = @cName;
end

exec sp_MainSelectNum '1','c��������j';
----------------------------------------------------------------------------------�������� ���� �ŷ�ó �̸� �ҷ�����
create procedure sp_ClientName
as
begin
	select '',cName from Client where delYn='N';
end

exec sp_ClientName;
----------------------------------------------------------------------------------�԰� ��ü����
create procedure sp_EnterAllSelect
as
begin
	select '',cName,pName,pWeight,EnterDate,pNum from Client inner join Product on Client.cNo = Product.cNo where Product.EnterCom='N' and Client.delYn='N';
end

exec sp_EnterAllSelect;
----------------------------------------------------------------------------------�԰� -> �ŷ�ó�̸� �����ϸ� ���� �ҷ�����
create procedure sp_EnterClientNameSelect(@cName varchar(30))
as
begin
	select '',cName,pName,pWeight,EnterDate,pNum from Client inner join Product on Client.cNo = Product.cNo where Product.EnterCom='N' and Client.delYn='N' and cName = @cName;
end

exec sp_EnterClientNameSelect 'cj';
----------------------------------------------------------------------------------��� ��ü����
create procedure sp_OutAllSelect
as
begin
	select '',cName,pName,pWeight,OutDate,pNum from Client inner join Product on Client.cNo = Product.cNo where Product.EnterCom='Y' and Client.delYn='N' and Product.OutCom='N';
end

exec sp_OutAllSelect;
----------------------------------------------------------------------------------�԰� �����ȣ ��ȸ��
create procedure sp_EnterSelectNum(@pNum int)
as
begin
	select '',cName,pName,pWeight,EnterDate,pNum from Client inner join Product on Client.cNo = Product.cNo where Product.EnterCom='N' and pNum = @pNum;
end

exec sp_EnterSelectNum 3;
----------------------------------------------------------------------------------��� -> �ŷ�ó �̸� �����ϸ� ���� �ҷ�����
create procedure sp_OutClientNameSelect(@cName varchar(30))
as
begin
	select '',cName,pName,pWeight,OutDate,pNum from Client inner join Product on Client.cNo = Product.cNo where Product.EnterCom='Y' and Product.OutCom='N' and cName = @cName;
end

exec sp_OutClientNameSelect 'cj';
----------------------------------------------------------------------------------��� �����ȣ ��ȸ��
create procedure sp_OutSelectNum(@pNum int)
as
begin
	select '',cName,pName,pWeight,OutDate,pNum from Client inner join Product on Client.cNo = Product.cNo where Product.EnterCom='Y' and Product.OutCom='N' and pNum = @pNum;
end
----------------------------------------------------------------------------------�԰��Ͽ��� �����ȣ�������� ������ġ�� �߰�
create procedure sp_LocationAdd(@pNum int,@lNo int)
as
begin
	update Product set lNo = @lNo,EnterCom='Y' where pNum = @pNum;
end
----------------------------------------------------------------------------------��� �Ϸ�
create procedure sp_OutCom(@pNum int)
as
begin
	update Product set OutCom = 'Y' where pNum = @pNum;
end
----------------------------------------------------------------------------------��ü ��������
create procedure sp_LocationAllSelect
as
begin
	select '',cName,pName,EnterDate,OutDate,lNo from Product inner join Client on Client.cNo = Product.cNo where EnterCom='Y' and OutCom = 'N';
end
----------------------------------------------------------------------------------�����ư Ŭ����
create procedure sp_LocationBtn(@lNo varchar(10))
as
begin
	select '',cName,pName,EnterDate,OutDate,lNo from Product inner join Client on Client.cNo = Product.cNo where EnterCom='Y' and OutCom = 'N' and lNo = @lNo;
end

exec sp_LocationBtn '2';
----------------------------------------------------------------------------------���� ��ġ �������
create procedure sp_Location
as
begin
	select DISTINCT lNo from Product where lNo is not null and OutCom = 'N';
end

exec sp_Location