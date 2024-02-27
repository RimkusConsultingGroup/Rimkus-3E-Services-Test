using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML
{
    public static class e3eCollectionItemXML
    {
        public static string AddCollectionStepXML = @"
        <CollectionItem xmlns=""http://elite.com/schemas/transaction/process/write/CollectionItem"">
        <Initialize xmlns = ""http://elite.com/schemas/transaction/object/write/CollectionItem"">
        <Edit>
            <MatterCollectionItem KeyValue=""@collectionItem"">
                <Children>
                    <CollectionStep>
                        <Add>
                            <CollectionStep>
                                <Attributes>
                                    <StepNumber>@stepNo</StepNumber>
                                    <Action>@action</Action>
                                    <Collector>@collectorName</Collector>
                                    <ActionPriority>0</ActionPriority>
                                    <IsDoneIfInvIsPaid>0</IsDoneIfInvIsPaid>
                                    <IsDoneImmediately>0</IsDoneImmediately>
                                    <DaysAfter>@daysAfter</DaysAfter>
                                    <DateSourceTypeList>InvoiceDueDate</DateSourceTypeList>
                                    <ActionByTypeList>System</ActionByTypeList>
                                    <Comments>@comments</Comments>
                                    <IsCompleted>1</IsCompleted>
                                    <CompletedBy>@completedBy</CompletedBy>
                                    <CollectionActorList>System</CollectionActorList>
                                    <ScheduledDate>@scheduledDate</ScheduledDate>
                                    <ActionByUnbound>Manual</ActionByUnbound>
                                    <CollectionActorListUnbound>System</CollectionActorListUnbound>
                                    <CollectorUnbound></CollectorUnbound>
                                    <ScheduledDateUnbound>@schedDateUnbound</ScheduledDateUnbound>
                                    <PrinterTemplate>@printerTemplate</PrinterTemplate>
                                    <EmailAddr>@emailAddr</EmailAddr>
                                    <EmailSubject>@emailSubject</EmailSubject>
                                    <IsStepRepeated>0</IsStepRepeated>
                                    <EmailFromAddress>@emailFromAddress</EmailFromAddress>
                                    <EmailCCAddress>@emailCCAddress</EmailCCAddress>
                                    <EmailBCCAddress>@emailBCCAddress</EmailBCCAddress>
                                    <BillingOffice>001</BillingOffice>
                                    <MatterLanguage>1033</MatterLanguage>
                                    <CollectionOffice>000</CollectionOffice>
                                </Attributes>
                            </CollectionStep>
                        </Add>
                    </CollectionStep>
                </Children>
            </MatterCollectionItem>
        </Edit>
    </Initialize>
</CollectionItem>
                                                    ";

    }
}
