-----------------------WinForm proc-------------------------
------------------------------------------------------------
------------------------------------------------------------삭제되지 않은 거래처 갖고오기
create PROCEDURE sp_ClientSelect
AS
select cNo,cName,cPName,cCall,cAddress from Client where delYn='N';

exec sp_ClientSelect;
------------------------------------------------------------거래처 추가
create PROCEDURE sp_ClientAdd(@cName varchar(30), @cPName varchar(30),@cCall varchar(20),@cAddress varchar(50),@cID varchar(20),@cPassword varchar(20))
as
begin
	INSERT INTO Client (cName,cPName,cCall,cAddress,cID,cPassword) VALUES (@cName,@cPName,@cCall,@cAddress,@cID,@cPassword);
end

exec sp_ClientAdd '구디','정인혜','01045671234','서울특별시','root','1234';
-----------------------------------------------------------------------------------거래처 수정 클릭시 form안에 정보
create procedure sp_ClientEditSelect(@cNo int)
as
begin
	select cName,cPName,cCall,cAddress,cID,cPassword from Client where cNo=@cNo;
end

exec sp_ClientEditSelect 2;
-----------------------------------------------------------------------------------거래처 수정
create PROCEDURE sp_ClientEdit(@cNo int,@cName varchar(30), @cPName varchar(30),@cCall varchar(20),@cAddress varchar(50),@cID varchar(20),@cPassword varchar(20))
as
begin
	UPDATE Client SET cName=@cName,cPName=@cPName,cCall=@cCall,cAddress=@cAddress,cID=@cID,cPassword=@cPassword WHERE cNo=@cNo;
end

exec sp_ClientEdit 2,'테스트','대표','010','주소','id','1234';
-----------------------------------------------------------------------------------거래처 삭제
create procedure sp_ClientDelete(@cNo int)
as
begin
	update Client set delYn='Y' where cNo=@cNo;
end

exec sp_ClientDelete 1;
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------메인화면 listview
create procedure sp_MainSelect(@date datetime)
as
begin
	select '',cName,pName,pWeight,pNum,EnterCom,OutCom from Client inner join Product on Client.cNo = Product.cNo where EnterDate = @date or OutDate = @date;

end

exec sp_MainSelect '2019-03-13';
select * from Product;
----------------------------------------------------------------------------------메인화면 textbox 조회 (거래처이름, 발행번호)
create procedure sp_MainSelectNum(@pNum varchar(10),@cName varchar(30))
as
begin
	select '',cName,pName,pWeight,pNum,EnterCom,OutCom from Client inner join Product on Client.cNo = Product.cNo where pNum = @pNum or cName = @cName;
end

exec sp_MainSelectNum '1','cㅁㄴㅇㄹj';
----------------------------------------------------------------------------------삭제되지 않은 거래처 이름 불러오기
create procedure sp_ClientName
as
begin
	select '',cName from Client where delYn='N';
end

exec sp_ClientName;
----------------------------------------------------------------------------------입고 전체정보
create procedure sp_EnterAllSelect
as
begin
	select '',cName,pName,pWeight,EnterDate,pNum from Client inner join Product on Client.cNo = Product.cNo where Product.EnterCom='N' and Client.delYn='N';
end

exec sp_EnterAllSelect;
----------------------------------------------------------------------------------입고 -> 거래처이름 선택하면 정보 불러오기
create procedure sp_EnterClientNameSelect(@cName varchar(30))
as
begin
	select '',cName,pName,pWeight,EnterDate,pNum from Client inner join Product on Client.cNo = Product.cNo where Product.EnterCom='N' and Client.delYn='N' and cName = @cName;
end

exec sp_EnterClientNameSelect 'cj';
----------------------------------------------------------------------------------출고 전체정보
create procedure sp_OutAllSelect
as
begin
	select '',cName,pName,pWeight,OutDate,pNum from Client inner join Product on Client.cNo = Product.cNo where Product.EnterCom='Y' and Client.delYn='N' and Product.OutCom='N';
end

exec sp_OutAllSelect;
----------------------------------------------------------------------------------입고 발행번호 조회시
create procedure sp_EnterSelectNum(@pNum int)
as
begin
	select '',cName,pName,pWeight,EnterDate,pNum from Client inner join Product on Client.cNo = Product.cNo where Product.EnterCom='N' and pNum = @pNum;
end

exec sp_EnterSelectNum 3;
----------------------------------------------------------------------------------출고 -> 거래처 이름 선택하면 정보 불러오기
create procedure sp_OutClientNameSelect(@cName varchar(30))
as
begin
	select '',cName,pName,pWeight,OutDate,pNum from Client inner join Product on Client.cNo = Product.cNo where Product.EnterCom='Y' and Product.OutCom='N' and cName = @cName;
end

exec sp_OutClientNameSelect 'cj';
----------------------------------------------------------------------------------출고 발행번호 조회시
create procedure sp_OutSelectNum(@pNum int)
as
begin
	select '',cName,pName,pWeight,OutDate,pNum from Client inner join Product on Client.cNo = Product.cNo where Product.EnterCom='Y' and Product.OutCom='N' and pNum = @pNum;
end
----------------------------------------------------------------------------------입고목록에서 발행번호기준으로 적재위치에 추가
create procedure sp_LocationAdd(@pNum int,@lNo int)
as
begin
	update Product set lNo = @lNo,EnterCom='Y' where pNum = @pNum;
end
----------------------------------------------------------------------------------출고 완료
create procedure sp_OutCom(@pNum int)
as
begin
	update Product set OutCom = 'Y' where pNum = @pNum;
end
----------------------------------------------------------------------------------전체 적재정보
create procedure sp_LocationAllSelect
as
begin
	select '',cName,pName,EnterDate,OutDate,lNo from Product inner join Client on Client.cNo = Product.cNo where EnterCom='Y' and OutCom = 'N';
end
----------------------------------------------------------------------------------적재버튼 클릭시
create procedure sp_LocationBtn(@lNo varchar(10))
as
begin
	select '',cName,pName,EnterDate,OutDate,lNo from Product inner join Client on Client.cNo = Product.cNo where EnterCom='Y' and OutCom = 'N' and lNo = @lNo;
end

exec sp_LocationBtn '2';
----------------------------------------------------------------------------------적재 위치 갖고오기
create procedure sp_Location
as
begin
	select DISTINCT lNo from Product where lNo is not null and OutCom = 'N';
end

exec sp_Location