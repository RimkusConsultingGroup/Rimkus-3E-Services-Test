//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TE3EEntityFramework.Datasource.RCGCLAIMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class rcg_rl_ClientJob
    {
        public int submission_id { get; set; }
        public string submission_type { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<System.TimeSpan> created_date_time { get; set; }
        public string billing_name { get; set; }
        public string billing_title { get; set; }
        public string billing_company { get; set; }
        public string billing_address { get; set; }
        public string billing_city { get; set; }
        public string billing_state { get; set; }
        public string billing_zip { get; set; }
        public string billing_email { get; set; }
        public string billing_phone { get; set; }
        public string billing_cell { get; set; }
        public string billing_fax { get; set; }
        public string client_name { get; set; }
        public string adverse_party { get; set; }
        public string claim_number { get; set; }
        public string tpa_file_number { get; set; }
        public string exact_engineer_request { get; set; }
        public string claim_description { get; set; }
        public string unlisted_service { get; set; }
        public Nullable<System.DateTime> occurrence_date { get; set; }
        public Nullable<System.DateTime> loss_date { get; set; }
        public string occurrence_location { get; set; }
        public string occurrence_city { get; set; }
        public string occurrence_state { get; set; }
        public string occurrence_zip { get; set; }
        public string inspection_contact_name { get; set; }
        public string inspection_contact_phone { get; set; }
        public string inspection_contact_number { get; set; }
        public bool request_design_permit_drawings { get; set; }
        public bool request_business_interruption { get; set; }
        public bool request_accident_reconstruction { get; set; }
        public bool request_full_mechanical_inspection { get; set; }
        public bool request_limited_mechanical_inspection { get; set; }
        public bool request_biomechanical_evaluation { get; set; }
        public bool request_fire_cause_and_origin { get; set; }
        public bool request_repair_cost_estimate { get; set; }
        public bool request_environmental { get; set; }
        public bool request_request_other { get; set; }
        public bool request_site_visit { get; set; }
        public bool request_mechanical_inspection { get; set; }
        public bool request_structural_analysis { get; set; }
        public bool property_damage { get; set; }
        public bool cost_estimate { get; set; }
        public bool evidence_return { get; set; }
        public string insurance_company { get; set; }
        public string insured_name { get; set; }
        public string insured_phone { get; set; }
        public string insured_cell { get; set; }
        public string adjustment_company { get; set; }
        public string adjustment_address { get; set; }
        public string adjustment_city { get; set; }
        public string adjustment_state { get; set; }
        public string adjustment_zip { get; set; }
        public string adjustment_phone { get; set; }
        public string adjustor_name { get; set; }
        public string adjustor_cell { get; set; }
        public string adjustor_email { get; set; }
        public string adjustor_file_number { get; set; }
        public string adjustor_fax { get; set; }
        public bool insurance_same_as_billing { get; set; }
        public string invoice_to { get; set; }
        public string invoice_company { get; set; }
        public string invoice_phone { get; set; }
        public string invoice_address { get; set; }
        public string invoice_city { get; set; }
        public string invoice_state { get; set; }
        public byte upload_count { get; set; }
        public string assignment_file_1 { get; set; }
        public string assignment_file_2 { get; set; }
        public string user_agent { get; set; }
        public string ip_address { get; set; }
        public System.DateTime XMLDate { get; set; }
        public System.TimeSpan XMLDateTime { get; set; }
        public bool IsSent { get; set; }
        public Nullable<System.DateTime> IsSentDate { get; set; }
        public Nullable<int> AssignmentID { get; set; }
        public Nullable<System.DateTime> AssignmentIDDate { get; set; }
        public Nullable<System.TimeSpan> AssignmentIDDateTime { get; set; }
        public string AdditionalData { get; set; }
    }
}
