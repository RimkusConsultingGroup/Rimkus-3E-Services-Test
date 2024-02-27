DECLARE @numOfAttempts int

SELECT @numOfAttempts =  NumOfAttempts
FROM [@server].[@instance].[dbo].[InAssignmentsCMS]
WHERE KenticoID = '@kenticoID'

SET @numOfAttempts = @numOfAttempts + 1

UPDATE [@server].[@instance].[dbo].[InAssignmentsCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[InOrderingClientsCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[InIncidentLocationsCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[InPayorDetailsCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[InAdditionalPartiesCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[InCoConsultantsCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'
