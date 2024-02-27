using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TE3EEntityFramework.Datasource;

namespace TE3EConnect.te3eARCollectionItem
{
    public static class ARStatementBody
    {

        public static string GetStatementBodyHtml(
			RetrieveCollectionItemsByPastDueDays_Result colItem,
			List<RetrieveItemizedInvCollection_Result> itemizedInv,
			RetrieveLetterHeaderAddress_Result letterHeadAddress,
			bool isDebug = false)
        {
            string bodyHtml = "";
            string strTemplate = "ARStatement.xml";
            using (var objStreamReader = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), $"template/{strTemplate}")))
            {
				bodyHtml = objStreamReader.ReadToEnd();

				StringBuilder sb = new StringBuilder();
				sb.AppendLine($"{letterHeadAddress.ClientCity}, {letterHeadAddress.ClientState} {letterHeadAddress.ClientZipCode}");

				bodyHtml = bodyHtml.Replace("@clientOrgName", !string.IsNullOrEmpty(letterHeadAddress.ClientOrgName) ? FixXMLString(letterHeadAddress.ClientOrgName) : "");
				bodyHtml = bodyHtml.Replace("@clientStreet", letterHeadAddress.ClientStreet);
				bodyHtml = bodyHtml.Replace("@clientCityState", sb.ToString());

				//hide empty attrs
				bodyHtml = string.IsNullOrEmpty(colItem.DateOfLoss) || Convert.ToDateTime(colItem.DateOfLoss) == DateTime.MinValue
				   ? bodyHtml.Replace("@dateOfLossParagraph", "")
				   : bodyHtml.Replace("@dateOfLossParagraph", DateOfLossParagraph);

				bodyHtml = string.IsNullOrEmpty(letterHeadAddress.ClaimNumber)
					? bodyHtml.Replace("@claimParagraph", "")
					: bodyHtml.Replace("@claimParagraph", ClaimParagraph);

				bodyHtml = string.IsNullOrEmpty(letterHeadAddress.ReferenceNumber)
					? bodyHtml.Replace("@referenceParagraph", "")
					: bodyHtml.Replace("@referenceParagraph", ReferenceParagraph);

				bodyHtml = string.IsNullOrEmpty(colItem.Insured_Name)
					? bodyHtml.Replace("@InsuredParagraph", "")
					: bodyHtml.Replace("@InsuredParagraph", InsuredParagraph);

				bodyHtml = string.IsNullOrEmpty(colItem.Claimant)
					? bodyHtml.Replace("@claimantParagraph", "")
					: bodyHtml.Replace("@claimantParagraph", ClaimantParagraph);

				bodyHtml = string.IsNullOrEmpty(colItem.Style)
					? bodyHtml.Replace("@styleParagraph", "")
					: bodyHtml.Replace("@styleParagraph", StyleParagraph);

				bodyHtml = string.IsNullOrEmpty(colItem.Cause_Number)
					? bodyHtml.Replace("@causeParagraph", "")
					: bodyHtml.Replace("@causeParagraph", CauseParagraph);

				bodyHtml = bodyHtml.Replace("@matterNo", colItem.MatterNumber);
				bodyHtml = bodyHtml.Replace("@dateOfLoss", Convert.ToDateTime(colItem.DateOfLoss).ToString("MM/dd/yyyy"));
				bodyHtml = bodyHtml.Replace("@referenceNo", letterHeadAddress.ReferenceNumber);
				bodyHtml = bodyHtml.Replace("@insuredName", !string.IsNullOrEmpty(colItem.Insured_Name) ? FixXMLString(colItem.Insured_Name) : "");
				bodyHtml = bodyHtml.Replace("@claimant", !string.IsNullOrEmpty(colItem.Claimant) ? FixXMLString(colItem.Claimant) : "");
				bodyHtml = bodyHtml.Replace("@styleName", !string.IsNullOrEmpty(colItem.Style) ? FixXMLString(colItem.Style) : "");
				bodyHtml = bodyHtml.Replace("@causeNo", colItem.Cause_Number);
				bodyHtml = bodyHtml.Replace("@claimNo", letterHeadAddress.ClaimNumber);
				bodyHtml = bodyHtml.Replace("@currentDate1", DateTime.Now.ToString("MMMM dd, yyyy"));
				bodyHtml = bodyHtml.Replace("@currentDate2", DateTime.Now.ToString("MM/dd/yyyy"));

				double totalAmt = 0.0;
				StringBuilder itemizedRow = new StringBuilder();

				for(int i=0;i<itemizedInv.Count;i++) //(var invGrp in itemizedInv)
				{
					string invDate = Convert.ToDateTime(itemizedInv[i].InvMaster_InvDate).ToString("MM/dd/yyyy");
					string invNum = itemizedInv[i].InvPayor_InvNumber;
					double billedAmt = Convert.ToDouble(itemizedInv[i].InvPayor_OrgAmt);
					double balanceAmt = Convert.ToDouble(itemizedInv[i].InvPayor_BalAmt);
					double recvdAmt = balanceAmt - billedAmt;

					string invrow = ItemizedRows[0].Replace("@invoiceDate", invDate)
														   .Replace("@invoiceNumber", invNum)
														   .Replace("@billedAmount", billedAmt.ToString("N2"))
														   .Replace("@received", recvdAmt.ToString("N2"))
														   .Replace("@balanceDue", balanceAmt.ToString("N2"));
					totalAmt = totalAmt + balanceAmt;
					itemizedRow.AppendLine(invrow);
				}

				bodyHtml = bodyHtml.Replace("@itemizedRow", itemizedRow.ToString());
				bodyHtml = bodyHtml.Replace("@totalAmtDue", totalAmt.ToString("N2"));

			}

			return bodyHtml;
        }

		private static string FixXMLString(string strValue)
		{
			try
			{

				strValue = strValue.Replace("&", "&amp;")
								   .Replace("\"\"", "&quot;")
								   .Replace("'", "&apos;")
								   .Replace("<", "&lt;")
								   .Replace(">", "&gt;");
			}
			catch { }

			return strValue;
		}

		private static string DateOfLossParagraph = @"<w:tr w:rsidR=""00BC09A4"" w:rsidRPr=""00BC09A4"" w14:paraId=""06B2D3E9"" w14:textId=""77777777"" w:rsidTr=""00474692"">
							<w:trPr>
								<w:cantSplit/>
								<w:tblHeader/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""2160"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""15DAF9A0"" w14:textId=""77777777"" w:rsidR=""00BC09A4"" w:rsidRPr=""00BC09A4"" w:rsidRDefault=""00BC09A4"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00BC09A4"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>Date of Loss:</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""7200"" w:type=""dxa""/>
									<w:gridSpan w:val=""4""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""0CA73BEE"" w14:textId=""2B39D0B0"" w:rsidR=""00BC09A4"" w:rsidRPr=""00BC09A4"" w:rsidRDefault=""00C35808"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""007D0C32"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@dateOfLoss</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>";

		private static string ReferenceParagraph = @"<w:tr w:rsidR=""0092171B"" w:rsidRPr=""00BC09A4"" w14:paraId=""34276A96"" w14:textId=""77777777"" w:rsidTr=""00474692"">
							<w:trPr>
								<w:cantSplit/>
								<w:tblHeader/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""2160"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""0902D071"" w14:textId=""078516FC"" w:rsidR=""0092171B"" w:rsidRPr=""00BC09A4"" w:rsidRDefault=""0092171B"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>Reference No.:</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""7200"" w:type=""dxa""/>
									<w:gridSpan w:val=""4""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""4C0342D3"" w14:textId=""608B6BBA"" w:rsidR=""0092171B"" w:rsidRPr=""007D0C32"" w:rsidRDefault=""00107C06"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:hAnsi=""Arial"" w:cs=""Arial""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""21""/>
										</w:rPr>
										<w:t>@referenceNo</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>";

		private static string InsuredParagraph = @"<w:tr w:rsidR=""00BC09A4"" w:rsidRPr=""00BC09A4"" w14:paraId=""044FDF26"" w14:textId=""77777777"" w:rsidTr=""00474692"">
							<w:trPr>
								<w:cantSplit/>
								<w:tblHeader/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""2160"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""157838D6"" w14:textId=""77777777"" w:rsidR=""00BC09A4"" w:rsidRPr=""00BC09A4"" w:rsidRDefault=""00BC09A4"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00BC09A4"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>Insured:</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""7200"" w:type=""dxa""/>
									<w:gridSpan w:val=""4""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""40291D25"" w14:textId=""5655B795"" w:rsidR=""00BC09A4"" w:rsidRPr=""00BC09A4"" w:rsidRDefault=""00517FF8"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00517FF8"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@insuredName</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>";

		private static string ClaimantParagraph = @"<w:tr w:rsidR=""00FC03C2"" w:rsidRPr=""00BC09A4"" w14:paraId=""74DA3085"" w14:textId=""77777777"" w:rsidTr=""00474692"">
							<w:trPr>
								<w:cantSplit/>
								<w:tblHeader/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""2160"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""4954D2A6"" w14:textId=""0C0354DA"" w:rsidR=""00FC03C2"" w:rsidRPr=""00BC09A4"" w:rsidRDefault=""00FC03C2"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:hAnsi=""Arial"" w:cs=""Arial""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""21""/>
										</w:rPr>
										<w:t>Claimant:</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""7200"" w:type=""dxa""/>
									<w:gridSpan w:val=""4""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""56221706"" w14:textId=""5FB0B8DA"" w:rsidR=""00FC03C2"" w:rsidRPr=""00517FF8"" w:rsidRDefault=""00107C06"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:hAnsi=""Arial"" w:cs=""Arial""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""21""/>
										</w:rPr>
										<w:t>@claimant</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>";

		private static string StyleParagraph = @"<w:tr w:rsidR=""00FC03C2"" w:rsidRPr=""00BC09A4"" w14:paraId=""75BF40BE"" w14:textId=""77777777"" w:rsidTr=""00474692"">
							<w:trPr>
								<w:cantSplit/>
								<w:tblHeader/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""2160"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""373B74D7"" w14:textId=""4753F62B"" w:rsidR=""00FC03C2"" w:rsidRPr=""00BC09A4"" w:rsidRDefault=""00FC03C2"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:hAnsi=""Arial"" w:cs=""Arial""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""21""/>
										</w:rPr>
										<w:t>Style:</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""7200"" w:type=""dxa""/>
									<w:gridSpan w:val=""4""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""7EFE1D84"" w14:textId=""19B06DD2"" w:rsidR=""00FC03C2"" w:rsidRPr=""00517FF8"" w:rsidRDefault=""00FC03C2"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:hAnsi=""Arial"" w:cs=""Arial""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""21""/>
										</w:rPr>
										<w:t>@styleName</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>";

		private static string CauseParagraph = @"<w:tr w:rsidR=""00FC03C2"" w:rsidRPr=""00BC09A4"" w14:paraId=""74EBBFED"" w14:textId=""77777777"" w:rsidTr=""00474692"">
							<w:trPr>
								<w:cantSplit/>
								<w:tblHeader/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""2160"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""1AD76056"" w14:textId=""7B44C582"" w:rsidR=""00FC03C2"" w:rsidRPr=""00BC09A4"" w:rsidRDefault=""00FC03C2"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:hAnsi=""Arial"" w:cs=""Arial""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""21""/>
										</w:rPr>
										<w:t>Cause No.:</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""7200"" w:type=""dxa""/>
									<w:gridSpan w:val=""4""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""53977837"" w14:textId=""2071D6FA"" w:rsidR=""00FC03C2"" w:rsidRPr=""00517FF8"" w:rsidRDefault=""00107C06"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:hAnsi=""Arial"" w:cs=""Arial""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""21""/>
										</w:rPr>
										<w:t>@causeNo</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>";

		private static string ClaimParagraph = @"<w:tr w:rsidR=""00BC09A4"" w:rsidRPr=""00BC09A4"" w14:paraId=""25B7C3B0"" w14:textId=""77777777"" w:rsidTr=""00474692"">
							<w:trPr>
								<w:cantSplit/>
								<w:tblHeader/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""2160"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""4E298F2F"" w14:textId=""77777777"" w:rsidR=""00BC09A4"" w:rsidRPr=""00BC09A4"" w:rsidRDefault=""00BC09A4"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00BC09A4"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>Claim No.:</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""7200"" w:type=""dxa""/>
									<w:gridSpan w:val=""4""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""2B66E6FA"" w14:textId=""7CB2E27C"" w:rsidR=""00BC09A4"" w:rsidRPr=""00BC09A4"" w:rsidRDefault=""007D0C32"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""007D0C32"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@claimNo</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>";

		//private static string ItemizedCollectionTable =
		//	@"
		//				<w:tr w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w14:paraId=""1AE1B5DD"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
		//					<w:trPr>
		//						<w:cantSplit/>
		//						<w:trHeight w:val=""310""/>
		//						<w:tblHeader/>
		//						<w:jc w:val=""center""/>
		//					</w:trPr>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1593"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""3A1894AD"" w14:textId=""7CE51670"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>05/07/2020</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1594"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""5C0C8AFC"" w14:textId=""7B9AAED6"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""center""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>6668065</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1444"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""683CD317"" w14:textId=""78323429"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$157.50</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1877"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""007B08A1"" w14:textId=""390802CE"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$0.00</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1444"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""0B06B1DA"" w14:textId=""036060B2"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$157.50</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//				</w:tr>
		//				<w:tr w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w14:paraId=""1BED5AE9"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
		//					<w:trPr>
		//						<w:cantSplit/>
		//						<w:trHeight w:val=""310""/>
		//						<w:tblHeader/>
		//						<w:jc w:val=""center""/>
		//					</w:trPr>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1593"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""5BE4E16D"" w14:textId=""5094719E"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>05/07/2020</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1594"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""76A8FEDE"" w14:textId=""69D7A611"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""center""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>6668065</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1444"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""4C46768B"" w14:textId=""110ADB0E"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$157.50</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1877"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""463EA1EA"" w14:textId=""68826BBE"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$0.00</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1444"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""6BD66BAA"" w14:textId=""6E6C590C"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$157.50</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//				</w:tr>
		//				<w:tr w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w14:paraId=""3BF421E4"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
		//					<w:trPr>
		//						<w:cantSplit/>
		//						<w:trHeight w:val=""310""/>
		//						<w:tblHeader/>
		//						<w:jc w:val=""center""/>
		//					</w:trPr>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1593"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""03F1409D"" w14:textId=""79916ADF"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>05/07/2020</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1594"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""59488992"" w14:textId=""5ABDDEFA"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""center""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>6668065</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1444"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""4ED28B44"" w14:textId=""4120014D"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$157.50</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1877"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""7E3598C0"" w14:textId=""03DEB0B5"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$0.00</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1444"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""6931F0EA"" w14:textId=""112DB90B"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$157.50</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//				</w:tr>
		//				<w:tr w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w14:paraId=""46E93BF1"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
		//					<w:trPr>
		//						<w:cantSplit/>
		//						<w:trHeight w:val=""310""/>
		//						<w:tblHeader/>
		//						<w:jc w:val=""center""/>
		//					</w:trPr>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1593"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""6CD585F4"" w14:textId=""16DF7B5A"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>05/07/2020</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1594"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""5680D6FA"" w14:textId=""168BF401"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""center""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>6668065</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1444"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""27C4200B"" w14:textId=""121C88B5"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$157.50</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1877"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""2A0E1D10"" w14:textId=""6BB54006"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$0.00</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1444"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""7A7DCB32"" w14:textId=""23660FD5"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$157.50</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//				</w:tr>
		//				<w:tr w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w14:paraId=""668CCE81"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
		//					<w:trPr>
		//						<w:cantSplit/>
		//						<w:trHeight w:val=""310""/>
		//						<w:tblHeader/>
		//						<w:jc w:val=""center""/>
		//					</w:trPr>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1593"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""485AC3E5"" w14:textId=""0CC15981"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>05/07/2020</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1594"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""5D1A1150"" w14:textId=""70936906"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""center""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>6668065</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1444"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""4C172432"" w14:textId=""6231101A"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$157.50</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1877"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""2ED46EDA"" w14:textId=""0F439847"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$0.00</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//					<w:tc>
		//						<w:tcPr>
		//							<w:tcW w:w=""1444"" w:type=""dxa""/>
		//							<w:vAlign w:val=""bottom""/>
		//						</w:tcPr>
		//						<w:p w14:paraId=""26AD6F1F"" w14:textId=""2F35A5AC"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
		//							<w:pPr>
		//								<w:keepNext/>
		//								<w:keepLines/>
		//								<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
		//								<w:contextualSpacing/>
		//								<w:jc w:val=""right""/>
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//							</w:pPr>
		//							<w:r w:rsidRPr=""00AB2EAD"">
		//								<w:rPr>
		//									<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
		//									<w:sz w:val=""18""/>
		//									<w:szCs w:val=""20""/>
		//								</w:rPr>
		//								<w:t>$157.50</w:t>
		//							</w:r>
		//						</w:p>
		//					</w:tc>
		//				</w:tr>
		//				<w:tr w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w14:paraId=""3BBD2C78"" w14:textId=""77777777"" w:rsidTr=""0018160D"">";

        public static List<string> ItemizedRows = new List<string> 
		{
			@"<w:tr w:rsidR=""009334E4"" w:rsidRPr=""00AB2EAD"" w14:paraId=""5972879C"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
							<w:trPr>
								<w:cantSplit/>
								<w:trHeight w:val=""310""/>
								<w:tblHeader/>
								<w:jc w:val=""center""/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1593"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""00A90354"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00AF1C13"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceDate</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1594"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""6EF15A65"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00AF1C13"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""center""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceNumber</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""1142DF78"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@billedAmount</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1877"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""4D83AACD"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@received</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""4F3C5AC1"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@balanceDue</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>",
			@"<w:tr w:rsidR=""009334E4"" w:rsidRPr=""00AB2EAD"" w14:paraId=""5C96F5A5"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
							<w:trPr>
								<w:cantSplit/>
								<w:trHeight w:val=""310""/>
								<w:tblHeader/>
								<w:jc w:val=""center""/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1593"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""19C96249"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00AF1C13"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceDate</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1594"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""5DCC5299"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00AF1C13"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""center""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceNumber</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""76DB3D05"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@billedAmount</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1877"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""53C0D158"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@received</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""272BF65C"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@balanceDue</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>",
			@"<w:tr w:rsidR=""009334E4"" w:rsidRPr=""00AB2EAD"" w14:paraId=""79059206"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
							<w:trPr>
								<w:cantSplit/>
								<w:trHeight w:val=""310""/>
								<w:tblHeader/>
								<w:jc w:val=""center""/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1593"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""265AAD0F"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00AF1C13"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceDate</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1594"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""7FADE46C"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00AF1C13"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""center""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceNumber</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""079BE548"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@billedAmount</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1877"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""02B7B169"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@received</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""5C1DA9BD"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@balanceDue</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>",
			@"<w:tr w:rsidR=""009334E4"" w:rsidRPr=""00AB2EAD"" w14:paraId=""669BC6C9"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
							<w:trPr>
								<w:cantSplit/>
								<w:trHeight w:val=""310""/>
								<w:tblHeader/>
								<w:jc w:val=""center""/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1593"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""65BFE344"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00AF1C13"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceDate</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1594"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""0D7EA7E9"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00AF1C13"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""center""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceNumber</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""3E54AA08"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@billedAmount</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1877"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""510BC321"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@received</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""4B49BB1B"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@balanceDue</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>",
			@"<w:tr w:rsidR=""009334E4"" w:rsidRPr=""00AB2EAD"" w14:paraId=""0922C46F"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
							<w:trPr>
								<w:cantSplit/>
								<w:trHeight w:val=""310""/>
								<w:tblHeader/>
								<w:jc w:val=""center""/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1593"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""0125EDE8"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00AF1C13"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceDate</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1594"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""27248B70"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00AF1C13"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""center""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceNumber</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""45A01C75"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@billedAmount</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1877"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""2A709D1B"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@received</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""3D47DE2A"" w14:textId=""77777777"" w:rsidR=""004C566E"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""004C566E"" w:rsidP=""00FD427E"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""21""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@balanceDue</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>",
			@"<w:tr w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w14:paraId=""1368B126"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
							<w:trPr>
								<w:cantSplit/>
								<w:trHeight w:val=""310""/>
								<w:tblHeader/>
								<w:jc w:val=""center""/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1593"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""0E1B4D32"" w14:textId=""75A2032C"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceDate</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1594"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""486D2E9C"" w14:textId=""6360A4B2"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""center""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceNumber</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""1FA20066"" w14:textId=""0D9B284B"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@billedAmount</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1877"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""24F607D9"" w14:textId=""146580BE"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@received</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""0D97CB8E"" w14:textId=""1508B50B"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@balanceDue</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>",
			@"<w:tr w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w14:paraId=""00D43FE2"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
							<w:trPr>
								<w:cantSplit/>
								<w:trHeight w:val=""310""/>
								<w:tblHeader/>
								<w:jc w:val=""center""/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1593"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""65E6A55E"" w14:textId=""319B72D7"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceDate</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1594"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""5C63033A"" w14:textId=""3391725B"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""center""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceNumber</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""5D7FC07B"" w14:textId=""6DDCD523"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@billedAmount</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1877"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""0908048E"" w14:textId=""4BE995E0"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@received</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""13A37535"" w14:textId=""5B279D72"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@balanceDue</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>",
			@"<w:tr w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w14:paraId=""53A05E7D"" w14:textId=""77777777"" w:rsidTr=""0018160D"">
							<w:trPr>
								<w:cantSplit/>
								<w:trHeight w:val=""310""/>
								<w:tblHeader/>
								<w:jc w:val=""center""/>
							</w:trPr>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1593"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""01426C50"" w14:textId=""1C334468"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceDate</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1594"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""6C41DA41"" w14:textId=""75D40D24"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""center""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>@invoiceNumber</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""355EDB5D"" w14:textId=""6309033B"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@billedAmount</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1877"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""13124572"" w14:textId=""6BCDD0AA"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@received</w:t>
									</w:r>
								</w:p>
							</w:tc>
							<w:tc>
								<w:tcPr>
									<w:tcW w:w=""1444"" w:type=""dxa""/>
									<w:vAlign w:val=""bottom""/>
								</w:tcPr>
								<w:p w14:paraId=""3EFEE4E8"" w14:textId=""51CAE89E"" w:rsidR=""0018160D"" w:rsidRPr=""00AB2EAD"" w:rsidRDefault=""0018160D"" w:rsidP=""0018160D"">
									<w:pPr>
										<w:keepNext/>
										<w:keepLines/>
										<w:spacing w:after=""120"" w:line=""240"" w:lineRule=""auto""/>
										<w:contextualSpacing/>
										<w:jc w:val=""right""/>
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
									</w:pPr>
									<w:r w:rsidRPr=""00AB2EAD"">
										<w:rPr>
											<w:rFonts w:ascii=""Arial"" w:eastAsia=""Arial"" w:hAnsi=""Arial"" w:cs=""Times New Roman""/>
											<w:sz w:val=""18""/>
											<w:szCs w:val=""20""/>
										</w:rPr>
										<w:t>$@balanceDue</w:t>
									</w:r>
								</w:p>
							</w:tc>
						</w:tr>",
		};
    }
}
