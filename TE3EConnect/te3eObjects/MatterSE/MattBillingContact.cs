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
    public partial class MattBillingContact
    {

        private string startDateField;

        private string finishDateField;

        private string billingContactTypeField;

        private string entityPersonField;

        private string entityPositionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string StartDate
        {
            get
            {
                return this.startDateField;
            }
            set
            {
                this.startDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FinishDate
        {
            get
            {
                return this.finishDateField;
            }
            set
            {
                this.finishDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string BillingContactType
        {
            get
            {
                return this.billingContactTypeField;
            }
            set
            {
                this.billingContactTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string EntityPerson
        {
            get
            {
                return this.entityPersonField;
            }
            set
            {
                this.entityPersonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string EntityPosition
        {
            get
            {
                return this.entityPositionField;
            }
            set
            {
                this.entityPositionField = value;
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

    //    private MattBillingContact[] itemsField;

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("MattBillingContact")]
    //    public MattBillingContact[] Items
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