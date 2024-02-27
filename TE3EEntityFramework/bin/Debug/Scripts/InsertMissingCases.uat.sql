
DELETE [TE_3E_RCG_SYNC].[dbo].TrackerSafeEMSImport
WHERE Exported = -1

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
					  ,[Exported]
					  ,[OfficeDescription]
					  ,[Engineer1])
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
					--c.DisplayName,
					--payorClient.DisplayName,
					p.DisplayName,
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
					0 [Exported],
					o.Description,
					(select DisplayName from [RCG3ESQL31-D.RIMKUS.NET].[TE_3E_UAT].[dbo].[Timekeeper] where TkprIndex =  md.[BillTkpr]) as [Engineer1]
					from 
						[RCG3ESQL31-D.RIMKUS.NET].[TE_3E_UAT].[dbo].[Matter] m
						inner join [RCG3ESQL31-D.RIMKUS.NET].[TE_3E_UAT].[dbo].Client c on c.ClientIndex = m.Client
						inner join [RCG3ESQL31-D.RIMKUS.NET].[TE_3E_UAT].[dbo].[MattDate] md on md.MatterLkUp = m.MattIndex
						INNER JOIN [RCG3ESQL31-D.RIMKUS.NET].[TE_3E_UAT].[dbo].MattPayor mp ON mp.Matter = m.MattIndex
						LEFT JOIN [RCG3ESQL31-D.RIMKUS.NET].[TE_3E_UAT].[dbo].MattPayorDet mpd ON mpd.MattPayor=mp.MattPayorID AND mpd.CftRelationship_CCC in ('01', '03')
						LEFT JOIN [RCG3ESQL31-D.RIMKUS.NET].[TE_3E_UAT].[dbo].Payor p ON p.PayorIndex = mpd.Payor
						LEFT JOIN [RCG3ESQL31-D.RIMKUS.NET].[TE_3E_UAT].[dbo].Site locSite ON locSite.SiteIndex = mpd.Site
						LEFT JOIN [RCG3ESQL31-D.RIMKUS.NET].[TE_3E_UAT].[dbo].Address locAddress ON locAddress.AddrIndex = locSite.Address
						LEFT JOIN [RCG3ESQL31-D.RIMKUS.NET].[TE_3E_UAT].[dbo].Office o on o.Code = md.Office
						LEFT JOIN [RCG3ESQL31-D.RIMKUS.NET].[TE_3E_UAT].[dbo].Site oSite ON oSite.SiteIndex = o.Site
						LEFT join [RCG3ESQL31-D.RIMKUS.NET].[TE_3E_UAT].[dbo].Address adr on adr.AddrIndex = oSite.Address
					  where m.Number in (@mattNumbers)
					  AND NOT EXISTS (SELECT * FROM  [TE_3E_RCG_SYNC].[dbo].TrackerSafeEMSImport WHERE MatterID = m.MatterID)
					  AND (( GETDATE()) BETWEEN ( md.NxStartDate ) AND ( md.NxEndDate))

