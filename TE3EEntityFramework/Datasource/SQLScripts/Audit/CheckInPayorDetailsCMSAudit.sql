select
      [E3EID]
      ,[KenticoID]
      ,[MatterIndex]
      ,[MatterNumber]
      ,[ClientIndex]
      ,[ClientName]
  from [@server].[@instance].[dbo].[InPayorDetailsCMSAudit]
  where [E3EID] = @E3EID
  and [KenticoID] = '@KenticoID'