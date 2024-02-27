select 
c.ClientIndex,
c.Number [ClientNumber],
m.MattIndex,
m.Number [MattNumber],
m.DisplayName [MattName]
from [@server].[@instance].[dbo].[Matter] m
inner join [@server].[@instance].[dbo].[Client] c on m.Client = c.ClientIndex
where m.MattIndex = @mattIndex -- 463611
and c.Number = '@clientNumber'
--and c.ClientIndex = @clientIndex -- 69469