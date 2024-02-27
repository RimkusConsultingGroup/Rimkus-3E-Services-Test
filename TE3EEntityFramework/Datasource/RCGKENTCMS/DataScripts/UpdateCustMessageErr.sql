DECLARE @numOfAttempts int

SELECT TOP 1 @numOfAttempts =  NumOfAttempts
FROM [@server].[@instance].[dbo].[CMSCustomerProfile]
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType'

IF @numOfAttempts IS NULL OR @numOfAttempts = ''
BEGIN
SET @numOfAttempts = 0
END

SET @numOfAttempts = @numOfAttempts + 1

UPDATE [@server].[@instance].[dbo].[CMSCustomerProfile]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType'
