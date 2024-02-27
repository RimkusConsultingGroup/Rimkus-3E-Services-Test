
select relParties.[RelatedParties_CCCID] [RelatedParties_CCCKeyValue]
from 
[@server].[@instance].[dbo].[Matter] m
inner join [@server].[@instance].[dbo].[RelatedParties_CCC] relParties on relParties.Matter = m.MattIndex
inner join [@server].[@instance].[dbo].[CftRole] r on r.Role = relParties.CftRole
inner join [@server].[@instance].[dbo].[Entity] e on e.EntIndex = relParties.Entity
where m.MattIndex = @mattIndex -- 463627
and e.EntIndex = @entityIndex -- 197049