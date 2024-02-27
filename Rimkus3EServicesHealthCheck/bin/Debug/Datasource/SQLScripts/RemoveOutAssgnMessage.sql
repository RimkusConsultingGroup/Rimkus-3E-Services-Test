DECLARE @numOfAttempts int

SELECT @numOfAttempts =  NumOfAttempts
FROM [@server].[@instance].[dbo].[OutAssignmentsCMS]
WHERE MatterIndex = @mattIndex

SET @numOfAttempts = @numOfAttempts + 1

UPDATE [@server].[@instance].[dbo].[OutAssignmentsCMS]
SET IsExported = 1,
ExportedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE MatterIndex = @mattIndex

DELETE FROM [@server].[@instance].[dbo].[OutAssignmentsCMS]
WHERE MatterIndex = @mattIndex

UPDATE [@server].[@instance].[dbo].[OutOrderingClientsCMS]
SET IsExported = 1,
ExportedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE MatterIndex = @mattIndex

DELETE FROM [@server].[@instance].[dbo].[OutOrderingClientsCMS]
WHERE MatterIndex = @mattIndex

UPDATE [@server].[@instance].[dbo].[OutIncidentLocationsCMS]
SET IsExported = 1,
ExportedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE MatterIndex = @mattIndex

DELETE FROM [@server].[@instance].[dbo].[OutIncidentLocationsCMS]
WHERE MatterIndex = @mattIndex

UPDATE [@server].[@instance].[dbo].[OutPayorDetailsCMS]
SET IsExported = 1,
ExportedDate = GETDATE(),
NumOfAttempts = @numOfAttempts
WHERE MatterIndex = @mattIndex

DELETE FROM [@server].[@instance].[dbo].[OutPayorDetailsCMS]
WHERE MatterIndex = @mattIndex

UPDATE [@server].[@instance].[dbo].[OutAdditionalPartiesCMS]
SET IsExported = 1,
ExportedDate = GETDATE(),
NumOfAttempts = @numOfAttempt
WHERE MatterIndex = @mattIndex

DELETE FROM [@server].[@instance].[dbo].[OutAdditionalPartiesCMS]
WHERE MatterIndex = @mattIndex

UPDATE [@server].[@instance].[dbo].[OutCoConsultantsCMS]
SET IsExported = 1,
ExportedDate = GETDATE(),
NumOfAttempts = @numOfAttempt
WHERE MatterIndex = @mattIndex

DELETE FROM [@server].[@instance].[dbo].[OutCoConsultantsCMS]
WHERE MatterIndex = @mattIndex

