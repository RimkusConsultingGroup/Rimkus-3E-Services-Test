
DECLARE @numOfAttempts int

SELECT @numOfAttempts =  NumOfAttempts
FROM [@server].[@instance].[dbo].[InCustomerProfileCMS]
WHERE KenticoID = '@kenticoID'

SET @numOfAttempts = @numOfAttempts + 1

UPDATE [@server].[@instance].[dbo].[InCustomerProfileCMS]
SET IsImported = 1,
ImportedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

DELETE FROM [@server].[@instance].[dbo].[InCustomerProfileCMS]
WHERE KenticoID = '@kenticoID'

