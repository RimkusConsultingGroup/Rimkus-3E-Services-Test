﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
// 

namespace TE3EConnect.te3eOjects.MatterSE
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class CmProductsLiability
    {

        private string prodNameCatField;

        private string damagesClaimedField;

        private string cmStrictLiabNegListField;

        private string currencyField;

        private string convDateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ProdNameCat
        {
            get
            {
                return this.prodNameCatField;
            }
            set
            {
                this.prodNameCatField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DamagesClaimed
        {
            get
            {
                return this.damagesClaimedField;
            }
            set
            {
                this.damagesClaimedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CmStrictLiabNegList
        {
            get
            {
                return this.cmStrictLiabNegListField;
            }
            set
            {
                this.cmStrictLiabNegListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ConvDate
        {
            get
            {
                return this.convDateField;
            }
            set
            {
                this.convDateField = value;
            }
        }
    }

    ///// <remarks/>
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    //[System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    //public partial class NewDataSet
    //{

    //    private CmProductsLiability[] itemsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("CmProductsLiability")]
    //    public CmProductsLiability[] Items
    //    {
    //        get
    //        {
    //            return this.itemsField;
    //        }
    //        set
    //        {
    //            this.itemsField = value;
    //        }
    //    }
    //}
}