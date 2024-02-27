DECLARE @numOfAttempts int

SELECT @numOfAttempts =  NumOfAttempts
FROM [@server].[@instance].[dbo].[InCustomerProfileCMS]
WHERE KenticoID = '@kenticoID'

SET @numOfAttempts = @numOfAttempts + 1

UPDATE [@server].[@instance].[dbo].[InCustomerProfileCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'
