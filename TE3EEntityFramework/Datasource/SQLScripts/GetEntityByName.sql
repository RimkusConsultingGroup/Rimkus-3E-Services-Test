select distinct
e.EntityType, 
et.Description [EntityTypeDesc], 
e.DisplayName [EntityName],
s.IsDefault,
e.EntIndex, 
s.SiteIndex, 
st.Code [OfficeType], 
st.Description [OfficeTypeDesc], 
a.Street,
a.[City] ,
a.[County] ,
a.[State] ,
a.[ZipCode] ,
a.[Country] ,
a.[Latitude] ,
a.[Longitude],
e.ArchetypeCode,
a.TimeStamp
from [@server].[@instance].[dbo].[Entity] e
inner join [@server].[@instance].[dbo].[Relate]  r on (r.SbjEntity=e.EntIndex and r.IsDefault=1)
left outer join [@server].[@instance].[dbo].[Site] s on (s.Relate=r.RelIndex)
left outer join [@server].[@instance].[dbo].[Address] a on (s.Address=a.AddrIndex)
inner join [@server].[@instance].[dbo].[SiteType] st on st.Code = s.SiteType
inner join [@server].[@instance].[dbo].[EntityType] et on et.Code = e.EntityType
left join [@server].[@instance].[dbo].[SiteEmail] se on (se.Site=s.SiteIndex)
where 
e.displayname = @companyName
