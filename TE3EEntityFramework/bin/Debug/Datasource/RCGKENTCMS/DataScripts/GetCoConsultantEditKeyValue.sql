
select 
techRev.[TechRevEngRec_CCCID] [TechRevEngRec_CCCKeyValue]
,coCons.[CoConsultants_CCCID] [CoConsultants_CCCKeyValue]
from [@server].[@instance].[dbo].Matter m 
inner join [@server].[@instance].[dbo].TechRevEngRec_CCC techRev on techRev.Matter = m.MattIndex
inner join [@server].[@instance].[dbo].CoConsultants_CCC coCons on coCons.TechRevEngRec_CCC = techRev.TechRevEngRec_CCCID
inner join [@server].[@instance].[dbo].Timekeeper tkpr on tkpr.TkprIndex = coCons.CoConsultant
where m.MattIndex = @matterId   --144712-- 
and coCons.CoConsultant = @coConsultantNumber  --785--