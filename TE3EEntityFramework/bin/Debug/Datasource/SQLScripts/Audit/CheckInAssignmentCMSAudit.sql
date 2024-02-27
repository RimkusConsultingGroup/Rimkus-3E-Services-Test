select
      [E3EID]
      ,[KenticoID]
      ,[MatterIndex]
      ,[MatterNumber]
      ,[MatterName]
      ,[ClientIndex]
      ,[ClientNumber]
      ,[ClientName]
  from [@server].[@instance].[dbo].[InAssignmentsCMSAudit]
  where E3EID = @E3EID
  and KenticoID = '@KenticoID'