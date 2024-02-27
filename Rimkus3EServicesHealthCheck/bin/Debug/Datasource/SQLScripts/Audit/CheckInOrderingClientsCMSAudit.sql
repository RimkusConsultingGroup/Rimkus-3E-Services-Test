select
      [E3EID]
      ,[KenticoID]
      ,[MatterIndex]
      ,[MatterNumber]
      ,[MatterName]
      ,[OrderClientIndex]
      ,[OrderClientCompanyName]
  from [@server].[@instance].[dbo].[InOrderingClientsCMSAudit]
  where [E3EID] = @E3EID
  and [KenticoID] = '@KenticoID'