select
      [E3EID]
      ,[KenticoID]
      ,[MatterIndex]
      ,[MatterName]
  from [@server].[@instance].[dbo].[InCoConsultantsCMS]
  where [E3EID] = @E3EID
  and [KenticoID] = '@KenticoID'