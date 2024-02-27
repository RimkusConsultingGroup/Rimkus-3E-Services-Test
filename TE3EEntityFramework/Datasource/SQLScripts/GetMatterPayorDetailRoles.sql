--Matter Payor Details Roles
select 
Role,
Description
from [@server].[@instance].[dbo].[CftRole]
where Role in (100,600,1200,1300,1400,1500,1600) --(100,1000,1100,600,700,800,900)
order by description