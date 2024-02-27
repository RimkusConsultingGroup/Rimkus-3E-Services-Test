declare @existedClient table (
    [Entity] int,
	[ClientIndex] int,
	[ClientNumber] nvarchar(max),
	[ClientName] nvarchar(max),
	[ClientType] nvarchar(max),
	[ClientTypeDesc] nvarchar(max),
	[EmailAddress] nvarchar(max),
	[LastProcItemID] nvarchar(max),
	[OrigProcItemID] nvarchar(max),
	[RelateID] nvarchar(max),
	[SiteID] nvarchar(max)
	);

insert @existedClient
select distinct
c.Entity, 
c.ClientIndex,
c.Number [ClientNumber],
c.DisplayName [ClientName],
c.CliType [ClientType],
ct.Description [ClientTypeDesc],
se.EmailAddr [EmailAddress],
convert(nvarchar(max), c.LastProcItemID) [LastProcItemID],
convert(nvarchar(max), c.OrigProcItemID) [OrigProcItemID],
convert(nvarchar(max), re.RelIndex) [RelateID],
convert(nvarchar(max), s.SiteIndex) [SiteID]
from [@server].[@instance].[dbo].[Client] c
inner join [@server].[@instance].[dbo].[CliType] ct on ct.Code = c.CliType
inner join [@server].[@instance].[dbo].[Entity] e on e.EntIndex = c.Entity
left join [@server].[@instance].[dbo].[Relate] re on (re.SbjEntity=e.EntIndex and re.IsDefault=1)
left join [@server].[@instance].[dbo].[Site] s on (s.Relate=re.RelIndex)
left join [@server].[@instance].[dbo].[SiteEmail] se on (se.Site=s.SiteIndex)
where 
e.DisplayName = '@displayName' or se.EmailAddr like '%@email%'

select distinct 
[Entity],
[ClientIndex],
[ClientNumber],
[ClientName],
[ClientType],
[ClientTypeDesc],
[EmailAddress],
[LastProcItemID],
[OrigProcItemID],
[RelateID],
[SiteID]
from @existedClient
