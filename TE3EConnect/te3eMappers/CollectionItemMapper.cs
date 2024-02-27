using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TE3EConnect.te3eXML;

namespace TE3EConnect.te3eMappers
{
    internal class CollectionItemMapper
    {
        public static string ConvertColStepToXml(CollectionStep collectionStep)
        {
            string csXml = e3eCollectionItemXML.AddCollectionStepXML
                                          .Replace("@collectionItem", collectionStep.CollectionItem)
                                          .Replace("@stepNo", collectionStep.StepNumber)
                                          .Replace("@action", collectionStep.Action)
                                          .Replace("@comments", collectionStep.Comments)
                                          .Replace("@scheduledDate", collectionStep.ScheduledDate)
                                          .Replace("@schedDateUnbound", collectionStep.ScheduledDateUnbound)
                                          .Replace("@emailAddr", collectionStep.EmailAddr)
                                          .Replace("@emailSubject", collectionStep.EmailSubject)
                                          .Replace("@emailFromAddress", collectionStep.EmailFromAddress)
                                          .Replace("@emailCCAddress", collectionStep.EmailCCAddress)
                                          .Replace("@emailBCCAddress", collectionStep.EmailBCCAddress)
                                          .Replace("@collectorName", collectionStep.Collector)
                                          .Replace("@printerTemplate", collectionStep.PrinterTemplate)
                                          .Replace("@daysAfter", collectionStep.DaysAfter)
                                          .Replace("@completedBy", collectionStep.CompletedBy);
                                          //.Replace("@collectionOffice", collectionStep.CollectionOffice);

            return csXml;
        }
    }
}
