select
      [E3EID]
      ,[KenticoID]
      ,[MatterIndex]
      ,[MatterNumber]
      ,[MatterName]
  from [@server].[@instance].[dbo].[InIncidentLocationsCMSAudit]
  where [E3EID] = @E3EID
  and [KenticoID] = '@KenticoID'