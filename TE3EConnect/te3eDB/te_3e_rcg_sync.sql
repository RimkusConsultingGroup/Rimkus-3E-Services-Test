USE [TE_3E_RCG_SYNC]
GO
/****** Object:  UserDefinedFunction [dbo].[ConvertFirsLastName]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[ConvertFirsLastName] 
(
	-- Add the parameters for the function here
	@name nvarchar(max)
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @firstLastName nvarchar(max)
	SET @firstLastName = SUBSTRING(@name, CHARINDEX(',', @name) + 2, LEN(@name)) + ' ' + SUBSTRING(@name, 1, CHARINDEX(',', @name) - 1)

	-- Return the result of the function
	RETURN @firstLastName

END
GO
/****** Object:  UserDefinedFunction [dbo].[ConvertTitleCase]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[ConvertTitleCase] 
(
	-- Add the parameters for the function here
	@String nvarchar(max)
)
RETURNS nvarchar(max)
AS
BEGIN
	
	-- Add the T-SQL statements to compute the return value here
	DECLARE @Position INT;

SELECT @String   = STUFF(LOWER(@String),1,1,UPPER(LEFT(@String,1))) COLLATE Latin1_General_Bin,
                    @Position = PATINDEX('%[^A-Za-z''][a-z]%',@String COLLATE Latin1_General_Bin);

                    WHILE @Position > 0
                    SELECT @String   = STUFF(@String,@Position,2,UPPER(SUBSTRING(@String,@Position,2))) COLLATE Latin1_General_Bin,
                    @Position = PATINDEX('%[^A-Za-z''][a-z]%',@String COLLATE Latin1_General_Bin);

                     RETURN @String;

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetClaimantOrInsuredName]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetClaimantOrInsuredName]
(
	-- Add the parameters for the function here
	@matterNo nvarchar(max),
	@isInsured int = 0
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	declare @claimantOrInsured nvarchar(max)
	declare @role nvarchar(max)

	set @role = '300'
	if(@isInsured = 1)
	begin
		set @role = '200'
	end
	
;WITH ClaimantOrInsured_CTE (Number, CftRole, Value)  
	AS  
	-- Define the CTE query.  
	(  
		SELECT Number, Max(CftRole), Value = STUFF((SELECT N', ' + addlPartyEntity1.DisplayName 
		  FROM [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Matter AS m1
			left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].RelatedParties_CCC addlParty1 ON addlParty1.Matter = m1.MattIndex --AND addlParty.CftRole in ('300')
			left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Entity addlPartyEntity1 ON addlPartyEntity1.EntIndex = addlParty1.Entity
		   WHERE m1.Number = m2.Number and addlParty1.CftRole = addlParty2.CftRole
		   --ORDER BY Value
		   FOR XML PATH, TYPE).value(N'.[1]', N'nvarchar(max)'),1, 2, N'')
		   --FOR XML PATH(N'')), 1, 2, N'')
		FROM [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Matter AS m2
			left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].RelatedParties_CCC addlParty2 ON addlParty2.Matter = m2.MattIndex --AND addlParty.CftRole in ('300')
			left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Entity addlPartyEntity2 ON addlPartyEntity2.EntIndex = addlParty2.Entity
			where m2.Number = @matterNo and addlParty2.CftRole = @role
		GROUP BY Number, CftRole
	)

	select @claimantOrInsured = Value from ClaimantOrInsured_CTE

	-- Return the result of the function
	RETURN @claimantOrInsured

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetMatterSpecialInstrRelatedClient]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetMatterSpecialInstrRelatedClient]
(
	-- Add the parameters for the function here
	@matterNo nvarchar(max)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @relatedClient int

	-- Add the T-SQL statements to compute the return value here
	select @relatedClient = ms.Client
	from [RCG3ESQL01-D].[TE_3E_UAT].[dbo].matter m
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MatterSpecialInstructions_CCC ms on ms.Matter = m.MattIndex
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayor mp on mp.Matter = m.MattIndex
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayorDet mpd on mpd.MattPayor = mp.MattPayorID
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Payor p on p.PayorIndex = mpd.Payor 
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Client c on c.ClientIndex = p.Client
	where m.Number = @matterNo
	and 
	mpd.CftRelationship_CCC in ('01', '03')

	-- Return the result of the function
	RETURN @relatedClient

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetPayorRelatedClient]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetPayorRelatedClient]
(
	-- Add the parameters for the function here
	@matterNo nvarchar(max)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @relatedClient int

	-- Add the T-SQL statements to compute the return value here
	select @relatedClient = c.RelatedClient
	from [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Matter m
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayor mp on mp.Matter = m.MattIndex
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayorDet mpd on mpd.MattPayor = mp.MattPayorID
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Payor p on p.PayorIndex = mpd.Payor 
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Client c on c.ClientIndex = p.Client
	where 
	m.Number = @matterNo
	and 
	mpd.CftRelationship_CCC in ('01', '03')

	-- Return the result of the function
	RETURN @relatedClient

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetPhoneOrFax]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetPhoneOrFax]
(
	-- Add the parameters for the function here
	@matterNo nvarchar(max),
	@phoneType nvarchar(15) --Phone type - 100 (office), 200 (fax), 150 (home), 250 (mobile)
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	declare @phoneOrFaxNum nvarchar(max)

	select @phoneOrFaxNum = ph.PhoneString
	from [RCG3ESQL01-D].[TE_3E_UAT].[dbo].[Matter] m
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].[MattDate] md on md.MatterLkUp = m.MattIndex
	LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Office o on o.Code = md.Office
	LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].SitePhone sp on sp.Site = o.Site
	LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Phone ph on ph.PhoneIndex = sp.Phone
	WHERE m.Number = @matterNo and ph.PhoneType = @phoneType

	-- Return the result of the function
	RETURN @phoneOrFaxNum

END
GO
/****** Object:  UserDefinedFunction [dbo].[GetTkprTitle]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[GetTkprTitle]
(
	-- Add the parameters for the function here
	@tkprIndex nvarchar(max)
)
RETURNS nvarchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @tkprName nvarchar(max)

	-- Add the T-SQL statements to compute the return value here
	SELECT @tkprName = tktitle.Description
	FROM [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Timekeeper tk 
    INNER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].TkprDate tkdate ON tkdate.TimekeeperLkUp=tk.TkprIndex AND GETDATE() BETWEEN (tkdate.NxStartDate) AND (tkdate.NxEndDate)
    INNER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Title tktitle ON tkdate.Title = tktitle.Code 
	WHERE tk.TkprIndex = @tkprIndex

	-- Return the result of the function
	RETURN @tkprName

END
GO
/****** Object:  UserDefinedFunction [dbo].[IsBrasheerMatterExist]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[IsBrasheerMatterExist]
(
	-- Add the parameters for the function here
	@matterNo nvarchar(max)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @count int

	-- Add the T-SQL statements to compute the return value here
	select @count = count(*)
	from [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Matter m
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayor mp on mp.Matter = m.MattIndex
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayorDet mpd on mpd.MattPayor = mp.MattPayorID
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Payor p on p.PayorIndex = mpd.Payor 
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Client c on c.ClientIndex = p.Client
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattDate md on md.MatterLkUp = m.MattIndex
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Section s on s.Code = md.Section
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Office o on o.Code = md.Office
	where 
	m.Number = @matterNo
	and s.Code = '030'

	-- Return the result of the function
	RETURN @count

END
GO
/****** Object:  UserDefinedFunction [dbo].[IsMatterRelatedClientExist]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[IsMatterRelatedClientExist]
(
	-- Add the parameters for the function here
	@matterNo nvarchar(max)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @count int

	-- Add the T-SQL statements to compute the return value here
	select @count = count(*)
	from [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Matter m
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayor mp on mp.Matter = m.MattIndex
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayorDet mpd on mpd.MattPayor = mp.MattPayorID
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Payor p on p.PayorIndex = mpd.Payor 
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Client c on c.ClientIndex = p.Client
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattDate md on md.MatterLkUp = m.MattIndex
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Section s on s.Code = md.Section
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Office o on o.Code = md.Office
	where 
	m.Number = @matterNo
	and 
	mpd.CftRelationship_CCC in ('03') and c.RelatedClient in (select RelatedClient from TE_3E_RCG_SYNC.dbo.ExcludedClientCollectionWF)

	-- Return the result of the function
	RETURN @count

END
GO
/****** Object:  UserDefinedFunction [dbo].[IsMultiPayorMatterExist]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[IsMultiPayorMatterExist]
(
	-- Add the parameters for the function here
	@matterNo nvarchar(max)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @count int

	-- Add the T-SQL statements to compute the return value here
	select @count = count(*)
	from [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Matter m
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayor mp on mp.Matter = m.MattIndex
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayorDet mpd on mpd.MattPayor = mp.MattPayorID
	where 
	m.Number = @matterNo
	and mpd.PctFee between 1 and 99
	and mpd.CftRelationship_CCC in ('01', '03')

	-- Return the result of the function
	RETURN @count

END
GO
/****** Object:  UserDefinedFunction [dbo].[IsRBCLondonCandaMatterExist]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[IsRBCLondonCandaMatterExist]
(
	-- Add the parameters for the function here
	@matterNo nvarchar(max)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @count int

	-- Add the T-SQL statements to compute the return value here
	select @count = count(*)
	from [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Matter m
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayor mp on mp.Matter = m.MattIndex
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayorDet mpd on mpd.MattPayor = mp.MattPayorID
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Payor p on p.PayorIndex = mpd.Payor 
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Client c on c.ClientIndex = p.Client
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattDate md on md.MatterLkUp = m.MattIndex
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Section s on s.Code = md.Section
	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Office o on o.Code = md.Office
	where 
	m.Number = @matterNo
	and o.Code in ('093', '094', '095')

	-- Return the result of the function
	RETURN @count

END
GO
/****** Object:  Table [dbo].[ClientMaster]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientMaster](
	[ClientKeyId] [int] IDENTITY(1,1) NOT NULL,
	[AppId] [varchar](500) NULL,
	[AppKey] [varchar](500) NULL,
	[ClientName] [varchar](100) NULL,
	[CreatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientKeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomSubjectLine]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomSubjectLine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientIndex] [nvarchar](10) NOT NULL,
	[ClientName] [nvarchar](max) NOT NULL,
	[SpecialSubjectLine] [nvarchar](max) NOT NULL,
	[SpecificEmail] [nvarchar](max) NULL,
 CONSTRAINT [PK_CustomSubjectLine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExcludedClientCollectionWF]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExcludedClientCollectionWF](
	[ClientID] [uniqueidentifier] NOT NULL,
	[ClientIndex] [int] NOT NULL,
	[Number] [nvarchar](64) NOT NULL,
	[DisplayName] [nvarchar](128) NOT NULL,
	[SortString] [nvarchar](128) NULL,
	[RelatedClient] [int] NOT NULL,
	[IsExcluded] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrackerSafeEMSImport]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackerSafeEMSImport](
	[MatterID] [uniqueidentifier] NOT NULL,
	[MattIndex] [int] NOT NULL,
	[MattNumber] [nvarchar](64) NULL,
	[MattName] [nvarchar](255) NULL,
	[Description] [nvarchar](1024) NULL,
	[MattStatus] [nvarchar](16) NULL,
	[MattStatusDate] [datetime] NULL,
	[MattType] [nvarchar](16) NULL,
	[OpenDate] [datetime] NULL,
	[ClientIndex] [int] NULL,
	[ClientNumber] [nvarchar](64) NULL,
	[ClientName] [nvarchar](128) NULL,
	[ClientFormattedString] [nvarchar](500) NULL,
	[ClientStreet] [nvarchar](500) NULL,
	[ClientCity] [nvarchar](500) NULL,
	[ClientState] [nvarchar](500) NULL,
	[ClientZipCode] [nvarchar](500) NULL,
	[Contact Email] [nvarchar](255) NULL,
	[ClaimNo] [nvarchar](255) NULL,
	[ReferenceNumber] [nvarchar](255) NULL,
	[Contact Name] [nvarchar](255) NULL,
	[Contact Phone] [nvarchar](64) NULL,
	[Insured Name] [nvarchar](512) NULL,
	[Claimant] [nvarchar](512) NULL,
	[Style] [nvarchar](512) NULL,
	[Cause Number] [nvarchar](512) NULL,
	[Date of Loss] [nvarchar](64) NULL,
	[OfficeFormattedString] [nvarchar](500) NULL,
	[OfficeName] [nvarchar](500) NULL,
	[OfficeStreet] [nvarchar](500) NULL,
	[OfficeCity] [nvarchar](500) NULL,
	[OfficeState] [nvarchar](500) NULL,
	[OfficeZipCode] [nvarchar](500) NULL,
	[OfficePhone] [nvarchar](500) NULL,
	[OfficeFax] [nvarchar](500) NULL,
	[CertAuthNo] [nvarchar](500) NULL,
	[Exported] [int] NULL,
	[ErrorMsg] [varchar](max) NULL,
	[TransDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[SplitStrings]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[SplitStrings]
(
   @List       NVARCHAR(MAX),
   @Delimiter  NVARCHAR(255)
)
RETURNS TABLE
WITH SCHEMABINDING
AS
   RETURN 
   (  
      SELECT Item = y.i.value('(./text())[1]', 'nvarchar(4000)')
      FROM 
      ( 
        SELECT x = CONVERT(XML, '<i>' 
          + REPLACE(@List, @Delimiter, '</i><i>') 
          + '</i>').query('.')
      ) AS a CROSS APPLY x.nodes('i') AS y(i)
   );
GO
/****** Object:  StoredProcedure [dbo].[RetrieveCollectionItemsByPastDueDays]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RetrieveCollectionItemsByPastDueDays] 
@numOfDays int = 31
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @collectionItems TABLE (
    [MatterNumber] nvarchar(max),
	[MatterName] nvarchar(max),
	[ClientIndex] int,
	[ClientName] nvarchar(max),
	[PrimaryRelatedClient] int,
	[PayorRelatedClient] int,
	[MattSpecialInstrRelatedClient] int,
	[Office] nvarchar(max),
	[DateOfLoss] nvarchar(max), 
	[Insured Name] nvarchar(max), 
	[Claimant] nvarchar(max), 
	[Style] nvarchar(max), 
	[Cause Number] nvarchar(max), 
	[InvMaster] int, 
    [InvDate] datetime, 
	[InvPayor] uniqueidentifier, 
	[Payor] int, 
    [PayorName] nvarchar(max), 
	[CollectionItem] int, 
	[CollectionStep] int, 
	[Collector] uniqueidentifier, 
    [CollectorName] nvarchar(max), 
	[OpenAmt] decimal, 
	[OrigAmt] decimal, 
	[OrigCollAmt] decimal, 
	[DaysOverdue] int
	);

	insert into @collectionItems
	SELECT DISTINCT
		m.Number as [MatterNumber],
		m.DisplayName as [MatterName],
		n9t12.Client as [ClientIndex],
		(SELECT DisplayName FROM [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Client WHERE ClientIndex = n9t12.Client) as [ClientName],
		(SELECT RelatedClient FROM [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Client WHERE ClientIndex = n9t12.Client) as [PrimaryRelatedClient],
		dbo.GetPayorRelatedClient(m.Number) as [PayorRelatedClient],
		dbo.GetMatterSpecialInstrRelatedClient(m.Number) as [MattSpecialInstrRelatedClient],
		o.Description as [Office],
		m.DateOfOccurenceTxt_CCC as [DateOfLoss], 
		dbo.GetClaimantOrInsuredName(m.Number, 0) as [Insured Name],
		dbo.GetClaimantOrInsuredName(m.Number, 1) as [Claimant],
		p.Style_CCC AS [Style],
		p.CauseNum_CCC as [Cause Number],
		n1t3.InvMaster as [InvMaster],
		n2t2.InvDate as [InvDate],
		n0t1.InvPayor as [InvPayor],
		n1t3.Payor as [Payor],
		(select DisplayName from [RCG3ESQL01-D].[TE_3E_UAT].[dbo].payor where PayorIndex = n1t3.Payor) as [PayorName],
		n0t1.CollectionItem as [CollectionItem],
		(select max(a.StepNumber)
			from(
			select StepNumber, CollectionItem
			from [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CollectionStep 
			union
			select StepNumber, CollectionItem
			from [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CollectionHistory) a 
			where a.CollectionItem = n0t1.CollectionItem) as [CollectionStep],
		n9t12.Collector as [Collector],
		( SELECT n8t11.Name FROM [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Collector AS n8t11 
		WHERE ( n8t11.CollectorID ) = ( n9t12.Collector ) )  as [CollectorName],
		--z2t5.TkprDateID as [BillTkprDate],
		( n1t3.BalAmt ) * ( CASE WHEN ( n0t1.Currency ) = ( N'USD'  ) 
		THEN 1 WHEN ( ( n4t7.ToCurrency ) = ( N'USD'  ) ) AND ( ( n4t7.IsRatePerToCurrency ) = ( 1 ) ) 
		THEN ( 1 ) / ( n6t9.Rate ) 
		WHEN ( ( n4t7.ToCurrency ) = ( N'USD'  ) ) AND ( ( n4t7.IsRatePerToCurrency ) = ( 0 ) ) 
		THEN n6t9.Rate 
		WHEN ( n4t7.IsRatePerToCurrency ) = ( 1 ) 
		THEN ( z3t9.Rate ) / ( n6t9.Rate ) 
		ELSE ( n6t9.Rate ) / ( z3t9.Rate ) END ) as [OpenAmt],
		( n1t3.OrgAmt ) * ( CASE WHEN ( n0t1.Currency ) = ( N'USD'  ) 
		THEN 1 WHEN ( ( n4t7.ToCurrency ) = ( N'USD'  ) ) AND ( ( n4t7.IsRatePerToCurrency ) = ( 1 ) ) 
		THEN ( 1 ) / ( n6t9.Rate ) 
		WHEN ( ( n4t7.ToCurrency ) = ( N'USD'  ) ) AND ( ( n4t7.IsRatePerToCurrency ) = ( 0 ) ) 
		THEN n6t9.Rate 
		WHEN ( n4t7.IsRatePerToCurrency ) = ( 1 ) 
		THEN ( z3t9.Rate ) / ( n6t9.Rate ) 
		ELSE ( n6t9.Rate ) / ( z3t9.Rate ) END ) as [OrigAmt],
		( n0t1.OrigCollAmt ) * ( CASE WHEN ( n0t1.Currency ) = ( N'USD'  ) 
		THEN 1 
		WHEN ( ( n4t7.ToCurrency ) = ( N'USD'  ) ) AND ( ( n4t7.IsRatePerToCurrency ) = ( 1 ) ) 
		THEN ( 1 ) / ( n6t9.Rate ) 
		WHEN ( ( n4t7.ToCurrency ) = ( N'USD'  ) ) AND ( ( n4t7.IsRatePerToCurrency ) = ( 0 ) ) 
		THEN n6t9.Rate 
		WHEN ( n4t7.IsRatePerToCurrency ) = ( 1 ) 
		THEN ( z3t9.Rate ) / ( n6t9.Rate ) 
		ELSE ( n6t9.Rate ) / ( z3t9.Rate ) END ) as [OrigCollAmt],
		DATEDIFF ( Day , n2t2.DueDate , CAST ( CONVERT(DATETIME,CONVERT(CHAR(12),GETDATE(),101),101) AS DATETIME ) ) as [DaysOverdue]
		--n7t10.StepsCompleted  
FROM [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CollectionInvoice AS n0t1 
JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].InvPayor AS n1t3 
JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].InvMaster AS n2t2 
JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattDate AS z1t4 ON ( n2t2.LeadMatter ) = ( z1t4.MatterLkUp ) 
JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].TkprDate AS z2t5 ON ( n2t2.BillTimekeeper ) = ( z2t5.TimekeeperLkUp ) ON ( n1t3.InvMaster ) = ( n2t2.InvIndex ) ON ( n0t1.InvPayor ) = ( n1t3.InvPayorID ) 
--JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CollectionTotalView AS n3t6 ON ( n0t1.CollectionItem ) = ( n3t6.CollectionItem ) 
JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CurrencyType AS n4t7 ON ( n4t7.Code ) = ( N'Daily'  ) 
JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CurrencyTypeDate AS n5t8 ON ( ( n4t7.Code ) = ( n5t8.CurrencyTypeLkUp ) ) AND ( ( n2t2.InvDate)BETWEEN ( n5t8.NxStartDate ) AND ( n5t8.NxEndDate)) 
JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CurrencyTypeDateRate AS n6t9 ON ( ( n0t1.Currency ) = ( n6t9.Currency ) ) AND ( ( n5t8.CurrencyTypeDateID ) = ( n6t9.CurrencyTypeDate ) ) 
JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CurrencyTypeDateRate AS z3t9 ON ( ( z3t9.Currency ) = ( N'USD'  ) ) AND ( ( n5t8.CurrencyTypeDateID ) = ( z3t9.CurrencyTypeDate ) ) 
JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CollectionItem AS n9t12 ON ( n0t1.CollectionItem ) = ( n9t12.Number ) 
INNER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Matter m on m.MattIndex = n2t2.LeadMatter
LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayor p on p.Matter = m.MattIndex
LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Office o on o.Code = n2t2.BillingOffice
--LEFT OUTER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CollectionStepsCompletedView AS n7t10 ON ( n0t1.CollectionItem ) = ( n7t10.CollectionItem ) 
WHERE 
( ( 
--( ( n9t12.Collector ) IN ( SELECT n8t11.CollectorID FROM [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Collector AS n8t11 
--WHERE ( n8t11.Name ) = ( N'CASSIE R. HADLEY'  ) ) ) 
--AND 
( ( ( n1t3.IsPaid ) = ( 0 ) ) AND ( ( n2t2.IsReversed ) = ( 0 ) ))) 
AND 
( ( GETDATE()) BETWEEN ( z1t4.NxStartDate ) AND ( z1t4.NxEndDate)) ) AND ( (GETDATE()) BETWEEN ( z2t5.NxStartDate ) AND ( z2t5.NxEndDate))
 AND ( (GETDATE()) BETWEEN ( p.StartDate ) AND ( p.EndDate))
 AND DATEDIFF ( Day , n2t2.DueDate , CAST ( CONVERT(DATETIME,CONVERT(CHAR(12),GETDATE(),101),101) AS DATETIME ) ) = @numOfDays
 ORDER BY DaysOverdue

SELECT *
FROM @collectionItems
WHERE 
dbo.IsBrasheerMatterExist(MatterNumber) = 0
and dbo.IsMatterRelatedClientExist(MatterNumber) = 0
and dbo.IsRBCLondonCandaMatterExist(MatterNumber) = 0
and dbo.IsMultiPayorMatterExist(MatterNumber) = 0
--and NOT EXISTS (SELECT * FROM DBO.ExcludedClientCollectionWF WHERE RelatedClient = MattSpecialInstrRelatedClient) 
and NOT EXISTS (SELECT * FROM DBO.ExcludedClientCollectionWF WHERE RelatedClient = PrimaryRelatedClient) 
and NOT EXISTS (SELECT * FROM DBO.ExcludedClientCollectionWF WHERE RelatedClient = PayorRelatedClient) 


END
GO
/****** Object:  StoredProcedure [dbo].[RetrieveItemizedInvCollection]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RetrieveItemizedInvCollection] 
@collectionItem nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--select distinct 
	--	m.Number AS [Matter Number]
	--	, e.ARAmt as [ARAmount]
	--	, v.BalAmt AS [Balance Amount]
	--	, i.invnumber AS [Invoice Number]
	--	, i.InvDate AS [Invoice Date]
	--	, n.DisplayName AS [Header Client]
	--	, r.DisplayName AS [Payor Name]
	--	, d.PctFee AS [Percentage] 
	--	, t.BillName AS [Billing Timekeeper]
	--	, d.ClaimNum_CCC AS [Claim Number]
	--	, d.RefNumber AS [Reference Number]
	--	, d.Contact_CCC AS [Contact]
	--	, d.PhoneNum_CCC AS [Phone]
	--	, d.Email_CCC AS [Email]
	--	, c.Description AS [Relationship]
	--	, a.street AS [Street]
	--	, a.city AS [City]
	--	, a.state AS [State]
	--	, a.zipcode AS [Zip]
	--	, m.DateOfOccurenceTxt_CCC as [Date of Loss]
	--	, p.Style_CCC as [Style]
	--	, p.CauseNum_CCC as [Cause Number]
	--	, dbo.GetClaimantOrInsuredName(m.Number, 0) as [Insured Name]
	--	, dbo.GetClaimantOrInsuredName(m.Number, 1) as [Claimant]
	--	, v.IsPaid
	--	, i.IsReversed
	--	from 
	--	[RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayorDet d 
	--	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayor p on d.MattPayor = p.MattPayorID 
	--	inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Matter m on p.Matter = m.MattIndex 
	--	left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CftRelationshipCode c on d.CftRelationship_CCC = c.RelationshipCode 
	--	left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Site s on d.Site = s.SiteIndex 
	--	left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Address a on s.Address = a.AddrIndex 
	--	left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Payor r on d.Payor = r.PayorIndex 
	--	left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].InvMaster i on m.MattIndex = i.LeadMatter 
	--	left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Office o on i.BillingOffice = o.Code
	--	left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Timekeeper t on i.BillTimekeeper = t.Number 
	--	left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Client n on m.Client = n.ClientIndex
	--	left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].ARMaster e on i.InvIndex = e.InvMaster 
	--	left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].InvPayor v on i.InvNumber = v.InvNumber
	--	left join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CollectionInvoice ci on ci.InvPayor = v.InvPayorID
	--	where 
	--	--v.IsPaid = '0' and i.IsReversed = '0' and v.BalAmt > '0' and ARAmt > '0' and 
	--	i.IsReversed = '0'
	--	and
	--	d.PctFee > '0'
	--	and 
	--	exists (select * from [RCG3ESQL01-D].[TE_3E_UAT].[dbo].ARMaster where i.InvIndex = ARMaster.InvMaster)
	--	and m.Number = @matterNo
	--	order by i.InvDate

	SELECT distinct
		n0t0.MatterCollectionInvoiceID 
		,n0t0.MatterCollectionItem
		--,n0t4.ArchetypeCode
		--,n0t4.CurrProcItemID
		--,n0t4.LastProcItemID
		--,n0t4.OrigProcItemID
		--,n0t4.HasAttachments
		,n0t4.TimeStamp as [CollectionInvoice_TimeStamp]
		,n0t4.InvPayor as [CollectionInvoice_InvPayor]
		,n0t4.BillingGroup as [CollectionInvoice_BillingGroup]
		,n0t4.CollectionItem as [CollectionInvoice_CollectionItem]
		,n0t4.OrigCollAmt as [CollectionInvoice_OrigColAmt]
		--,n0t4.ConvDate
		--,n0t4.Currency
		,n0t4.DisputedAmount as [CollectionInvoice_DisputedAmount]
		,n0t4.DisputeResolutionResp as [CollectionInvoice_DisputeResolutionResp]
		,n0t4.InvoiceDisputeReason as [CollectionInvoice_InvoiceDisputeReason]
		,n0t4.Comments as [CollectionInvoice_Comments]
		,n0t4.ProformaSite as [CollectionInvoice_ProformaSite]
		,n4t5.InvMaster as [InvPayor_InvMaster]
		,n4t5.InvNumber as [InvPayor_InvNumber]
		,n4t5.Payor as [InvPayor_Payor]
		,n4t5.Currency as [InvPayor_Currency]
		,n4t5.CurrDate as [InvPayor_CurrDate]
		,n4t5.OrgAmt as [InvPayor_OrgAmt]
		,n4t5.AdjAmt as [InvPayor_AdjAmt]
		,n4t5.BalAmt as [InvPayor_BalAmt]
		,n4t5.Site as [InvPayor_Site]
		,n4t5.IsPaid as [InvPayor_IsPaid]
		,n4t5.PaidDate as [InvPayor_PaidDate]
		,n4t5.DoubtfulAmt as [InvPayor_DoubtfulAmt]
		,n4t5.ForAttentionOf as [InvPayor_ForAttentionOf]
		,n4t5.Layer as [InvPayor_Layer]
		,n4t5.RefNumber as [InvPayor_RefNumber]
		,n5t6.InvNumber as [InvMaster_InvNumber]
		,n5t6.InvDate as [InvMaster_InvDate]
		,n5t6.DueDate as [InvMaster_DueDate]
		,n5t6.LeadMatter as [InvMaster_LeadMatter]
		,n5t6.InvIndex as [InvMaster_InvIndex]
		,n5t6.IsReversed as [InvMaster_IsReversed]
		,n6t7.Number as [Matter_Number]
		,n6t7.Client as [Client_Index]
		,n6t7.Description as [Matter_Description]
		,n6t7.Language as [Matter_Language]
		,n7t8.DisplayName as [Client_Name]
		,n7t8.Number as [Client_Number]
		,n8t9.Locale as [Language_Locale]
		,n8t9.Description as [Language_Description]
		,n9t10.DisplayName as [Payor_Description]
		,n10t11.CurrCode as [NxCurrencyCode_CurrCode]
		,n11t12.Address as [Site_Address]
		,n11t12.Description as [Site_Description]
		--,n23t12.Description as [Site_Description]
		,n12t13.City as [Address_City]
		,n12t13.Country as [Address_Country]
		,n12t13.Street as [Address_Street]
		,n12t13.ZipCode as [Address_ZipCode]
		,n12t13.FormattedString as [Address_FormattedString]
		,n12t13.State as [Address_State]
		,n13t14.Code as [Country_Code]
		,n13t14.Description as [Country_Description]
		,n14t15.Code as [State_Code]
		,n14t15.Description as [State_Description]
		,n15t16.Description as [BillingGroup_Description]
		,n16t2.Collector as [CollectionItem_Collector]
		,n16t2.Workflow as [CollectionItem_Workflow]
		,n16t2.Number as [CollectionItem_Number]
		,n16t2.Description as [CollectionItem_Description]
		,n17t17.Name as [Collector_Name]
		,n18t18.Description as [CollectionWorkflow_Description]
		--,n19t11.CurrCode as [NxCurrencyCode_CurrCode]
		,n20t19.Entity as [Timekeeper_Entity]
		,n20t19.Number as [Timekeeper_Number]
		,n21t21.DisplayName as [Entity_Description]
		,n22t22.Description as [InvoiceDisputeReason_Description]
		FROM [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MatterCollectionInvoice AS n0t0 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MatterCollectionItem AS n1t1 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CollectionItem AS n1t2 ON ( n1t1.MatterCollectionItemID ) = ( n1t2.CollectionItemID ) 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CollectionItem AS n2t2 
		LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].NxWorklist AS n3t3 ON ( n3t3.ItemID ) = ( n2t2.CollectionItemID ) ON ( n2t2.CollectionItemID ) = ( n1t1.MatterCollectionItemID ) ON ( n1t2.Number ) = ( n0t0.MatterCollectionItem ) 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CollectionInvoice AS n0t4 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].InvPayor AS n4t5 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].InvMaster AS n5t6 
		LEFT OUTER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Matter AS n6t7 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Client AS n7t8 ON ( n6t7.Client ) = ( n7t8.ClientIndex ) 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Language AS n8t9 ON ( n6t7.Language ) = ( n8t9.Locale ) ON ( n5t6.LeadMatter ) = ( n6t7.MattIndex ) ON ( n4t5.InvMaster ) = ( n5t6.InvIndex ) 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Payor AS n9t10 ON ( n4t5.Payor ) = ( n9t10.PayorIndex ) 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].NxCurrencyCode AS n10t11 ON ( n4t5.Currency ) = ( n10t11.CurrCode ) 
		LEFT OUTER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Site AS n11t12 
		LEFT OUTER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Address AS n12t13 
		LEFT OUTER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Country AS n13t14 ON ( n12t13.Country ) = ( n13t14.Code ) 
		LEFT OUTER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].State AS n14t15 ON ( n12t13.State ) = ( n14t15.Code ) ON ( n11t12.Address ) = ( n12t13.AddrIndex ) ON ( n4t5.Site ) = ( n11t12.SiteIndex ) ON ( n0t4.InvPayor ) = ( n4t5.InvPayorID ) 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CollectionItem AS n16t2 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Collector AS n17t17 ON ( n16t2.Collector ) = ( n17t17.CollectorID ) 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].CollectionWorkflow AS n18t18 ON ( n16t2.Workflow ) = ( n18t18.Name ) ON ( n0t4.CollectionItem ) = ( n16t2.Number ) 
		LEFT OUTER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].BillingGroup AS n15t16 ON ( n0t4.BillingGroup ) = ( n15t16.GroupName ) 
		LEFT OUTER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].NxCurrencyCode AS n19t11 ON ( n0t4.Currency ) = ( n19t11.CurrCode ) 
		LEFT OUTER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Timekeeper AS n20t19 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].EntityPerson AS n21t20 
		JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Entity AS n21t21 ON ( n21t20.EntityPersonID ) = ( n21t21.EntityID ) ON ( n20t19.Entity ) = ( n21t21.EntIndex ) ON ( n0t4.DisputeResolutionResp ) = ( n20t19.TkprIndex ) 
		LEFT OUTER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].InvoiceDisputeReason AS n22t22 ON ( n0t4.InvoiceDisputeReason ) = ( n22t22.Code ) 
		LEFT OUTER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Site AS n23t12 ON ( n0t4.ProformaSite ) = ( n23t12.SiteIndex ) ON ( n0t0.MatterCollectionInvoiceID ) = ( n0t4.CollectionInvoiceID ) 
		WHERE n0t4.CollectionItem = @collectionItem
		and n4t5.BalAmt > '0'
		ORDER BY [InvMaster_InvDate]
END
GO
/****** Object:  StoredProcedure [dbo].[RetrieveLetterHeaderAddress]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RetrieveLetterHeaderAddress]
	-- Add the parameters for the stored procedure here
	@matterNo nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select distinct locAddress.FormattedString [ClientFormattedString],
	--locAddress.OrgName [ClientOrgName],
	--payorClient.DisplayName [ClientOrgName],
	--c.DisplayName [ClientOrgName],
	p.DisplayName [ClientOrgName],
	locAddress.Street [ClientStreet],
	locAddress.City [ClientCity],
	locAddress.State [ClientState],
	locAddress.ZipCode [ClientZipCode],
	mpd.Email_CCC [ClientEmail],
	mpd.ClaimNum_CCC [ClaimNumber],
	mpd.RefNumber [ReferenceNumber],
	mpd.Contact_CCC [ClientContact],
	mpd.PhoneNum_CCC [ClientPhone],
	adr.FormattedString [BillingFormattedString],
	adr.OrgName [BillingOrgName],
	adr.Street [BillingStreet],
	adr.City [BillingCity],
	adr.State [BillingState],
	adr.ZipCode [BillingZipCode]
	from 
	[TE_3E_UAT].[dbo].[Matter] m
	--inner join [TE_3E_UAT].[dbo].Client c on c.ClientIndex = m.Client
	inner join [TE_3E_UAT].[dbo].[MattDate] md on md.MatterLkUp = m.MattIndex
	INNER JOIN [TE_3E_UAT].dbo.MattPayor mp ON mp.Matter = m.MattIndex
	LEFT JOIN [TE_3E_UAT].dbo.MattPayorDet mpd ON mpd.MattPayor=mp.MattPayorID AND mpd.CftRelationship_CCC in ('01', '03')
	LEFT JOIN [TE_3E_UAT].[dbo].Payor p ON p.PayorIndex = mpd.Payor
	--LEFT join [TE_3E_UAT].[dbo].Client payorClient on payorClient.ClientIndex = mpd.Payor
	LEFT JOIN [TE_3E_UAT].dbo.Site locSite ON locSite.SiteIndex = mpd.Site
	LEFT JOIN [TE_3E_UAT].dbo.Address locAddress ON locAddress.AddrIndex = locSite.Address
	LEFT JOIN [TE_3E_UAT].dbo.Office o on o.Code = md.Office
	LEFT join [TE_3E_UAT].dbo.Address adr on adr.AddrIndex = o.Site
	where m.Number = @matterNo
END
GO
/****** Object:  StoredProcedure [dbo].[RetrieveMatteCPC]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RetrieveMatteCPC] 
@matterNo nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT DISTINCT
		m.Number as [MattNumber],
		m.DisplayName as [MattName],
		m.Description as [Description],
		[dbo].ConvertFirsLastName(tkpm.BillName) [BillingTkprName],
		[dbo].ConvertFirsLastName(tkrsp.BillName) [RspTkprName],
		o.Description [ReportingOffice]
		from 
		[RCG3ESQL01-D].[TE_3E_UAT].[dbo].[Matter] m
		inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].[MattDate] md on md.MatterLkUp = m.MattIndex
		inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].[Timekeeper] tkpm on tkpm.TkprIndex = md.BillTkpr AND ( ( GETDATE()) BETWEEN ( md.NxStartDate ) AND ( md.NxEndDate)) 
		inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].[Timekeeper] tkrsp on tkrsp.TkprIndex = md.RspTkpr AND( ( GETDATE()) BETWEEN ( md.NxStartDate ) AND ( md.NxEndDate)) 
		inner JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Office o on o.Code = md.Office AND ( ( GETDATE()) BETWEEN ( md.NxStartDate ) AND ( md.NxEndDate)) 
		where m.Number = @matterNo
END
GO
/****** Object:  StoredProcedure [dbo].[RetrieveMatterByNum]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RetrieveMatterByNum] 
@matterNo nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		SELECT DISTINCT
		m.MatterID as [MatterID],
		m.MattIndex as [MattIndex],
		m.Number as [MattNumber],
		m.DisplayName as [MattName],
		m.Description as [Description],
		m.MattStatus as [MattStatus],
		m.MattStatusDate as [MattStatusDate],
		m.MattType as [MattType],
		m.OpenDate [OpenDate],
		c.ClientIndex [ClientIndex],
		c.Number [ClientNumber],
		c.DisplayName [ClientName],
		locAddress.FormattedString [ClientFormattedString],
		locAddress.Street [ClientStreet],
		locAddress.City [ClientCity],
		locAddress.State [ClientState],
		locAddress.ZipCode [ClientZipCode],
		mpd.Email_CCC [Contact Email],
		mpd.ClaimNum_CCC [ClaimNo],
		mpd.RefNumber [ReferenceNumber],
		mpd.Contact_CCC [Contact Name],
		mpd.PhoneNum_CCC [Contact Phone],
		dbo.GetClaimantOrInsuredName(m.Number, 0) as [Insured Name],
		dbo.GetClaimantOrInsuredName(m.Number, 1) as [Claimant],
		mp.Style_CCC AS [Style],
		mp.CauseNum_CCC as [Cause Number],
		m.DateOfOccurenceTxt_CCC [Date of Loss],
		adr.FormattedString [OfficeFormattedString],
		adr.OrgName [OfficeName],
		adr.Street [OfficeStreet],
		adr.City [OfficeCity],
		adr.State [OfficeState],
		adr.ZipCode [OfficeZipCode],
		[dbo].[GetPhoneOrFax](m.Number, '100') as [OfficePhone],
		[dbo].[GetPhoneOrFax](m.Number, '200') as [OfficeFax],
		o.CertAuthNo_CCC [CertAuthNo],
		0 [Exported],
		null [ErrorMsg],
		null [TransDate]
		from 
		[RCG3ESQL01-D].[TE_3E_UAT].[dbo].[Matter] m
		inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Client c on c.ClientIndex = m.Client
		inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].[MattDate] md on md.MatterLkUp = m.MattIndex
		INNER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayor mp ON mp.Matter = m.MattIndex
		LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayorDet mpd ON mpd.MattPayor=mp.MattPayorID AND mpd.CftRelationship_CCC in ('01', '03')
		LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Site locSite ON locSite.SiteIndex = mpd.Site
		LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Address locAddress ON locAddress.AddrIndex = locSite.Address
		LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Office o on o.Code = md.Office
		LEFT join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Address adr on adr.AddrIndex = o.Site
		where m.Number = @matterNo
END
GO
/****** Object:  StoredProcedure [dbo].[RetrieveMatters]    Script Date: 8/13/2020 4:22:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RetrieveMatters] 
@numOfDays int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [TE_3E_RCG_SYNC].[dbo].TrackerSafeEMSImport
					([MatterID]
					  ,[MattIndex]
					  ,[MattNumber]
					  ,[MattName]
					  ,[Description]
					  ,[MattStatus]
					  ,[MattStatusDate]
					  ,[MattType]
					  ,[OpenDate]
					  ,[ClientIndex]
					  ,[ClientNumber]
					  ,[ClientName]
					  ,[ClientFormattedString]
					  ,[ClientStreet]
					  ,[ClientCity]
					  ,[ClientState]
					  ,[ClientZipCode]
					  ,[Contact Email]
					  ,[ClaimNo]
					  ,[ReferenceNumber]
					  ,[Contact Name]
					  ,[Contact Phone]
					  ,[Insured Name]
					  ,[Claimant]
					  ,[Style]
					  ,[Cause Number]
					  ,[Date of Loss]
					  ,[OfficeFormattedString]
					  ,[OfficeName]
					  ,[OfficeStreet]
					  ,[OfficeCity]
					  ,[OfficeState]
					  ,[OfficeZipCode]
					  ,[OfficePhone]
					  ,[OfficeFax]
					  ,[CertAuthNo]
					  ,[Exported])
					SELECT DISTINCT
					m.MatterID,
					m.MattIndex,
					m.Number,
					m.DisplayName,
					m.Description,
					m.MattStatus,
					m.MattStatusDate,
					m.MattType,
					m.OpenDate,
					c.ClientIndex,
					c.Number,
					c.DisplayName,
					locAddress.FormattedString [ClientFormattedString],
					locAddress.Street [ClientStreet],
					locAddress.City [ClientCity],
					locAddress.State [ClientState],
					locAddress.ZipCode [ClientZipCode],
					mpd.Email_CCC [ClientEmail],
					mpd.ClaimNum_CCC [ClaimNumber],
					mpd.RefNumber [ReferenceNumber],
					mpd.Contact_CCC [ClientContact],
					mpd.PhoneNum_CCC [ClientPhone],
					dbo.GetClaimantOrInsuredName(m.Number, 0) as [Insured Name],
					dbo.GetClaimantOrInsuredName(m.Number, 1) as [Claimant],
					mp.Style_CCC AS [Style],
					mp.CauseNum_CCC as [Cause Number],
					m.DateOfOccurenceTxt_CCC,
					adr.FormattedString [BillingFormattedString],
					adr.OrgName [BillingOrgName],
					adr.Street [BillingStreet],
					adr.City [BillingCity],
					adr.State [BillingState],
					adr.ZipCode [BillingZipCode],
					[dbo].[GetPhoneOrFax](m.Number, '100') as [OfficePhone],
					[dbo].[GetPhoneOrFax](m.Number, '200') as [OfficeFax],
					o.CertAuthNo_CCC [CertAuthNo],
					0 [Exported]
					from 
						[RCG3ESQL01-D].[TE_3E_UAT].[dbo].[Matter] m
						inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Client c on c.ClientIndex = m.Client
						inner join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].[MattDate] md on md.MatterLkUp = m.MattIndex
						INNER JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayor mp ON mp.Matter = m.MattIndex
						LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].MattPayorDet mpd ON mpd.MattPayor=mp.MattPayorID AND mpd.CftRelationship_CCC in ('01', '03')
						LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Site locSite ON locSite.SiteIndex = mpd.Site
						LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Address locAddress ON locAddress.AddrIndex = locSite.Address
						LEFT JOIN [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Office o on o.Code = md.Office
						LEFT join [RCG3ESQL01-D].[TE_3E_UAT].[dbo].Address adr on adr.AddrIndex = o.Site
					  where m.[TimeStamp] >= DATEADD(day,-@numOfDays,getdate()) AND NOT EXISTS (SELECT * FROM  [TE_3E_RCG_SYNC].[dbo].TrackerSafeEMSImport WHERE MatterID = m.MatterID)
END
GO
