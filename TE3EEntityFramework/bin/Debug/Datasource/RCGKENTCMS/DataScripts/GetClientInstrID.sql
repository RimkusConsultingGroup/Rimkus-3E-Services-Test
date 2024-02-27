
declare @cSpecialCode nvarchar(max)

select @cSpecialCode = Code
from [@server].[@instance].[dbo].[ClientInstructions_CCC]
where 
Code = '@clientInst'

select convert(nvarchar(max), msi.ClientInstr) --, csi.ClientInstructions_CCC, ci.Code, ci.Description --, csi.TimeStamp
from [@server].[@instance].[dbo].[Matter] m
left join [@server].[@instance].[dbo].[MatterSpecialInstructions_CCC] msi on msi.Matter = m.MattIndex and ((getdate()) between ( msi.StartDate ) and ( msi.EndDate))
left join [@server].[@instance].[dbo].[ClientSpecialInstructions_CCC] csi on csi.ClientSpecialInstructions_CCCID = msi.ClientInstr --and ((getdate()) between ( csi.StartDate ) and ( csi.EndDate))
--left join [@server].[@instance].[dbo].[ClientInstructions_CCC] ci on ci.Code = csi.ClientInstructions_CCC
where 
m.MattIndex = @mattIndex
and csi.ClientInstructions_CCC = @cSpecialCode