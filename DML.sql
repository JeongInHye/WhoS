select * from Client;
select * from Product;
select * from Location;

--적재 정보 1~36까지 데이터 넣기
DECLARE @count INT
SET @count = 1
WHILE @count <= 36
BEGIN
	INSERT INTO Location (lNum) VALUES (@count);
	SET @count = @count+1
END


INSERT INTO Product (cNo,pNum,pName,pWeight,EnterDate,OutDate) VALUES (1,'1','물품명','2kg',CONVERT(CHAR(10), '2019-03-12', 23),CONVERT(CHAR(10), '2019-03-13', 23));
INSERT INTO Product (cNo,lNo,pNum,pName,pWeight,EnterDate,OutDate,EnterCom) VALUES (2,2,'2','a','1kg',CONVERT(CHAR(10), '2019-03-11', 23),CONVERT(CHAR(10), '2019-03-20', 23),'Y');
INSERT INTO Product (cNo,pNum,pName,pWeight,EnterDate,OutDate) VALUES (2,'2','b','2kg',CONVERT(CHAR(10), '2019-03-12', 23),CONVERT(CHAR(10), '2019-03-15', 23));

SELECT CONVERT(CHAR(10), GETDATE(), 23) AS 날짜

select cName,pName,pWeight,pNum,EnterCom,OutCom from Client inner join Product on Client.cNo = Product.cNo where EnterDate = '2019-03-12' or OutDate = '2019-03-13';