
DECLARE @numOfAttempts int

SELECT @numOfAttempts =  NumOfAttempts
FROM [@server].[@instance].[dbo].[InAssignmentsCMS]
WHERE KenticoID = '@kenticoID'

SET @numOfAttempts = @numOfAttempts + 1

UPDATE [@server].[@instance].[dbo].[InAssignmentsCMS]
SET IsImported = 1,
ImportedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

DELETE FROM [@server].[@instance].[dbo].[InAssignmentsCMS]
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[InOrderingClientsCMS]
SET IsImported = 1,
ImportedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

DELETE FROM [@server].[@instance].[dbo].[InOrderingClientsCMS]
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[InIncidentLocationsCMS]
SET IsImported = 1,
ImportedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

DELETE FROM [@server].[@instance].[dbo].[InIncidentLocationsCMS]
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[InPayorDetailsCMS]
SET IsImported = 1,
ImportedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

DELETE FROM [@server].[@instance].[dbo].[InPayorDetailsCMS]
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[InAdditionalPartiesCMS]
SET IsImported = 1,
ImportedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

DELETE FROM [@server].[@instance].[dbo].[InAdditionalPartiesCMS]
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[InCoConsultantsCMS]
SET IsImported = 1,
ImportedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

DELETE FROM [@server].[@instance].[dbo].[InCoConsultantsCMS]
WHERE KenticoID = '@kenticoID'