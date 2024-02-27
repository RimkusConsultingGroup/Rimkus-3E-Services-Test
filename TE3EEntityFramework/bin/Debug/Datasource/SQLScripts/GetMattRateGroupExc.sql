--Matt Rate Group Exc
select 
RateExcID, 
Description
from [@server].[@instance].[dbo].RateExc
where RateExcID = '@mattRateGrpExc'