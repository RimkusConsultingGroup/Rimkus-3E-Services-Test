﻿select distinct 
e.EntIndex, 
e.DisplayName [EntName],
e.EntityType,
convert(nvarchar(max), e.LastProcItemID) [LastProcItemID],
convert(nvarchar(max), e.OrigProcItemID) [OrigProcItemID],
convert(nvarchar(max), re.RelIndex) [RelateID],
convert(nvarchar(max), s.SiteIndex) [SiteID],
convert(nvarchar(max), se.SiteEmailID) [SiteEmailID],
addr.Street
from [@server].[@instance].[dbo].[Entity] e 
--left join [@server].[@instance].[dbo].[RelatedParties_CCC] relParties on relParties.Entity = e.EntIndex
left join [@server].[@instance].[dbo].[Relate] re on (re.SbjEntity=e.EntIndex and re.IsDefault=1)
left join [@server].[@instance].[dbo].[Site] s on (s.Relate=re.RelIndex)
left join [@server].[@instance].[dbo].[Address] addr on addr.AddrIndex = s.Address
left join [@server].[@instance].[dbo].[SiteEmail] se on (se.Site=s.SiteIndex)
where 
e.EntIndex = @entityID