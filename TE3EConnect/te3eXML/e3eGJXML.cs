using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML
{
    public class e3eGJXML
    {
        public static string AddGJXml = @"

        <GJ_CCC xmlns=""http://elite.com/schemas/transaction/process/write/GJ_CCC"">
    <Initialize xmlns = ""http://elite.com/schemas/transaction/object/write/GJ"" >
        <Add>
            <GJ>
                <Attributes>
                    <TranDate>@TranDate</TranDate>
                    <GLType>@GLType</GLType>
                    <PostDate>@PostDate</PostDate>
                    <Description>@Description</Description>
                    <NxUnit>@Unit</NxUnit>
                    <PostSourceList>GJ</PostSourceList>
                    <JM></JM>
                    <IsCalcForEx>@IsCalcForEx</IsCalcForEx>
                    <PostFlag>1</PostFlag>
                    <IsReversal>0</IsReversal>
                    <CreatedBy />
                    <IsDisplayOnly>1</IsDisplayOnly>
                    <PostMsgQueue />
                    <SeqNumInvMaster />
                    <SeqNumRcptMaster />
                    <SeqNumVoucher />
                    <SeqNumCkMaster />
                    <JMProcessGUID></JMProcessGUID>
                    <JMProcessTimeStamp></JMProcessTimeStamp>
                    <GJTranNum>@GJTranNum</GJTranNum>
                    <IsAutoReversed>@IsReversed</IsAutoReversed>
                    <Category>@Category</Category>
                    <CurrDate>@CurrDate</CurrDate>
                    <Currency>@Currency</Currency>
                    <BankRefNum></BankRefNum>
                    <ReversesJnl />
                    <ReversedBy />
                    <IsIntercurrency>0</IsIntercurrency>
                    <TotalTranDebit>@TotalTranDebit</TotalTranDebit>
                    <TotalTranCredit>@TotalTranCredit</TotalTranCredit>
                    <IsReconciled>1</IsReconciled>
                    <RevPostDate></RevPostDate>
                    <RevTranDate></RevTranDate>
                    <IsReversed>0</IsReversed>
                    <ReversalReason></ReversalReason>
                    <IntercoMethod>0</IntercoMethod>
                    <ReverseTo>@ReverseTo</ReverseTo>
                    <PostUnitOnly>1</PostUnitOnly>
                    <PostFirmOnly>1</PostFirmOnly>
                    <GJBatch />
                    <PostDateTemp></PostDateTemp>
                    <GJSeqNum></GJSeqNum>
                    <GLClearHdr />
                    <UnrealizedGainLoss />
                    <IsSystemGenerated>1</IsSystemGenerated>
                    <IsRecurringJE>0</IsRecurringJE>
                    <IsSpotRate>0</IsSpotRate>
                    <IsSeqNumGenerated>1</IsSeqNumGenerated>
                    <CashJournal />
                    <RevalAsOfDate />
                    <IsAllowIntercompanyGJ>@IsAllowIntercompanyGJ</IsAllowIntercompanyGJ>
                    <IsAllowControlAccount>0</IsAllowControlAccount>
                    <IsDoNotCreateCJ>1</IsDoNotCreateCJ>
                    <RejectReason_CCC></RejectReason_CCC>
                </Attributes>
                <Children>
                    <GJDetail1>
                        {0}
                    </GJDetail1>
                </Children>
            </GJ>
        </Add>
    </Initialize>
</GJ_CCC>

        ";

        public static string AddGJDetail = @"
            <Add>
                            <GJDetail1>
                                <Attributes>
                                    <CurrDate>@CurrDate</CurrDate>
                                    <Currency>USD</Currency>
                                    <Amount></Amount>
                                    <Description>@Description</Description>
                                    <GLAcct>@GLAcct</GLAcct>
                                    <IsDebit>@IsDebit</IsDebit>
                                    <GLDetail></GLDetail>
                                    <UnitCurr>USD</UnitCurr>
                                    <UnitCurrAmt></UnitCurrAmt>
                                    <UnitCurrRate></UnitCurrRate>
                                    <FirmCurr>USD</FirmCurr>
                                    <FirmCurrAmt></FirmCurrAmt>
                                    <FirmCurrRate></FirmCurrRate>
                                    <LineType>ST</LineType>
                                    <IsAnchor>0</IsAnchor>
                                    <GLProject />
                                    <RefUnitRate></RefUnitRate>
                                    <RefFirmRate></RefFirmRate>
                                    <GLAcctMask />
                                    <MaskNameList></MaskNameList>
                                    <TranTypeValueList />
                                    <IsDisplayOnly>1</IsDisplayOnly>
                                    <Rpt1Curr />
                                    <Rpt1Amt></Rpt1Amt>
                                    <Rpt1Rate></Rpt1Rate>
                                    <Rpt1RefRate></Rpt1RefRate>
                                    <Rpt2Curr />
                                    <Rpt2Amt></Rpt2Amt>
                                    <Rpt2Rate></Rpt2Rate>
                                    <Rpt2RefRate></Rpt2RefRate>
                                    <Rpt3Curr />
                                    <Rpt3Amt></Rpt3Amt>
                                    <Rpt3Rate></Rpt3Rate>
                                    <Rpt3RefRate></Rpt3RefRate>
                                    <GLRespTkpr />
                                    <GLClearReg />
                                    <ConvertedByList></ConvertedByList>
                                    <TransInfo1></TransInfo1>
                                    <TransInfo3></TransInfo3>
                                    <TransInfo4></TransInfo4>
                                    <TransInfo5></TransInfo5>
                                    <TransInfo6></TransInfo6>
                                    <TransInfo2></TransInfo2>
                                    <AnchorSegment />
                                    <LineNum>@LineNum</LineNum>
                                    <Timekeeper />
                                    <OrigCurr>USD</OrigCurr>
                                    <OrigDR>@OrigDR</OrigDR>
                                    <OrigCR>@OrigCR</OrigCR>
                                    <CurrencyRate>1</CurrencyRate>
                                    <TranDR>@OrigDR</TranDR>
                                    <TranCR>@OrigCR</TranCR>
                                    <IsRateOverride>1</IsRateOverride>
                                    <TotSubledgerDR></TotSubledgerDR>
                                    <TotSubledgerCR></TotSubledgerCR>
                                    <BasePost />
                                    <IsUserAllowSubledger>0</IsUserAllowSubledger>
                                    <BankRefNum>NewValue</BankRefNum>
                                    <IsCalculateRate>1</IsCalculateRate>
                                    <IsSystemChange>1</IsSystemChange>
                                    <IsInCode>1</IsInCode>
                                    <IsOverrideUnitFirmCurrency>1</IsOverrideUnitFirmCurrency>
                                    <GLAcctHold />
                                    <IsCashAccount>1</IsCashAccount>
                                </Attributes>
                            </GJDetail1>
                        </Add>
            
            
            ";
    }
}
