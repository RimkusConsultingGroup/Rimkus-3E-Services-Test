USE [TE_3E_UAT]
GO
/****** Object:  StoredProcedure [dbo].[RetrieveCollectionItems]    Script Date: 4/1/2020 11:20:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[RetrieveCollectionItems] 
@numOfDays int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select distinct 
		m.Number AS [Matter Number]
		, o.Description AS [Office]
		, v.BalAmt AS [Balance Amount]
		, ci.CollectionItem AS [Collection Number]
		, (select top 1 StepNumber from CollectionStep where CollectionItem = ci.CollectionItem order by StepNumber desc) as [Current CollectionStep]
		, i.invnumber AS [Invoice Number]
		, i.InvDate AS [Invoice Date]
		, n.DisplayName AS [Header Client]
		, r.DisplayName AS [Payor Name]
		, d.PctFee AS [Percentage] 
		, t.BillName AS [Billing Timekeeper]
		, d.ClaimNum_CCC AS [Claim Number]
		, d.RefNumber AS [Reference Number]
		, d.Contact_CCC AS [Contact]
		, d.PhoneNum_CCC AS [Phone]
		, d.Email_CCC AS [Email]
		, c.Description AS [Relationship]
		, a.street AS [Street]
		, a.city AS [City]
		, a.state AS [State]
		, a.zipcode AS [Zip]
		, i.TimeStamp
		from 
 
		MattPayorDet d 
		inner join MattPayor p on d.MattPayor = p.MattPayorID 
		inner join Matter m on p.Matter = m.MattIndex 
		inner join CftRelationshipCode c on d.CftRelationship_CCC = c.RelationshipCode 
		inner join Site s on d.Site = s.SiteIndex 
		inner join Address a on s.Address = a.AddrIndex 
		inner join Payor r on d.Payor = r.PayorIndex 
		inner join InvMaster i on m.MattIndex = i.LeadMatter 
		inner join Office o on i.BillingOffice = o.Code
		inner join Timekeeper t on i.BillTimekeeper = t.Number 
		inner join Client n on m.Client = n.ClientIndex
		inner join ARMaster e on i.InvIndex = e.InvMaster 
		inner join InvPayor v on i.InvNumber = v.InvNumber
		inner join CollectionInvoice ci on ci.InvPayor = v.InvPayorID
 
		where v.IsPaid = '0' and i.IsReversed = '0' and v.BalAmt > '0' and ARAmt > '0' and d.PctFee > '0'
		and exists (select * from ARMaster where i.InvIndex = ARMaster.InvMaster)
		and i.TimeStamp >= DATEADD(day,-@numOfDays,getdate())
		order by i.TimeStamp
END
