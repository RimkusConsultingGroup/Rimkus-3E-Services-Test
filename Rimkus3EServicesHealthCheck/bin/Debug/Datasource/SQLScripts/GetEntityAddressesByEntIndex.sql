select 
e.EntIndex,
e.DisplayName,
e.EntityType [EntityTypeCode],
et.Description [EntityTypeDesc],
s.SiteType [SiteTypeCode],
st.Description [SiteTypeDesc],
a.Street,
a.City,
a.State,
a.ZipCode,
a.Country,
e.TimeStamp
from [@server].[@instance].[dbo].[Entity] e 
inner join [@server].[@instance].[dbo].[Site] s on s.Relate = e.EntIndex
inner join  [@server].[@instance].[dbo].[Address] a on a.AddrIndex = s.Address
inner join [@server].[@instance].[dbo].[EntityType] et on et.Code = e.EntityType
inner join [@server].[@instance].[dbo].[SiteType] st on st.Code = s.SiteType
where e.EntIndex = @entityID
order by st.Code 