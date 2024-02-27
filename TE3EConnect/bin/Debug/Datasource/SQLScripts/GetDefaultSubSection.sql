--Matt Rate Group Exc
select 
Code
from [@server].[@instance].[dbo].SubSection_CCC
where Description = 'Default' AND Section = '@section'
