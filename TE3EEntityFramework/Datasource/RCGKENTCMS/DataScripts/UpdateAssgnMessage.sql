DECLARE @numOfAttempts int

SELECT TOP 1 @numOfAttempts =  NumOfAttempts
FROM [@server].[@instance].[dbo].[CMSAssignments]
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'


IF @numOfAttempts IS NULL OR @numOfAttempts = ''
BEGIN
SET @numOfAttempts = 0
END

SET @numOfAttempts = @numOfAttempts + 1

UPDATE [@server].[@instance].[dbo].[CMSAssignments]
SET [ProcessedDate] = '@processedDate',
[IsProcessed] = 1,
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

UPDATE [@server].[@instance].[dbo].[CMSOrderingClients]
SET [ProcessedDate] = '@processedDate',
[IsProcessed] = 1,
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

UPDATE [@server].[@instance].[dbo].[CMSIncidentLocations]
SET [ProcessedDate] = '@processedDate',
[IsProcessed] = 1,
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

UPDATE [@server].[@instance].[dbo].[CMSPayorDetails]
SET [ProcessedDate] = '@processedDate',
[IsProcessed] = 1,
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

UPDATE [@server].[@instance].[dbo].[CMSAdditionalParties]
SET [ProcessedDate] = '@processedDate',
[IsProcessed] = 1,
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'

UPDATE [@server].[@instance].[dbo].[CMSCoConsultants]
SET [ProcessedDate] = '@processedDate',
[IsProcessed] = 1,
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID' and QueueType = '@queueType' and TimeStamp = '@timeStamp'
