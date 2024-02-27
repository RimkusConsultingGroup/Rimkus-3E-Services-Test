select 
MattIndex,
Number [MattNumber],
DisplayName [MattName],
convert(nvarchar(max), LastProcItemID) [LastProcItemID],
convert(nvarchar(max), OrigProcItemID) [OrigProcItemID]
from [@server].[@instance].[dbo].[Matter]
where MattIndex = @mattIndex