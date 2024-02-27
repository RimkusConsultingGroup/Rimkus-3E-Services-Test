select 
[dbo].[CMSExtractFirstName](mpd.Contact_CCC) [FirstName],
[dbo].[CMSExtractLastName](mpd.Contact_CCC) [LastName],
mpd.Email_CCC [Email],
mpd.Payor [PayorIndex],
mpd.Site [PayorSiteIndex],
convert(nvarchar(max), mpd.LastProcItemID) [LastProcItemID],
convert(nvarchar(max), mpd.OrigProcItemID) [OrigProcItemID]
from [@server].[@instance].[dbo].[MattPayorDet] mpd
where mpd.Contact_CCC = '@contactName'
and mpd.Email_CCC = '@email'
