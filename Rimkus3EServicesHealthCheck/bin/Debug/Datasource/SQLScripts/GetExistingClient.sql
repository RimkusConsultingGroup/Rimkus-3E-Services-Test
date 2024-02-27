select 
c.Entity [EntIndex],
c.ClientIndex,
c.Number [ClientNumber],
c.DisplayName [ClientName],
convert(nvarchar(max), c.LastProcItemID) [LastProcItemID],
convert(nvarchar(max), c.OrigProcItemID) [OrigProcItemID],
se.EmailAddr [EmailAddress],
cst.Description [Status],
a.Street,
a.City,
a.State,
a.ZipCode,
a.Country,
c.TimeStamp
from [@server].[@instance].[dbo].[Client] c
inner join [@server].[@instance].[dbo].[Entity] e on e.EntIndex = c.Entity
inner join [@server].[@instance].[dbo].[Site] s on s.SiteIndex = c.InvoiceSite
inner join [@server].[@instance].[dbo].[Address] a on a.AddrIndex = s.Address
inner join [@server].[@instance].[dbo].[CliStatusType] cst on cst.Code = c.CliStatusType
inner join [@server].[@instance].[dbo].[SiteEmail] se on (se.Site=s.SiteIndex)
where 
c.CliStatusType = '100' and (c.displayname = '@clientName'
or c.Number = '@clientNumber')
order by c.TimeStamp