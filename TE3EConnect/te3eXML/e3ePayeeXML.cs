using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eXML
{
    public static class e3ePayeeXML
    {
        public static string GetPayeeXOQLByName = @"
                <QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class=""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Payee"" Class=""NextGen.Application.Query.Payee"" Assembly=""NextGen.Archetype.Payee"" />
    <NODEMAP ID=""Node#2"" QueryID=""Vendor1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#3"" QueryID=""Payee1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#4"" QueryID=""Entity1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#5"" QueryID=""Terms1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#6"" QueryID=""Timekeeper1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#7"" QueryID=""Office1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#8"" QueryID=""NxUnit1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#9"" QueryID=""Language1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#10"" QueryID=""PayeeType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#11"" QueryID=""PayeeStatus1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#12"" QueryID=""TaxCode1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#13"" QueryID=""POMatchList1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#14"" QueryID=""TemplatePORel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#15"" QueryID=""Flag10991"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#16"" QueryID=""ProjectRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#17"" QueryID=""Site1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#18"" QueryID=""Site2"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#19"" QueryID=""Site3"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#20"" QueryID=""APGLNat1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#21"" QueryID=""ExpenseGLNatRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#22"" QueryID=""VchrStatus1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#23"" QueryID=""ShipMethod1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#24"" QueryID=""BankAcct1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#25"" QueryID=""PayeeCategoryRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#26"" QueryID=""PayeeAttributeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#27"" QueryID=""CostTypeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#28"" QueryID=""APTranTypeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#29"" QueryID=""APUnitLocalRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#30"" QueryID=""ExpUnitLocalRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#31"" QueryID=""TaxAreaRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#32"" QueryID=""RemittanceDeliveryMethodListRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#33"" QueryID=""WithholdingTaxRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID=""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""PayeeID"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayeeIndex"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayeeNum"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Vendor"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RelatedPayee"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Entity"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID=""Node#4"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""SortString"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Terms"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#5"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Timekeeper"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#6"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Comments"">
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
            <NODE NodeID=""Node#7"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsOnlyOffice"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""NxUnit"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#8"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsOnlyUnit"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Language"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#9"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Currency"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayeeType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#10"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayeeStatus"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#11"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ReferenceNum"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxCode"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#12"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""OpenDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CloseDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsPORequired"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""POMatchList"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#13"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TemplatePO"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#14"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Is1099"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Flag1099"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#15"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxNum"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""AltNum"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""NameCtrl"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Project"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#16"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CkSite"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#17"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""POSite"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#18"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Site1099"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#19"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""APGLNat"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLNat"">
            <NODE NodeID=""Node#20"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ExpenseGLNat"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLNat"">
            <NODE NodeID=""Node#21"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""VchrStatus"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#22"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ShipMethod"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#23"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BankAcct"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#24"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsEFTOnly"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsSeparateCheck"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ContactInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayeeCategory"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#25"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayeeAttribute"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#26"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CostType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#27"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""APGLAcct"">
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
            <NODE NodeID=""Node#28"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""APUnitLocal"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLLocal"">
            <NODE NodeID=""Node#29"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ExpenseUnitLocal"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLLocal"">
            <NODE NodeID=""Node#30"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxArea"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#31"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsIncurPayeeRequired"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ExpenseAcct"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsRemittanceSent"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RemittanceDeliveryMethodList"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#32"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WithholdingTax"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#33"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WithholdingTaxRef"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsPreferred"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfidential"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
        <X_IS_EQUAL_TO_Y>
		  <X>
			<LEAF QueryID=""Name"">
			  <NODE NodeID=""Node#2"" />
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

        public static string GetPayeeXOQLByVendor = @"
                <QUERY><SELECT ID=""SelectStatement"" Class=""NextGen.Framework.OQL.Symbols.SelectStatement"" xmlns=""http://elite.com/schemas/query"">
  <OQL_CONTEXT Class=""NextGen.Framework.Managers.ObjectMgr.ExContextProvider"">
    <NODEMAP ID=""Node#1"" QueryID=""Payee"" Class=""NextGen.Application.Query.Payee"" Assembly=""NextGen.Archetype.Payee"" />
    <NODEMAP ID=""Node#2"" QueryID=""Vendor1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#3"" QueryID=""Payee1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#4"" QueryID=""Entity1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#5"" QueryID=""Terms1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#6"" QueryID=""Timekeeper1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#7"" QueryID=""Office1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#8"" QueryID=""NxUnit1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#9"" QueryID=""Language1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#10"" QueryID=""PayeeType1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#11"" QueryID=""PayeeStatus1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#12"" QueryID=""TaxCode1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#13"" QueryID=""POMatchList1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#14"" QueryID=""TemplatePORel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#15"" QueryID=""Flag10991"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#16"" QueryID=""ProjectRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#17"" QueryID=""Site1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#18"" QueryID=""Site2"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#19"" QueryID=""Site3"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#20"" QueryID=""APGLNat1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#21"" QueryID=""ExpenseGLNatRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#22"" QueryID=""VchrStatus1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#23"" QueryID=""ShipMethod1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#24"" QueryID=""BankAcct1"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#25"" QueryID=""PayeeCategoryRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#26"" QueryID=""PayeeAttributeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#27"" QueryID=""CostTypeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#28"" QueryID=""APTranTypeRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#29"" QueryID=""APUnitLocalRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#30"" QueryID=""ExpUnitLocalRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#31"" QueryID=""TaxAreaRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#32"" QueryID=""RemittanceDeliveryMethodListRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
    <NODEMAP ID=""Node#33"" QueryID=""WithholdingTaxRel"">
      <NODE NodeID=""Node#1"" />
    </NODEMAP>
  </OQL_CONTEXT>
  <SELECT_LIST>
    <SINGLE_SELECT Union=""Distinct"">
      <NODE NodeID=""Node#1"" />
      <VALUES>
        <VALUE>
          <LEAF QueryID=""PayeeID"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayeeIndex"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayeeNum"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Vendor"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#2"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RelatedPayee"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#3"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Entity"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""DisplayName"">
            <NODE NodeID=""Node#4"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""SortString"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Terms"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#5"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Timekeeper"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Number"">
            <NODE NodeID=""Node#6"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Comments"">
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
            <NODE NodeID=""Node#7"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsOnlyOffice"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""NxUnit"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#8"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsOnlyUnit"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Language"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#9"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Currency"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayeeType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#10"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayeeStatus"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#11"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ReferenceNum"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxCode"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#12"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""OpenDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CloseDate"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsPORequired"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""POMatchList"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#13"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TemplatePO"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#14"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Is1099"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Flag1099"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#15"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxNum"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""AltNum"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""NameCtrl"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Project"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#16"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CkSite"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#17"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""POSite"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#18"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Site1099"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#19"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""APGLNat"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLNat"">
            <NODE NodeID=""Node#20"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ExpenseGLNat"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLNat"">
            <NODE NodeID=""Node#21"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""VchrStatus"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#22"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ShipMethod"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#23"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""BankAcct"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Name"">
            <NODE NodeID=""Node#24"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsEFTOnly"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsSeparateCheck"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ContactInfo"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayeeCategory"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#25"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""PayeeAttribute"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#26"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""CostType"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#27"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""APGLAcct"">
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
            <NODE NodeID=""Node#28"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""APUnitLocal"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLLocal"">
            <NODE NodeID=""Node#29"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ExpenseUnitLocal"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""GLLocal"">
            <NODE NodeID=""Node#30"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""TaxArea"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#31"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsIncurPayeeRequired"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""ExpenseAcct"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsRemittanceSent"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""RemittanceDeliveryMethodList"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#32"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WithholdingTax"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""Description"">
            <NODE NodeID=""Node#33"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""WithholdingTaxRef"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsPreferred"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
        <VALUE>
          <LEAF QueryID=""IsConfidential"">
            <NODE NodeID=""Node#1"" />
          </LEAF>
        </VALUE>
      </VALUES>
      <WHERE>
        <X_IS_EQUAL_TO_Y>
		  <X>
			<LEAF QueryID=""Vendor"">
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
    }
}
