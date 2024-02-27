
DECLARE @numOfAttempts int

SELECT @numOfAttempts =  NumOfAttempts
FROM [@server].[@instance].[dbo].[CMSCustomerProfile]
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType'

SET @numOfAttempts = @numOfAttempts + 1

UPDATE [@server].[@instance].[dbo].[CMSCustomerProfile]
SET IsProcessed = 1,
ProcessedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType'

DELETE FROM [@server].[@instance].[dbo].[CMSCustomerProfile]
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType'

