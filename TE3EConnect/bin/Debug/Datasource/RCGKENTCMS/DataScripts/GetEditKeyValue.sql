select convert(nvarchar(max), @retColumn)
from [@server].[@instance].[dbo].[@tableName]
where @lookupColumn = @foreignKey