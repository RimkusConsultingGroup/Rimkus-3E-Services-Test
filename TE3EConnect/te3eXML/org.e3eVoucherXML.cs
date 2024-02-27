using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML
{
    public static class e3eVoucherXMLSample
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
                                        <Voucher xmlns=""http://elite.com/schemas/transaction/process/write/Voucher"">
                                            <Initialize xmlns=""http://elite.com/schemas/transaction/object/write/Voucher"">
                                                <Add>
                                                    <Voucher>
                                                        <Attributes>
                                                            <TranDate>2019-01-14T00:00:00</TranDate>
                                                            <InvDate>2019-01-14T00:00:00</InvDate>
                                                            <InvNum />
                                                            <Payee>5995</Payee>
                                                            <Currency>USD</Currency>
                                                            <CurrDate>2010-01-21T00:00:00</CurrDate>
                                                            <Amount>10046.85</Amount>
                                                            <APTranType>INV</APTranType>
                                                            <Terms>UPONREC</Terms>
                                                            <DiscountDate></DiscountDate>
                                                            <DueDate>2019-01-21T00:00:00</DueDate>
                                                            <PayDate>2019-01-15T00:00:00</PayDate>
                                                            <OpenAmt>1</OpenAmt>
                                                            <PONum></PONum>
                                                            <PO />
                                                            <POAmt>2</POAmt>
                                                            <Office>01100</Office>
                                                            <APGLAcct>21101</APGLAcct>
                                                            <PostDate>2019-01-15T00:00:00</PostDate>
                                                            <IsPrepaid>1</IsPrepaid>
                                                            <CkSel />
                                                            <IsReversed>0</IsReversed>
                                                            <ReverseIndex />
                                                            <ReverseDate></ReverseDate>
                                                            <ApprovedAmt>10046.85</ApprovedAmt>
                                                            <IsDisplayReports>0</IsDisplayReports>
                                                            <BankAcctAP />
                                                            <CkDate></CkDate>
                                                            <CkNum></CkNum>
                                                            <PayeeSite>5995</PayeeSite>
                                                            <IsPayCkNow>1</IsPayCkNow>
                                                            <IsElecCk>1</IsElecCk>
                                                            <IsSameDay>1</IsSameDay>
                                                            <IsAdvice>1</IsAdvice>
                                                            <Comments>bei-c</Comments>
                                                            <IsDoingCheck>1</IsDoingCheck>
                                                            <DetailSumAmt>10046.85</DetailSumAmt>
                                                            <DetailRemAmount>1</DetailRemAmount>
                                                            <PaidAmt>10046.85</PaidAmt>
                                                            <IsDirectCk>1</IsDirectCk>
                                                            <ReverseReason />
                                                            <DCkIndex>2</DCkIndex>
                                                            <DCkAmt>2</DCkAmt>
                                                            <DCkPayee>2</DCkPayee>
                                                            <DCkCurrency></DCkCurrency>
                                                            <DCkCkNum></DCkCkNum>
                                                            <DCkCkDate></DCkCkDate>
                                                            <OrigVchrAmt>10046.85</OrigVchrAmt>
                                                            <IsAuthorized>0</IsAuthorized>
                                                            <VchrStatus>AUTHORIZED</VchrStatus>
                                                            <OrigGLAcct>21101</OrigGLAcct>
                                                            <OrigVDGLCount>2</OrigVDGLCount>
                                                            <ApprovedDate></ApprovedDate>
                                                            <DMVoucher />
                                                            <UnapprovedAmt>1</UnapprovedAmt>
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
                                                            <UnitCurrRate>2</UnitCurrRate>
                                                            <FirmCurrRate>2</FirmCurrRate>
                                                            <DCkBankAcctAP />
                                                            <QCIndex />
                                                            <TaxDate>2019-01-14T00:00:00</TaxDate>
                                                            <QCSelIndex>2</QCSelIndex>
                                                            <FileName></FileName>
                                                            <DCSOutputFolder></DCSOutputFolder>
                                                            <PaperTemplate />
                                                            <ElectronicTemplate />
                                                            <VchrAutoNumber>00294-2</VchrAutoNumber>
                                                            <Rpt1CurrRate>2</Rpt1CurrRate>
                                                            <Rpt2CurrRate>2</Rpt2CurrRate>
                                                            <Rpt3CurrRate>2</Rpt3CurrRate>
                                                            <FiscalInvNum></FiscalInvNum>
                                                            <VchrPayStatusList>PF</VchrPayStatusList>
                                                            <PayeeAccount />
                                                            <DCkAPTranType></DCkAPTranType>
                                                            <IsPrepaidWire>1</IsPrepaidWire>
                                                            <DCSOutputSubfolder></DCSOutputSubfolder>
                                                            <IsRemittanceSent>1</IsRemittanceSent>
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
                                                            <OrigVWHTCount>1</OrigVWHTCount>
                                                            <IsZeroCk>1</IsZeroCk>
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
                                        </Voucher>


            ";

        public static string Vchr1099 = @"<Vchr1099>
                                            <Add>
                                                <Vchr1099>
                                                    <Attributes>
                                                        <Flag1099>N</Flag1099>
                                                        <Amount>8594.35</Amount>
                                                    </Attributes>
                                              </Vchr1099>
                                            </Add>
                                        </Vchr1099>
                                        ";


        public static string VrchCost = @"<VchrCost>
                                            <Add>
                                                <VchrCost>
                                                    <Attributes>
                                                        <WorkDate>9/24/2018 12:00:00 AM</WorkDate>
                                                        <PostDate>9/24/2018 12:00:00 AM</PostDate>
                                                        <Currency>USD</Currency>
                                                        <CurrDate>9/24/2018 12:00:00 AM</CurrDate>
                                                        <Matter>7206</Matter>
                                                        <Timekeeper>2078</Timekeeper>
                                                        <OrigAmt>30.00</OrigAmt>
                                                        <WorkQty>0.00000</WorkQty>
                                                        <WorkRate>0.0000</WorkRate>
                                                        <WorkAmt>0.00</WorkAmt>
                                                        <StdRate>0.0000</StdRate>
                                                        <StdCurrency>USD</StdCurrency>
                                                        <StdAmt>0.00</StdAmt>
                                                        <Narrative>Billing Adjustment at conv</Narrative>
                                                        <CostType>1016</CostType>
                                                        <RefCurrency>USD</RefCurrency>
                                                        <RefRate>0.0000</RefRate>
                                                        <RefAmt>0.00</RefAmt>
                                                        <Language>1033</Language>
                                                        <Office>01100</Office>
                                                    </Attributes>
                                              </VchrCost>
                                            </Add>
                                             <Add>
                                                <VchrCost>
                                                    <Attributes>
                                                        <WorkDate>9/24/2018 12:00:00 AM</WorkDate>
                                                        <PostDate>9/24/2018 12:00:00 AM</PostDate>
                                                        <Currency>USD</Currency>
                                                        <CurrDate>9/24/2018 12:00:00 AM</CurrDate>
                                                        <Matter>7206</Matter>
                                                        <Timekeeper>2078</Timekeeper>
                                                        <OrigAmt>20.00</OrigAmt>
                                                        <WorkQty>0.00000</WorkQty>
                                                        <WorkRate>0.0000</WorkRate>
                                                        <WorkAmt>0.00</WorkAmt>
                                                        <StdRate>0.0000</StdRate>
                                                        <StdCurrency>USD</StdCurrency>
                                                        <StdAmt>0.00</StdAmt>
                                                        <Narrative>Billing Adjustment at conv</Narrative>
                                                        <CostType>1016</CostType>
                                                        <RefCurrency>USD</RefCurrency>
                                                        <RefRate>0.0000</RefRate>
                                                        <RefAmt>0.00</RefAmt>
                                                        <Language>1033</Language>
                                                        <Office>01100</Office>
                                                    </Attributes>
                                              </VchrCost>
                                            </Add>
                                            </VchrCost>
                                        ";

        public static string VcrhDirectGL = @"
                                 <VchrDirectGL>
                                    <Add>
                                        <VchrDirectGL>
                                            <Attributes>
                                                <GLAcct>1638</GLAcct>
                                                <Currency>USD</Currency>
                                                <CurrDate>2010-01-21T00:00:00</CurrDate>
                                                <Amount>10046.85</Amount>
                                                <TaxCode />
                                                <Timekeeper />
                                                <Office>01100</Office>
                                                <PostDate>2019-01-15T00:00:00</PostDate>
                                                <Project />
                                                <Description>D&amp;O and Professional Liability insurance policies (12/20/09 thru 12/20/10)</Description>
                                                <APTranDetailList>PR</APTranDetailList>
                                                <QntInv></QntInv>
                                                <ItemCost></ItemCost>
                                                <UOM />
                                                <ProductCode />
                                                <ProductDesc></ProductDesc>
                                                <LineNum>2</LineNum>
                                                <IsActive>0</IsActive>
                                                <IsReversed>1</IsReversed>
                                                <IsQntHold>1</IsQntHold>
                                                <IsPriceHold>1</IsPriceHold>
                                                <IsInspHold>1</IsInspHold>
                                                <IsSupervisorOvrd>1</IsSupervisorOvrd>
                                                <OpenAmt>1</OpenAmt>
                                                <VchrDetailID>8cb96c47-8f08-48e3-b672-880ef17495e5</VchrDetailID>
                                                <FAClassType />
                                                <PODetail />
                                                <IsTaxed>0</IsTaxed>
                                                <VchrDetailGroup />
                                                <GLDate>2010-01-21T00:00:00</GLDate>
                                                <WithholdingTax />
                                                <IsWHTax>1</IsWHTax>
                                                <IsApproved>0</IsApproved>
                                                <ApprovedDate>2019-01-14T00:00:00</ApprovedDate>
                                                <IsPOToVchr>1</IsPOToVchr>
                                                <CurrPODetQtyHold>2</CurrPODetQtyHold>
                                                <CurrPODetQtyApp>2</CurrPODetQtyApp>
                                                <IsMatchPerformed>1</IsMatchPerformed>
                                                <IsReverseCreate>1</IsReverseCreate>
                                                <IsReversal>1</IsReversal>
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
                                    <Add>
                                        <VchrDirectGL>
                                            <Attributes>
                                                <GLAcct>1638</GLAcct>
                                                <Currency>USD</Currency>
                                                <CurrDate>2010-01-21T00:00:00</CurrDate>
                                                <Amount>500.85</Amount>
                                                <TaxCode />
                                                <Timekeeper />
                                                <Office>01100</Office>
                                                <PostDate>2019-01-15T00:00:00</PostDate>
                                                <Project />
                                                <Description>D&amp;O and Professional Liability insurance policies (12/20/09 thru 12/20/10)</Description>
                                                <APTranDetailList>PR</APTranDetailList>
                                                <QntInv></QntInv>
                                                <ItemCost></ItemCost>
                                                <UOM />
                                                <ProductCode />
                                                <ProductDesc></ProductDesc>
                                                <LineNum>2</LineNum>
                                                <IsActive>0</IsActive>
                                                <IsReversed>1</IsReversed>
                                                <IsQntHold>1</IsQntHold>
                                                <IsPriceHold>1</IsPriceHold>
                                                <IsInspHold>1</IsInspHold>
                                                <IsSupervisorOvrd>1</IsSupervisorOvrd>
                                                <OpenAmt>1</OpenAmt>
                                                <VchrDetailID>8cb96c47-8f08-48e3-b672-880ef17495e5</VchrDetailID>
                                                <FAClassType />
                                                <PODetail />
                                                <IsTaxed>0</IsTaxed>
                                                <VchrDetailGroup />
                                                <GLDate>2010-01-21T00:00:00</GLDate>
                                                <WithholdingTax />
                                                <IsWHTax>1</IsWHTax>
                                                <IsApproved>0</IsApproved>
                                                <ApprovedDate>2019-01-14T00:00:00</ApprovedDate>
                                                <IsPOToVchr>1</IsPOToVchr>
                                                <CurrPODetQtyHold>2</CurrPODetQtyHold>
                                                <CurrPODetQtyApp>2</CurrPODetQtyApp>
                                                <IsMatchPerformed>1</IsMatchPerformed>
                                                <IsReverseCreate>1</IsReverseCreate>
                                                <IsReversal>1</IsReversal>
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
                                </VchrDirectGL>


                        ";
    }
}
