select convert(nvarchar(max), msiv.MatterSpecialInvoiceTo_CCCID)
from [@server].[@instance].[dbo].[MatterSpecialInstructions_CCC] msi
left join [@server].[@instance].[dbo].[MatterSpecialInvoiceTo_CCC] msiv on msiv.MatterSpecial = msi.MatterSpecialInstructions_CCCID
where Matter = @mattIndex --463629
and msiv.InvoiceTo = '@email'