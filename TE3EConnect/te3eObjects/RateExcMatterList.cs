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


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class RateExcMatterList {
    
    private string matterField;
    
    private string startDateField;
    
    private string endDateField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Matter {
        get {
            return this.matterField;
        }
        set {
            this.matterField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string StartDate {
        get {
            return this.startDateField;
        }
        set {
            this.startDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string EndDate {
        get {
            return this.endDateField;
        }
        set {
            this.endDateField = value;
        }
    }
}

/// <remarks/>
//[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
//[System.SerializableAttribute()]
//[System.Diagnostics.DebuggerStepThroughAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
//[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
//public partial class NewDataSet {
    
//    private RateExcMatterList[] itemsField;
    
//    /// <remarks/>
//    [System.Xml.Serialization.XmlElementAttribute("RateExcMatterList")]
//    public RateExcMatterList[] Items {
//        get {
//            return this.itemsField;
//        }
//        set {
//            this.itemsField = value;
//        }
//    }
//}