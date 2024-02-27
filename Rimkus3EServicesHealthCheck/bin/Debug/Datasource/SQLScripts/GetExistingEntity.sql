
select 
EntIndex, 
DisplayName [EntName],
EntityType,
convert(nvarchar(max), LastProcItemID) [LastProcItemID],
convert(nvarchar(max), OrigProcItemID) [OrigProcItemID]
from [@server].[@instance].[dbo].[Entity]
where ArchetypeCode = '@archetypeCode' -- EntityOrg, EntityPerson
and DisplayName = '@displayName'