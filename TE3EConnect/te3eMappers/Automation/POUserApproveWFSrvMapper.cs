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
    internal class POUserApproveWFSrvMapper
    {
        public static string ConvertPOUserApproveWFSrvToXml(POReqWF_CCCSrv pOReqWF_CCCSrv, e3eMode e3EMode)
        {
            string csXml = "";
            string strTemplate = "POUserApproveWF_CCC_Srv.xml";
            
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "te3eXML", "Automation",strTemplate);
            using (var objStreamReader = File.OpenText(path))
            {
                csXml = objStreamReader.ReadToEnd();
                csXml = csXml.Replace("@AddPOUserApproveWF_CCC", e3EMode == e3eMode.Add ? ConvertAddPOUserApproveWFCCC(pOReqWF_CCCSrv) : "");

            }

            return csXml;
        }

        #region add POReqWFCCC conversion
        private static string ConvertAddPOUserApproveWFCCC(POReqWF_CCCSrv pOReqWF_CCCSrv)
        {
            StringBuilder sb = new StringBuilder();
            
            string csXml = AddPOReqWFCCCXml;
            csXml = csXml.Replace("@Payee", pOReqWF_CCCSrv.pOReq.Payee)
                         .Replace("@Supplier", pOReqWF_CCCSrv.pOReq.Supplier)
                         .Replace("@ShipSite", pOReqWF_CCCSrv.pOReq.ShipSite)
                         .Replace("@ShipInstructions", pOReqWF_CCCSrv.pOReq.ShipInstructions)
                         .Replace("@Comments", pOReqWF_CCCSrv.pOReq.Comments.Length >= 255 ? pOReqWF_CCCSrv.pOReq.Comments.Substring(0, 254) : pOReqWF_CCCSrv.pOReq.Comments)
                         .Replace("@NxUser", pOReqWF_CCCSrv.pOReq.NxUser)
                         .Replace("@ReqDate", pOReqWF_CCCSrv.pOReq.ReqDate)
                         .Replace("@Currency", pOReqWF_CCCSrv.pOReq.Currency)
                         .Replace("@ProductBundle_CCC", pOReqWF_CCCSrv.pOReq.ProductBundle_CCC)
                         .Replace("@AddPOReqDetail", pOReqWF_CCCSrv.pOReqDetails.Count() > 0 ? ConverPOReqDetail(pOReqWF_CCCSrv.pOReqDetails) : "");

            sb.AppendLine(csXml);

            return sb.ToString();
        }

        private static string ConverPOReqDetail(List<POReqDetail> pOReqDetails)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<POReqDetail>");
            

            StringBuilder poReqDetSb = new StringBuilder();
            pOReqDetails.ForEach(x =>
            {
                string csXml = AddPOReqDetailXml;
                csXml = csXml.Replace("@LineNum", x.LineNum)
                             .Replace("@DateRequired", x.DateRequired)
                             .Replace("@Quantity", x.Quantity)
                             .Replace("@ProductCode", x.ProductCode)
                             .Replace("@Description", x.Description)
                             .Replace("@UOM", x.UOM)
                             .Replace("@ExpenseGLAcct", x.ExpenseGLAcct)
                             .Replace("@Comments", x.Comments)
                             .Replace("@DeliverNxUser", x.DeliverNxUser)
                             .Replace("@Category", x.Category)
                             .Replace("@Currency", x.Currency)
                             .Replace("@UnitCost", x.UnitCost);

                poReqDetSb.AppendLine(csXml);
            });

            sb.AppendLine(poReqDetSb.ToString());
            sb.AppendLine("</POReqDetail>");

            return sb.ToString();
        }
        #endregion add POReqWFCCC conversion

        #region add POReqWFCCC xml

        private static string AddPOReqWFCCCXml = @"

    <Add>
      <POReq>
        <Attributes>
          <Payee>@Payee</Payee>
          <Supplier>@Supplier</Supplier>
          <ShipSite>@ShipSite</ShipSite>
          <ShipInstructions>@ShipInstructions</ShipInstructions>
          <Comments>@Comments</Comments>
          <IsClosed>0</IsClosed>
          <NxUser>@NxUser</NxUser>
          <ReqDate>@ReqDate</ReqDate>
          <!--<Amount>@Amount</Amount> -->
          <Currency>@Currency</Currency>
          <!--<RouteTo_CCC>@RouteTo_CCC</RouteTo_CCC>
          <RejectionReason>@RejectionReason</RejectionReason>
          <Approver>@Approver</Approver>
          <PreviousOwner>@PreviousOwner</PreviousOwner>
          <HasBeenApprovedByFinalApprover_CCC>@HasBeenApprovedByFinalApprover_CCC</HasBeenApprovedByFinalApprover_CCC>-->
          <ProductBundle_CCC>@ProductBundle_CCC</ProductBundle_CCC>
        </Attributes>
        <Children>
            @AddPOReqDetail
        </Children>
      </POReq>
    </Add>
";

    private static string AddPOReqDetailXml = @"

            <Add>
              <POReqDetail>
                <Attributes>
                  <LineNum>@LineNum</LineNum>
                  <DateRequired>@DateRequired</DateRequired>
                  <Quantity>@Quantity</Quantity>
                  <ProductCode>@ProductCode</ProductCode>
                  <Description>@Description</Description>
                  <UOM>@UOM</UOM>
                  <!--<Matter>@Matter</Matter>
                  <Office>@Office</Office>
                  <Timekeeper>@Timekeeper</Timekeeper> -->
                  <ExpenseGLAcct>@ExpenseGLAcct</ExpenseGLAcct>
                  <Comments>@Comments</Comments>
                  <IsRush>0</IsRush>
                  <DeliverNxUser>@DeliverNxUser</DeliverNxUser>
                  <IsClosed>0</IsClosed>
                  <!--<GLProject>@GLProject</GLProject> -->
                  <Category>@Category</Category>
                  <Currency>@Currency</Currency>
                  <UnitCost>@UnitCost</UnitCost>
                  <!--<Amount>@Amount</Amount>
                  <FACategory>@FACategory</FACategory>
                  <IsProdCodeDoesNotExist_CCC>1</IsProdCodeDoesNotExist_CCC>
                  <ShippingCost_CCC>1</ShippingCost_CCC>
                  <Tax_CCC>1</Tax_CCC>-->
                </Attributes>
              </POReqDetail>
            </Add>
";
        #endregion add POReqWFCCC xml


    }
}
