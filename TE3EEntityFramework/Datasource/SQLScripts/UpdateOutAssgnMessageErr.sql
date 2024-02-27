DECLARE @numOfAttempts int

SELECT @numOfAttempts =  NumOfAttempts
FROM [@server].[@instance].[dbo].[OutAssignmentsCMS]
WHERE KenticoID = '@kenticoID'

SET @numOfAttempts = @numOfAttempts + 1

UPDATE [@server].[@instance].[dbo].[OutAssignmentsCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[OutOrderingClientsCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[OutIncidentLocationsCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[OutPayorDetailsCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[OutAdditionalPartiesCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

UPDATE [@server].[@instance].[dbo].[OutCoConsultantsCMS]
SET [ErrorMsg] = '@errMsg',
NumOfAttempts = @numOfAttempts
WHERE KenticoID = '@kenticoID'

