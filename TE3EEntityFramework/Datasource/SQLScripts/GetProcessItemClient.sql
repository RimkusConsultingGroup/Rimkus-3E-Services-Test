select 
c.ClientIndex, 
c.Number [ClientNumber], 
c.DisplayName [ClientName], 
p.PayorIndex
from [@server].[@instance].[dbo].[Client] c
inner join [@server].[@instance].[dbo].[Payor] p on p.Client = c.ClientIndex
where 
convert(nvarchar(max), c.LastProcItemID) in (@clientProcessItemId)
or convert(nvarchar(max), c.OrigProcItemID) in (@clientProcessItemId) 
or c.Number = @clientNum
