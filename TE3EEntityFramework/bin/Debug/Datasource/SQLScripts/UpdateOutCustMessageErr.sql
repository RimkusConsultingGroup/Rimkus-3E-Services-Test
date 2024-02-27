DECLARE @numOfAttempts int

SELECT @numOfAttempts =  NumOfAttempts
FROM [@server].[@instance].[dbo].[OutCustomerProfileCMS]
WHERE ClientNumber = @clientNumber

SET @numOfAttempts = @numOfAttempts + 1

UPDATE [@server].[@instance].[dbo].[OutCustomerProfileCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE ClientNumber = @clientNumber