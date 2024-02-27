--Additional Parties Roles
select 
Role,
Description
from [@server].[@instance].[dbo].[CftRole]
where Role in (100,200,300,400,500)
order by description