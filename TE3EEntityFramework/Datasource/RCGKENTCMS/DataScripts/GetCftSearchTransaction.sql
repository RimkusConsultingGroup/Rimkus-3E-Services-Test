select 
cnbr.CftNewBizRequestID,
cnbr.CftSearchReason,
cnbr.Client,
cnbr.Matter,
cnbr.RequestDateTime,
cnbr.JobNumber,
cnbr.Description,
cnbr.CftNBRStatus,
rbu.BaseUserName,
cnbr.OrigProcItemID,
cnbr.LastProcItemID
from dbo.CftNewBizRequest cnbr
inner join dbo.CftNewBizRequest_draft cnbrd on cnbrd.ItemID = cnbr.CftNewBizRequestID
left join [dbo].NxBaseUser rbu on rbu.NxBaseUserID = cnbr.Submitter
where cnbr.Description = @description --'ABC COMPANY - 263e972f-92d5-4762-bd77-43db7fe6da18'
order by cnbr.TimeStamp desc