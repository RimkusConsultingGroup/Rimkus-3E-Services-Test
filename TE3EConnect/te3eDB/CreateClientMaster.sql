
drop table ClientMaster

CREATE TABLE ClientMaster
(
  ClientKeyId INT PRIMARY KEY IDENTITY,
  AppId VARCHAR(500),
  AppKey VARCHAR(500),
  ClientName VARCHAR(100),
  CreatedOn DateTime
)
GO
-- Populate the ClientMaster with test data
 INSERT INTO ClientMaster(AppId, AppKey, ClientName, CreatedOn) 
 VALUES('0233DEF9-F678-4B2C-BCB7-5BF952745D13', 'A93reRTUJHsCuQSHR+L3GxqOJyDmQpCgps102ciuabc=', 'CPCUser', GETDATE())