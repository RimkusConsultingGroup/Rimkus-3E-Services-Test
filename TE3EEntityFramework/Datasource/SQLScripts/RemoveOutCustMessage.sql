DECLARE @numOfAttempts int

SELECT @numOfAttempts =  NumOfAttempts
FROM [@server].[@instance].[dbo].[OutCustomerProfileCMS]
WHERE ClientNumber = @clientNumber

SET @numOfAttempts = @numOfAttempts + 1

UPDATE [@server].[@instance].[dbo].[OutCustomerProfileCMS]
SET IsExported = 1,
ExportedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE ClientNumber = @clientNumber

DELETE FROM [@server].[@instance].[dbo].[OutCustomerProfileCMS]
WHERE ClientNumber = @clientNumber



