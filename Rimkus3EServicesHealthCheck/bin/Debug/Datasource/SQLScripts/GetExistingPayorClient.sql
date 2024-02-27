select 
p.DisplayName [PayorName],
p.PayorIndex [PayorIndex],
c.DisplayName [ClientName], 
c.Number [ClientNumber],
c.ClientIndex,
convert(nvarchar(max), c.LastProcItemID) [LastProcItemID],
convert(nvarchar(max), c.OrigProcItemID) [OrigProcItemID]
from [@server].[@instance].[dbo].[Payor] p
inner join [@server].[@instance].[dbo].[Client] c on c.ClientIndex = p.Client
where p.PayorIndex = @payorIndex