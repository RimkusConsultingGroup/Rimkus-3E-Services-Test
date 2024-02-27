select
      [E3EID]
      ,[KenticoID]
      ,[MatterIndex]
      ,[MatterNumber]
      ,[MatterName]
      ,[PartyName]
      ,[EntIndex]
  from [@server].[@instance].[dbo].[InAdditionalPartiesCMSAudit]
  where E3EID = @E3EID
  and KenticoID = '@KenticoID'