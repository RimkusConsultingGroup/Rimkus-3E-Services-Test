select
      [KenticoID]
      ,[CustomerID]
      ,[Email]
  from [@server].[@instance].[dbo].[InCustomerProfileCMSAudit]
  where [CustomerID] = @CustomerID
  and [KenticoID] = '@KenticoID'