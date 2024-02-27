using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TE3EConnect.te3eObjects.Automation;

namespace TE3EConnect.te3eMappers.Automation
{
    internal class POEntrySrvMapper
    {
        public static string ConvertPOEntrySrvToXml(POEntrySrv pOEntrySrv, e3eMode e3EMode)
        {
            string csXml = "";
            string strTemplate = "POEntry_Srv.xml";
            
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "te3eXML", "Automation",strTemplate);
            using (var objStreamReader = File.OpenText(path))
            {
                csXml = objStreamReader.ReadToEnd();
                csXml = csXml.Replace("@AddPOEntry", e3EMode == e3eMode.Add ? ConvertAddPOEntry(pOEntrySrv) : "");

            }

            return csXml;
        }

        #region add POReqWFCCC conversion
        private static string ConvertAddPOEntry(POEntrySrv pOEntrySrv)
        {
            StringBuilder sb = new StringBuilder();
            
            string csXml = AddPOEntryXml;
            csXml = csXml.Replace("@PONum", pOEntrySrv.pOReq.PONum)
                         .Replace("@PayeeSite", pOEntrySrv.pOReq.PayeeSite)
                         .Replace("@Payee", pOEntrySrv.pOReq.Payee)
                         .Replace("@RequestNxUser", pOEntrySrv.pOReq.RequestNxUser)
                         .Replace("@DateOrdered", pOEntrySrv.pOReq.DateOrdered)
                         .Replace("@Terms", pOEntrySrv.pOReq.Terms)
                         .Replace("@BillSite", pOEntrySrv.pOReq.BillSite)
                         .Replace("@ShipMethod", pOEntrySrv.pOReq.ShipMethod)
                         .Replace("@ShipInstructions", pOEntrySrv.pOReq.ShipInstructions)
                         .Replace("@Comments", pOEntrySrv.pOReq.Comments.Length >= 255 ? pOEntrySrv.pOReq.Comments.Substring(0, 254) : pOEntrySrv.pOReq.Comments)
                         .Replace("@POMatchList", pOEntrySrv.pOReq.POMatchList)
                         .Replace("@Currency", pOEntrySrv.pOReq.Currency)
                         .Replace("@AddPODetail", pOEntrySrv.pOReqDetails.Count() > 0 ? ConverPODetail(pOEntrySrv.pOReqDetails) : "");

            sb.AppendLine(csXml);

            return sb.ToString();
        }

        private static string ConverPODetail(List<POReqDetail> pOReqDetails)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<PODetail>");
            

            StringBuilder poReqDetSb = new StringBuilder();
            pOReqDetails.ForEach(x =>
            {
                string csXml = AddPOEntryDetailXml;
                csXml = csXml.Replace("@LineNum", x.LineNum)
                             .Replace("@DateRequired", x.DateRequired)
                             .Replace("@Quantity", x.Quantity)
                             .Replace("@ProductCode", x.ProductCode)
                             .Replace("@Description", x.Description)
                             .Replace("@UOM", x.UOM)
                             .Replace("@Office", x.Office)
                             .Replace("@ExpenseGLAcct", x.ExpenseGLAcct)
                             .Replace("@Comments", x.Comments)
                             .Replace("@DeliverNxUser", x.DeliverNxUser)
                             .Replace("@Category", x.Category)
                             .Replace("@Currency", x.Currency)
                             .Replace("@UnitCost", x.UnitCost);

                poReqDetSb.AppendLine(csXml);
            });

            sb.AppendLine(poReqDetSb.ToString());
            sb.AppendLine("</PODetail>");

            return sb.ToString();
        }
        #endregion add POReqWFCCC conversion

        #region add POEntry xml

        private static string AddPOEntryXml = @"

    <Add>
            <PO>
                <Attributes>
                    <PONum>@PONum</PONum>
                    <Payee>@Payee</Payee>
                    <RequestNxUser>@RequestNxUser</RequestNxUser>
                    <OrderNxUser>@RequestNxUser</OrderNxUser>
                    <DateOrdered>@DateOrdered</DateOrdered>
                    <Terms>@Terms</Terms>
                    <BillSite>@BillSite</BillSite>
                    <ShipSite>@BillSite</ShipSite>
                    <ShipMethod>@ShipMethod</ShipMethod>
                    <ShipInstructions>@ShipInstructions</ShipInstructions>
                    <Comments>@Comments</Comments>
                    <IsClosed>0</IsClosed>
                    <PayeeSite>@PayeeSite</PayeeSite>
                    <POMatchList>@POMatchList</POMatchList>
                    <Currency>@Currency</Currency>
                </Attributes>
        <Children>
            @AddPODetail
        </Children>
      </PO>
    </Add>
";

        private static string AddPOEntryDetailXml = @"

    <Add>
        <PODetail>
            <Attributes>
                <DateRequired>@DateRequired</DateRequired>
                <QntOrder>@Quantity</QntOrder>
                <ProductCode>@ProductCode</ProductCode>
                <Description>@Description</Description>
                <Currency>@Currency</Currency>
                <UnitCost>@UnitCost</UnitCost>
                <ExpenseGLAcct>@ExpenseGLAcct</ExpenseGLAcct>
                <Comments>@Comments</Comments>
                <LineNum>@LineNum</LineNum>
                <UOM>@UOM</UOM>
                <Office>@Office</Office>
                <RequestNxUser>@DeliverNxUser</RequestNxUser>
                <IsClosed>0</IsClosed>
                <IsRush>0</IsRush>
                <DeliverNxUser>@DeliverNxUser</DeliverNxUser>
                <Category>@Category</Category>
                <IsActive>1</IsActive>
            </Attributes>
        </PODetail>
    </Add>
";
        #endregion add POEntry xml


    }
}
