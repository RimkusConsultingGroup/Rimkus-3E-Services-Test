select 
m.MattIndex, 
m.Number [MattNumber], 
m.DisplayName [MattName]
from [@server].[@instance].[dbo].[Matter] m
where 
convert(nvarchar(max), m.LastProcItemID) = '@matterProcessItemId'
or convert(nvarchar(max), m.OrigProcItemID) = '@matterProcessItemId'