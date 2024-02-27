using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML
{
    public static class e3eVoucherXML
    {
        public static string GetVoucherXML = @"
            <QUERY xmlns=""http://elite.com/schemas/query"">
                                            <SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
                                              <OQL_CONTEXT Class=""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
                                                <NODEMAP ID=""Node#1"" QueryID=""Voucher"" Class=""NextGen.Application.Query.Voucher"" Assembly=""NextGen.Archetype.Voucher"" />
                                                <NODEMAP ID=""Node#2"" QueryID=""Payee1"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#3"" QueryID=""APTranType1"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#4"" QueryID=""Terms1"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#5"" QueryID=""PO1"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#6"" QueryID=""Office1"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#7"" QueryID=""BankAcctAP2"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#8"" QueryID=""Voucher1"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#9"" QueryID=""Site1"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#10"" QueryID=""ReverseReasonRel"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#11"" QueryID=""VchrStatus1"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#12"" QueryID=""VchrPayStatusListRel"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#13"" QueryID=""PayeeAccountRel"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#14"" QueryID=""CkReqUserRel"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#15"" QueryID=""CkReqTimekeeperRel"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#16"" QueryID=""WF_VchrApproverRel"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#17"" QueryID=""WF_ReturnCheckToRel"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                                <NODEMAP ID=""Node#18"" QueryID=""WF_ReturnToOfficeRel"">
                                                  <NODE NodeID=""Node#1"" />
                                                </NODEMAP>
                                              </OQL_CONTEXT>
                                              <SELECT_LIST>
                                                <SINGLE_SELECT Union=""Distinct"">
                                                  <NODE NodeID=""Node#1"" />
                                                  <VALUES>
                                                    <VALUE>
                                                      <LEAF QueryID=""VoucherID"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""VchrIndex"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""VoucherNum"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""TranDate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""InvDate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""InvNum"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Payee"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Name"">
                                                        <NODE NodeID=""Node#2"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Currency"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""CurrDate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Amount"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""APTranType"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Description"">
                                                        <NODE NodeID=""Node#3"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Terms"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Description"">
                                                        <NODE NodeID=""Node#4"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""DiscountDate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""DueDate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""PayDate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""OpenAmt"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""PONum"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""PO"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""PONum"">
                                                        <NODE NodeID=""Node#5"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""POAmt"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Office"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Description"">
                                                        <NODE NodeID=""Node#6"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""PayBankAcct"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Name"">
                                                        <NODE NodeID=""Node#7"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""APGLAcct"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""PostDate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""IsPrepaid"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Comments"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""CkSel"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""IsReversed"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""ReverseIndex"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""InvNum"">
                                                        <NODE NodeID=""Node#8"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""ReverseDate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""ApprovedAmt"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""IsDisplayReports"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""PayeeSite"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Description"">
                                                        <NODE NodeID=""Node#9"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""ReverseReason"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Description"">
                                                        <NODE NodeID=""Node#10"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""VchrStatus"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Description"">
                                                        <NODE NodeID=""Node#11"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""GroupNum"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""LoadNum"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""LoadSource"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""IsSeparateCheck"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""UnitCurrRate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""FirmCurrRate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""TaxDate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""VchrAutoNumber"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Rpt1CurrRate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Rpt2CurrRate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Rpt3CurrRate"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""FiscalInvNum"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""VchrPayStatusList"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Description"">
                                                        <NODE NodeID=""Node#12"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""PayeeAccount"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""IncurPayee"">
                                                        <NODE NodeID=""Node#13"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""ConversionRefNum"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""WithholdingTaxRef"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""IsZeroCk"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""CkReqUser"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""BaseUserName"">
                                                        <NODE NodeID=""Node#14"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""CkReqTimekeeper"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Number"">
                                                        <NODE NodeID=""Node#15"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""CkReqComments"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""WF_VchrApprover"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""BaseUserName"">
                                                        <NODE NodeID=""Node#16"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""WF_OfficePayment"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""WF_ReturnCheckTo"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""BaseUserName"">
                                                        <NODE NodeID=""Node#17"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""WF_ReturnToOffice"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""Description"">
                                                        <NODE NodeID=""Node#18"" />
                                                      </LEAF>
                                                    </VALUE>
                                                    <VALUE>
                                                      <LEAF QueryID=""WF_DateNeeded"">
                                                        <NODE NodeID=""Node#1"" />
                                                      </LEAF>
                                                    </VALUE>
                                                  </VALUES>
                                                  <WHERE>
                                                     <X_IS_EQUAL_TO_Y>
		                                              <X>
			                                            <LEAF QueryID=""VchrIndex"">
			                                              <NODE NodeID=""Node#1"" />
			                                            </LEAF>
		                                              </X>
		                                              <Y>
			                                            <UNICODE_STRING Value=""{0}"" />
		                                              </Y>
		                                            </X_IS_EQUAL_TO_Y>
                                                  </WHERE>
                                                </SINGLE_SELECT>
                                              </SELECT_LIST>
                                            </SELECT>
                                        </QUERY>
            
            ";

        public static string AddVoucherXml = @"
                                        <Voucher_Srv xmlns=""http://elite.com/schemas/transaction/process/write/Voucher_Srv"">
                                            <Initialize xmlns=""http://elite.com/schemas/transaction/object/write/Voucher"">
                                                <Add>
                                                    <Voucher>
                                                        <Attributes>
                                                            <TranDate>@TranDate</TranDate>
                                                            <InvDate>@InvDate</InvDate>
                                                            <InvNum>@InvNum</InvNum>
                                                            <Payee>@Payee</Payee>
                                                            <Currency>@Currency</Currency>
                                                            <CurrDate>@CurrDate</CurrDate>
                                                            <Amount>@Amount</Amount>
                                                            <APTranType>@APTranType</APTranType>
                                                            <Terms>@Terms</Terms>
                                                            <DiscountDate></DiscountDate>
                                                            <DueDate>@DueDate</DueDate>
                                                            <PayDate>@PayDate</PayDate>
                                                            <OpenAmt></OpenAmt>
                                                            <PONum></PONum>
                                                            <PO></PO>
                                                            <POAmt></POAmt>
                                                            <Office>@Office</Office>
                                                            <APGLAcct>@APGLAcct</APGLAcct>
                                                            <PostDate></PostDate>
                                                            <IsPrepaid>0</IsPrepaid>
                                                            <CkSel />
                                                            <IsReversed>0</IsReversed>
                                                            <ReverseIndex />
                                                            <ReverseDate></ReverseDate>
                                                            <ApprovedAmt></ApprovedAmt>
                                                            <IsDisplayReports>0</IsDisplayReports>
                                                            <BankAcctAP />
                                                            <CkDate></CkDate>
                                                            <CkNum></CkNum>
                                                            <PayeeSite>@PSite</PayeeSite>
                                                            <IsPayCkNow>0</IsPayCkNow>
                                                            <IsElecCk>0</IsElecCk>
                                                            <IsSameDay>0</IsSameDay>
                                                            <IsAdvice>0</IsAdvice>
                                                            <Comments>@Comments</Comments>
                                                            <IsDoingCheck>0</IsDoingCheck>
                                                            <DetailSumAmt></DetailSumAmt>
                                                            <DetailRemAmount></DetailRemAmount>
                                                            <PaidAmt></PaidAmt>
                                                            <IsDirectCk>0</IsDirectCk>
                                                            <ReverseReason />
                                                            <DCkIndex></DCkIndex>
                                                            <DCkAmt></DCkAmt>
                                                            <DCkPayee></DCkPayee>
                                                            <DCkCurrency></DCkCurrency>
                                                            <DCkCkNum></DCkCkNum>
                                                            <DCkCkDate></DCkCkDate>
                                                            <OrigVchrAmt></OrigVchrAmt>
                                                            <IsAuthorized>1</IsAuthorized>
                                                            <VchrStatus>AUTHORIZED</VchrStatus>
                                                            <OrigGLAcct></OrigGLAcct>
                                                            <OrigVDGLCount>2</OrigVDGLCount>
                                                            <ApprovedDate></ApprovedDate>
                                                            <DMVoucher />
                                                            <UnapprovedAmt></UnapprovedAmt>
                                                            <PayBankAcct />
                                                            <IsReverseFlag>0</IsReverseFlag>
                                                            <OrigCostCardCount>1</OrigCostCardCount>
                                                            <IsDM>0</IsDM>
                                                            <IsPartialPaid>0</IsPartialPaid>
                                                            <NxPrinter />
                                                            <NxPrinterTemplate />
                                                            <GroupNum></GroupNum>
                                                            <LoadNum></LoadNum>
                                                            <LoadSource></LoadSource>
                                                            <Counter></Counter>
                                                            <IsVendorCreditFlag>0</IsVendorCreditFlag>
                                                            <OrigVTAXCount>0</OrigVTAXCount>
                                                            <IsSeparateCheck>0</IsSeparateCheck>
                                                            <UnitCurrRate></UnitCurrRate>
                                                            <FirmCurrRate></FirmCurrRate>
                                                            <DCkBankAcctAP />
                                                            <QCIndex />
                                                            <TaxDate>@TaxDate</TaxDate>
                                                            <QCSelIndex>0</QCSelIndex>
                                                            <FileName></FileName>
                                                            <DCSOutputFolder></DCSOutputFolder>
                                                            <PaperTemplate />
                                                            <ElectronicTemplate />
                                                            <VchrAutoNumber></VchrAutoNumber>
                                                            <Rpt1CurrRate>0</Rpt1CurrRate>
                                                            <Rpt2CurrRate>0</Rpt2CurrRate>
                                                            <Rpt3CurrRate>0</Rpt3CurrRate>
                                                            <FiscalInvNum></FiscalInvNum>
                                                            <VchrPayStatusList>PF</VchrPayStatusList>
                                                            <PayeeAccount />
                                                            <DCkAPTranType></DCkAPTranType>
                                                            <IsPrepaidWire>0</IsPrepaidWire>
                                                            <DCSOutputSubfolder></DCSOutputSubfolder>
                                                            <IsRemittanceSent>0</IsRemittanceSent>
                                                            <RemittanceDeliveryMethodList />
                                                            <RemittanceTemplate />
                                                            <ElecRemittanceTemplate />
                                                            <PaperRemittanceTemplate />
                                                            <SiteEmailAddr></SiteEmailAddr>
                                                            <RemittanceEmailFromAddr></RemittanceEmailFromAddr>
                                                            <RemittanceEmailSubj></RemittanceEmailSubj>
                                                            <ElecRemittanceEmailFromAddr></ElecRemittanceEmailFromAddr>
                                                            <PaperRemittanceEmailFromAddr></PaperRemittanceEmailFromAddr>
                                                            <ElecRemittanceEmailSubj></ElecRemittanceEmailSubj>
                                                            <PaperRemittanceEmailSubj></PaperRemittanceEmailSubj>
                                                            <RemittanceFileName></RemittanceFileName>
                                                            <ElecElecRemittanceTemplate />
                                                            <PaperElecRemittanceTemplate />
                                                            <IsAddedAuto>0</IsAddedAuto>
                                                            <PORcptHeadID></PORcptHeadID>
                                                            <WithholdingTaxRef></WithholdingTaxRef>
                                                            <OrigVWHTCount>0</OrigVWHTCount>
                                                            <IsZeroCk>0</IsZeroCk>
                                                            <ZeroVoucherCkDate></ZeroVoucherCkDate>
                                                            <ZeroVoucherCkNum></ZeroVoucherCkNum>
                                                            <ZeroVoucherBank />
                                                            <doWHTax>1</doWHTax>
                                                            <CkReqComments></CkReqComments>
                                                            <CkReqTimekeeper />
                                                            <CkReqUser />
                                                        </Attributes>
                                                        <Children>
                                                           {0}
                                                           {1}
                                                        </Children>
                                                    </Voucher>
                                                </Add>
                                            </Initialize>
                                        </Voucher_Srv>


            ";

        public static string AddCompleteVoucherXml = @"
                                        <Voucher_Srv xmlns=""http://elite.com/schemas/transaction/process/write/Voucher_Srv"">
                                            <Initialize xmlns=""http://elite.com/schemas/transaction/object/write/Voucher"">
                                                <Add>
                                                    <Voucher>
                                                        <Attributes>
                                                            <TranDate>@TranDate</TranDate>
                                                            <InvDate>@InvDate</InvDate>
                                                            <InvNum>@InvNum</InvNum>
                                                            <Payee>@Payee</Payee>
                                                            <Currency>@Currency</Currency>
                                                            <CurrDate>@CurrDate</CurrDate>
                                                            <Amount>@Amount</Amount>
                                                            <APTranType>@APTranType</APTranType>
                                                            <Terms>@Terms</Terms>
                                                            <DiscountDate></DiscountDate>
                                                            <DueDate>@DueDate</DueDate>
                                                            <PayDate>@PayDate</PayDate>
                                                            <OpenAmt></OpenAmt>
                                                            <PONum></PONum>
                                                            <PO></PO>
                                                            <POAmt></POAmt>
                                                            <Office>@Office</Office>
                                                            <APGLAcct>@APGLAcct</APGLAcct>
                                                            <PostDate></PostDate>
                                                            <IsPrepaid>0</IsPrepaid>
                                                            <CkSel />
                                                            <IsReversed>0</IsReversed>
                                                            <ReverseIndex />
                                                            <ReverseDate></ReverseDate>
                                                            <ApprovedAmt></ApprovedAmt>
                                                            <IsDisplayReports>0</IsDisplayReports>
                                                            <BankAcctAP />
                                                            <CkDate></CkDate>
                                                            <CkNum></CkNum>
                                                            <PayeeSite>@PSite</PayeeSite>
                                                            <IsPayCkNow>0</IsPayCkNow>
                                                            <IsElecCk>0</IsElecCk>
                                                            <IsSameDay>0</IsSameDay>
                                                            <IsAdvice>0</IsAdvice>
                                                            <Comments>@Comments</Comments>
                                                            <IsDoingCheck>0</IsDoingCheck>
                                                            <DetailSumAmt></DetailSumAmt>
                                                            <DetailRemAmount></DetailRemAmount>
                                                            <PaidAmt></PaidAmt>
                                                            <IsDirectCk>0</IsDirectCk>
                                                            <ReverseReason />
                                                            <DCkIndex></DCkIndex>
                                                            <DCkAmt></DCkAmt>
                                                            <DCkPayee></DCkPayee>
                                                            <DCkCurrency></DCkCurrency>
                                                            <DCkCkNum></DCkCkNum>
                                                            <DCkCkDate></DCkCkDate>
                                                            <OrigVchrAmt></OrigVchrAmt>
                                                            <IsAuthorized>1</IsAuthorized>
                                                            <VchrStatus>AUTHORIZED</VchrStatus>
                                                            <OrigGLAcct></OrigGLAcct>
                                                            <OrigVDGLCount>@OrigVDGLCount</OrigVDGLCount>
                                                            <ApprovedDate></ApprovedDate>
                                                            <DMVoucher />
                                                            <UnapprovedAmt></UnapprovedAmt>
                                                            <PayBankAcct />
                                                            <IsReverseFlag>0</IsReverseFlag>
                                                            <OrigCostCardCount>@OrigCostCardCount</OrigCostCardCount>
                                                            <IsDM>0</IsDM>
                                                            <IsPartialPaid>0</IsPartialPaid>
                                                            <NxPrinter />
                                                            <NxPrinterTemplate />
                                                            <GroupNum></GroupNum>
                                                            <LoadNum></LoadNum>
                                                            <LoadSource></LoadSource>
                                                            <Counter></Counter>
                                                            <IsVendorCreditFlag>0</IsVendorCreditFlag>
                                                            <OrigVTAXCount>0</OrigVTAXCount>
                                                            <IsSeparateCheck>0</IsSeparateCheck>
                                                            <UnitCurrRate></UnitCurrRate>
                                                            <FirmCurrRate></FirmCurrRate>
                                                            <DCkBankAcctAP />
                                                            <QCIndex />
                                                            <TaxDate>@TaxDate</TaxDate>
                                                            <QCSelIndex>0</QCSelIndex>
                                                            <FileName></FileName>
                                                            <DCSOutputFolder></DCSOutputFolder>
                                                            <PaperTemplate />
                                                            <ElectronicTemplate />
                                                            <VchrAutoNumber></VchrAutoNumber>
                                                            <Rpt1CurrRate>0</Rpt1CurrRate>
                                                            <Rpt2CurrRate>0</Rpt2CurrRate>
                                                            <Rpt3CurrRate>0</Rpt3CurrRate>
                                                            <FiscalInvNum></FiscalInvNum>
                                                            <VchrPayStatusList>PF</VchrPayStatusList>
                                                            <PayeeAccount />
                                                            <DCkAPTranType></DCkAPTranType>
                                                            <IsPrepaidWire>0</IsPrepaidWire>
                                                            <DCSOutputSubfolder></DCSOutputSubfolder>
                                                            <IsRemittanceSent>0</IsRemittanceSent>
                                                            <RemittanceDeliveryMethodList />
                                                            <RemittanceTemplate />
                                                            <ElecRemittanceTemplate />
                                                            <PaperRemittanceTemplate />
                                                            <SiteEmailAddr></SiteEmailAddr>
                                                            <RemittanceEmailFromAddr></RemittanceEmailFromAddr>
                                                            <RemittanceEmailSubj></RemittanceEmailSubj>
                                                            <ElecRemittanceEmailFromAddr></ElecRemittanceEmailFromAddr>
                                                            <PaperRemittanceEmailFromAddr></PaperRemittanceEmailFromAddr>
                                                            <ElecRemittanceEmailSubj></ElecRemittanceEmailSubj>
                                                            <PaperRemittanceEmailSubj></PaperRemittanceEmailSubj>
                                                            <RemittanceFileName></RemittanceFileName>
                                                            <ElecElecRemittanceTemplate />
                                                            <PaperElecRemittanceTemplate />
                                                            <IsAddedAuto>0</IsAddedAuto>
                                                            <PORcptHeadID></PORcptHeadID>
                                                            <WithholdingTaxRef></WithholdingTaxRef>
                                                            <OrigVWHTCount>0</OrigVWHTCount>
                                                            <IsZeroCk>0</IsZeroCk>
                                                            <ZeroVoucherCkDate></ZeroVoucherCkDate>
                                                            <ZeroVoucherCkNum></ZeroVoucherCkNum>
                                                            <ZeroVoucherBank />
                                                            <doWHTax>0</doWHTax>
                                                            <CkReqComments></CkReqComments>
                                                            <CkReqTimekeeper />
                                                            <CkReqUser />
                                                        </Attributes>
                                                        <Children>
                                                           {0}
                                                           {1}
                                                           {2}
                                                        </Children>
                                                    </Voucher>
                                                </Add>
                                            </Initialize>
                                        </Voucher_Srv>


            ";

        public static string AddVchr1099 = @"<Vchr1099>
                                            <Add>
                                                <Vchr1099>
                                                    <Attributes>
                                                        <Flag1099>@Flag1099</Flag1099>
                                                        <Currency>USD</Currency>
                                                        <Amount>@Amount</Amount>
                                                        <PaidAmt></PaidAmt>
                                                    </Attributes>
                                              </Vchr1099>
                                            </Add>
                                        </Vchr1099>
                                        ";


        public static string AddVrchCost = @"<Add>
                                                <VchrCost>
                                                    <Attributes>
                                                        <WorkDate>@WorkDate</WorkDate>
                                                        <PostDate></PostDate>
                                                        <Currency>@Currency</Currency>
                                                        <CurrDate>@CurrDate</CurrDate>
                                                        <Matter>@MatterIndex</Matter>
                                                        <Timekeeper>@Timekeeper</Timekeeper>
                                                        <OrigAmt>@OrigAmt</OrigAmt>
                                                        <WorkQty>@WorkQty</WorkQty>
                                                        <WorkRate>@WorkRate</WorkRate>
                                                        <WorkAmt>@WorkAmt</WorkAmt>
                                                        <StdRate>@StdRate</StdRate>
                                                        <StdCurrency>USD</StdCurrency>
                                                        <StdAmt>@StdAmt</StdAmt>
                                                        <Narrative>@Narrative</Narrative>
                                                        <CostType>@CostType</CostType>
                                                        <RefCurrency>USD</RefCurrency>
                                                        <RefRate>@RefRate</RefRate>
                                                        <RefAmt>@RefAmt</RefAmt>
                                                        <Language>@Language</Language>
                                                        <Office>@Office</Office>
                                                    </Attributes>
                                              </VchrCost>
                                            </Add>
                                        ";

        public static string AddVcrhDirectGL = @"
                                    <Add>
                                        <VchrDirectGL>
                                            <Attributes>
                                                <GLAcct>@GLAcct</GLAcct>
                                                <Currency>@Currency</Currency>
                                                <CurrDate>@CurrDate</CurrDate>
                                                <Amount>@Amount</Amount>
                                                <TaxCode />
                                                <Timekeeper />
                                                <Office>@Office</Office>
                                                <PostDate></PostDate>
                                                <Project />
                                                <Description>@Description</Description>
                                                <APTranDetailList>@APTranDetailList</APTranDetailList>
                                                <QntInv></QntInv>
                                                <ItemCost></ItemCost>
                                                <UOM />
                                                <ProductCode />
                                                <ProductDesc></ProductDesc>
                                                <LineNum>@LineNumber</LineNum>
                                                <IsActive>1</IsActive>
                                                <IsReversed>0</IsReversed>
                                                <IsQntHold>0</IsQntHold>
                                                <IsPriceHold>0</IsPriceHold>
                                                <IsInspHold>0</IsInspHold>
                                                <IsSupervisorOvrd>0</IsSupervisorOvrd>
                                                <OpenAmt></OpenAmt>
                                                <VchrDetailID></VchrDetailID>
                                                <FAClassType />
                                                <PODetail />
                                                <IsTaxed>0</IsTaxed>
                                                <VchrDetailGroup />
                                                <GLDate>@GLDate</GLDate>
                                                <WithholdingTax />
                                                <IsWHTax>0</IsWHTax>
                                                <IsApproved>1</IsApproved>
                                                <ApprovedDate>@ApprovedDate</ApprovedDate>
                                                <IsPOToVchr>0</IsPOToVchr>
                                                <CurrPODetQtyHold>0</CurrPODetQtyHold>
                                                <CurrPODetQtyApp>0</CurrPODetQtyApp>
                                                <IsMatchPerformed>0</IsMatchPerformed>
                                                <IsReverseCreate>0</IsReverseCreate>
                                                <IsReversal>0</IsReversal>
                                                <FACategory />
                                                <WHTaxReason />
                                                <IsWHTaxed>0</IsWHTaxed>
                                                <IsCreate>1</IsCreate>
                                                <RevDirectGL></RevDirectGL>
                                                <GLAcctLocal />
                                                <OrigDirectGL></OrigDirectGL>
                                                <WF_RspTkpr />
                                            </Attributes>
                                        </VchrDirectGL>
                                    </Add>


                        ";
    }
}
