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
public partial class MattOrgTkpr {
    
    private string timekeeperField;
    
    private string percentageField;
    
    private string isPrimaryField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Timekeeper {
        get {
            return this.timekeeperField;
        }
        set {
            this.timekeeperField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Percentage {
        get {
            return this.percentageField;
        }
        set {
            this.percentageField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string IsPrimary {
        get {
            return this.isPrimaryField;
        }
        set {
            this.isPrimaryField = value;
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
    
//    private MattOrgTkpr[] itemsField;
    
//    /// <remarks/>
//    [System.Xml.Serialization.XmlElementAttribute("MattOrgTkpr")]
//    public MattOrgTkpr[] Items {
//        get {
//            return this.itemsField;
//        }
//        set {
//            this.itemsField = value;
//        }
//    }
//}