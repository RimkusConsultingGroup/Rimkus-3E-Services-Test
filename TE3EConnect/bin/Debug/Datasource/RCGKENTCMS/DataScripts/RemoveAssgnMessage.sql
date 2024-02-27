
DECLARE @numOfAttempts int

SELECT @numOfAttempts =  NumOfAttempts
FROM [@server].[@instance].[dbo].[CMSAssignments]
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

SET @numOfAttempts = @numOfAttempts + 1

UPDATE [@server].[@instance].[dbo].[CMSAssignments]
SET IsProcessed = 1,
ProcessedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

DELETE FROM [@server].[@instance].[dbo].[CMSAssignments]
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

UPDATE [@server].[@instance].[dbo].[CMSOrderingClients]
SET IsProcessed = 1,
ProcessedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

DELETE FROM [@server].[@instance].[dbo].[CMSOrderingClients]
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

UPDATE [@server].[@instance].[dbo].[CMSIncidentLocations]
SET IsProcessed = 1,
ProcessedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

DELETE FROM [@server].[@instance].[dbo].[CMSIncidentLocations]
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

UPDATE [@server].[@instance].[dbo].[CMSPayorDetails]
SET IsProcessed = 1,
ProcessedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

DELETE FROM [@server].[@instance].[dbo].[CMSPayorDetails]
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

UPDATE [@server].[@instance].[dbo].[CMSAdditionalParties]
SET IsProcessed = 1,
ProcessedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

DELETE FROM [@server].[@instance].[dbo].[CMSAdditionalParties]
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

UPDATE [@server].[@instance].[dbo].[CMSCoConsultants]
SET IsProcessed = 1,
ProcessedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

DELETE FROM [@server].[@instance].[dbo].[CMSCoConsultants]
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'