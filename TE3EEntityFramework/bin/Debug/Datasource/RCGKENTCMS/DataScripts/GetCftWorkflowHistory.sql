select distinct
cu.BaseUserName [CurrentOwner],
s.CurrentStepID,
s.StepType,
r.CftSearchReason,
r.Client [ClientIndex],
cl.Number [ClientNumber],
cl.DisplayName [ClientName],
r.Matter [MatterIndex],
m.Number [MatterNumber],
m.DisplayName [MatterName],
r.RequestDateTime,
CAST(s.EndDateTime AS DATE) AS EndDateTime,
r.JobNumber,
r.Description,
r.CftNBRStatus,
c.NumResults,
c.DateRun,
rbu.BaseUserName [Ranby]
--,c.*
--,r.*
from [@server].[@instance].[dbo].CftSearch c 
left join [@server].[@instance].[dbo].CftNewBizRequest r on r.CftNewBizRequestID = c.CftNewBizRequest
inner join [@server].[@instance].[dbo].Matter m on m.MattIndex = r.Matter
inner join [@server].[@instance].[dbo].Client cl on cl.ClientIndex = r.Client
left join [@server].[@instance].[dbo].NxFWKProcessItemStep s on s.ProcItemID = c.CurrProcItemID
left join [@server].[@instance].[dbo].NxBaseUser rbu on rbu.NxBaseUserID = c.Ranby
left join [@server].[@instance].[dbo].NxBaseUser cu on cu.NxBaseUserID = s.CurrentUserId
where 
r.JobNumber = @jobNumber
AND s.EndDateTime IS NOT NULL