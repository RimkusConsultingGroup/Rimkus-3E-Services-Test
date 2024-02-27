using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TE3EEntityFramework.Data.LibertyMutual;
using TE3EEntityFramework.Datasource.RCGCLAIMS;
using TE3EEntityFramework.Setting;

namespace TE3EEntityFramework.Client
{
    public class LibertyMutualDbClient
    {
        private LibertyMutualAppSetting _appSettings;

        public LibertyMutualDbClient(LibertyMutualAppSetting appSettings)
        {
            _appSettings = appSettings;
        }

        public bool VerifyApiKey(string key)
        {
            bool isValid = false;

            if (_appSettings.IsDebug)
            {
                using (RCGCLAIMS_DEV01Entities db = new RCGCLAIMS_DEV01Entities())
                {
                    isValid = db.KeyVaults.Any(x => x.ApiKey.Equals(key));
                }
            }
            else
            {
                using (RCGCLAIMS_PROD01Entities db = new RCGCLAIMS_PROD01Entities())
                {
                    isValid = db.KeyVaults.Any(x => x.ApiKey.Equals(key));
                }
            }

            return isValid;
        }

        public List<LMClaimNotification> GetLMClaimNotifications()
        {
            List<LMClaimNotification> claims = new List<LMClaimNotification>();

            if (_appSettings.IsDebug)
            {
                using (RCGCLAIMS_DEV01Entities db = new RCGCLAIMS_DEV01Entities())
                {
                    claims = db.LMClaimNotifications.Where(x => !x.ClaimUniqueId.Equals("string") && x.ImportedAt == null && x.NumOfAttempts <= _appSettings.MaxNumOfAttempts).ToList();
                }
            }
            else
            {
                using (RCGCLAIMS_PROD01Entities db = new RCGCLAIMS_PROD01Entities())
                {
                    claims = db.LMClaimNotifications.Where(x => !x.ClaimUniqueId.Equals("string") && x.ImportedAt == null && x.NumOfAttempts <= _appSettings.MaxNumOfAttempts).ToList();
                }
            }

            return claims;
        }

        public void LMClaimNotificationsMarkImported(LMClaimNotification lmClaimNotification)
        {
            if (_appSettings.IsDebug)
            {
                using (RCGCLAIMS_DEV01Entities db = new RCGCLAIMS_DEV01Entities())
                {
                    lmClaimNotification.ImportedAt = DateTime.Now;
                    db.Entry(lmClaimNotification).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                using (RCGCLAIMS_PROD01Entities db = new RCGCLAIMS_PROD01Entities())
                {
                    lmClaimNotification.ImportedAt = DateTime.Now;
                    db.Entry(lmClaimNotification).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public bool IsLMClaimNotificationsDuplicate(string ClaimUniqueId)
        {
            if (_appSettings.IsDebug)
            {
                using (RCGCLAIMS_DEV01Entities db = new RCGCLAIMS_DEV01Entities())
                {
                    return db.LMClaimNotifications.Any(x => x.ClaimUniqueId.Equals(ClaimUniqueId));
                }
            }
            else
            {
                using (RCGCLAIMS_PROD01Entities db = new RCGCLAIMS_PROD01Entities())
                {
                    return db.LMClaimNotifications.Any(x => x.ClaimUniqueId.Equals(ClaimUniqueId));
                }
            }

            return false;
        }

        public void AddLMClaimNotification(ClaimNotification model)
        {
            if (_appSettings.IsDebug)
            {
                using (RCGCLAIMS_DEV01Entities db = new RCGCLAIMS_DEV01Entities())
                {
                    if (db.LMClaimNotifications.Any(x => x.ClaimUniqueId.Equals(model.UniqueID)))
                        return;

                    var claim = new LMClaimNotification()
                    {
                        ClaimNumber = model.Number,
                        ClaimUniqueId = model.UniqueID,
                        FileNumber = model.FileNumber,
                        OriginatorCompanyID = model.OriginatorCompany?.CompanyID,
                        OriginatorCompanyName = model.OriginatorCompany?.CompanyName,
                        PolicyNumber = model.PolicyNumber,
                        ExternalReference = model.ExternalReference,
                        Status = model.Status,
                        NotificationJson = JsonConvert.SerializeObject(model),
                        TimeStamp = DateTime.Now
                    };
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.LMClaimNotifications.Add(claim);
                    db.SaveChanges();
                }
            }
            else
            {
                using (RCGCLAIMS_PROD01Entities db = new RCGCLAIMS_PROD01Entities())
                {
                    if (db.LMClaimNotifications.Any(x => x.ClaimUniqueId.Equals(model.UniqueID)))
                        return;

                    var claim = new LMClaimNotification()
                    {
                        ClaimNumber = model.Number,
                        ClaimUniqueId = model.UniqueID,
                        FileNumber = model.FileNumber,
                        OriginatorCompanyID = model.OriginatorCompany?.CompanyID,
                        OriginatorCompanyName = model.OriginatorCompany?.CompanyName,
                        PolicyNumber = model.PolicyNumber,
                        ExternalReference = model.ExternalReference,
                        Status = model.Status,
                        NotificationJson = JsonConvert.SerializeObject(model),
                        TimeStamp = DateTime.Now
                    };
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.LMClaimNotifications.Add(claim);
                    db.SaveChanges();
                }
            }
        }

        public LMAssignment AddLMAssignment(LM_Assignment assignment, LM_Claims parentClaim)
        {
            if (_appSettings.IsDebug)
            {
                using (RCGCLAIMS_DEV01Entities db = new RCGCLAIMS_DEV01Entities())
                {
                    var lmAssignment = new LMAssignment()
                    {
                        AssignmentSentDate = assignment.AssignmentSentDate ?? DateTime.Now,
                        BillingName = $"{parentClaim.Originator?.ContactFirstName} {parentClaim.Originator?.ContactLastName}",
                        BillingCompany = parentClaim.Originator?.CompanyName,
                        BillingAddress = parentClaim.Originator?.Address?.Line1,
                        BillingCity = parentClaim.Originator?.Address?.City,
                        BillingState = parentClaim.Originator?.Address?.State,
                        BillingZip = parentClaim.Originator?.Address?.ZipCode,
                        BillingEmail = parentClaim.Originator?.Email,
                        BillingPhone = parentClaim.Originator?.Phone,
                        BillingCell = parentClaim.Originator?.MobilePhone,
                        BillingFax = parentClaim.Originator?.Fax,
                        BillingTitle = "",
                        ClaimNumber = parentClaim.Number,
                        ClientName = parentClaim.LossContactName,
                        ClaimDescription = $"{(string.IsNullOrEmpty(parentClaim.InitialLossReport) ? string.Empty : parentClaim.InitialLossReport + " |")}" +
                        $"{(string.IsNullOrEmpty(parentClaim.Cause) ? string.Empty : parentClaim.Cause + " |")}" +
                        $"{(string.IsNullOrEmpty(parentClaim.Damages) ? string.Empty : parentClaim.Damages + " |")}".Trim(),
                        UnlistedService = assignment.Notes,
                        OccurrenceDate = parentClaim.LossDate,
                        OccurrenceLocation = string.IsNullOrEmpty(parentClaim.LossAddress?.Line1) ? parentClaim.InsuredAddress?.Line1 : parentClaim.LossAddress?.Line1,
                        OccurrenceCity = string.IsNullOrEmpty(parentClaim.LossAddress?.City) ? parentClaim.InsuredAddress?.City : parentClaim.LossAddress?.City,
                        OccurrenceState = string.IsNullOrEmpty(parentClaim.LossAddress?.State) ? parentClaim.InsuredAddress?.State : parentClaim.LossAddress?.State,
                        OccurrenceZip = string.IsNullOrEmpty(parentClaim.LossAddress?.ZipCode) ? parentClaim.InsuredAddress?.ZipCode : parentClaim.LossAddress?.ZipCode,
                        InsuranceCompany = parentClaim.InsuredCompanyName,
                        InsuredName = $"{parentClaim.InsuredFirstName} {parentClaim.InsuredLastName}{(string.IsNullOrEmpty(parentClaim.InsuredFirstName2) ? string.Empty : $" and {parentClaim.InsuredFirstName2} {parentClaim.InsuredLastName2}")}",
                        InsuredPhone = string.IsNullOrEmpty(parentClaim.InsuredBusinessPhone) ? parentClaim.InsuredHomePhone : parentClaim.InsuredBusinessPhone,
                        InsuredCell = string.IsNullOrEmpty(parentClaim.InsuredMobilePhone) ? parentClaim.InsuredOtherPhone : parentClaim.InsuredMobilePhone,
                        AdjustmentCompany = parentClaim.CustomFields?.FirstOrDefault(x => x.Name.Equals("Business Unit", StringComparison.OrdinalIgnoreCase))?.Value,
                        AdjustmentPhone = parentClaim.CustomFields?.FirstOrDefault(x => x.Name.Equals("Adjuster Phone", StringComparison.OrdinalIgnoreCase))?.Value,
                        AdjustorName = parentClaim.CustomFields?.FirstOrDefault(x => x.Name.Equals("Adjuster Name", StringComparison.OrdinalIgnoreCase))?.Value,
                        AdjustorEmail = parentClaim.CustomFields?.FirstOrDefault(x => x.Name.Equals("Adjuster Email", StringComparison.OrdinalIgnoreCase))?.Value,
                        InvoiceTo = $"{parentClaim.Originator?.ContactFirstName} {parentClaim.Originator?.ContactLastName}",
                        InvoiceCompany = parentClaim.Originator?.CompanyName,
                        InvoicePhone = parentClaim.Originator?.Phone,
                        InvoiceAddress = parentClaim.Originator?.Address?.Line1,
                        InvoiceCity = parentClaim.Originator?.Address?.City,
                        InvoiceState = parentClaim.Originator?.Address?.State,
                        TPAFileNumber = parentClaim.FileNumber,
                        AdditionalData = JsonConvert.SerializeObject(parentClaim, Formatting.None),
                        ClaimUniqueId = parentClaim.UniqueID,
                        TimeStamp = DateTime.Now,
                        Title = $"{parentClaim.Originator?.ContactFirstName} {parentClaim.Originator?.ContactLastName} ({parentClaim.Originator?.Email})"
                    };

                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.LMAssignments.Add(lmAssignment);
                    db.SaveChanges();
                    return lmAssignment;
                }
            }
            else
            {
                using (RCGCLAIMS_PROD01Entities db = new RCGCLAIMS_PROD01Entities())
                {
                    var lmAssignment = new LMAssignment()
                    {
                        AssignmentSentDate = assignment.AssignmentSentDate ?? DateTime.Now,
                        BillingName = $"{parentClaim.Originator?.ContactFirstName} {parentClaim.Originator?.ContactLastName}",
                        BillingCompany = parentClaim.Originator?.CompanyName,
                        BillingAddress = parentClaim.Originator?.Address?.Line1,
                        BillingCity = parentClaim.Originator?.Address?.City,
                        BillingState = parentClaim.Originator?.Address?.State,
                        BillingZip = parentClaim.Originator?.Address?.ZipCode,
                        BillingEmail = parentClaim.Originator?.Email,
                        BillingPhone = parentClaim.Originator?.Phone,
                        BillingCell = parentClaim.Originator?.MobilePhone,
                        BillingFax = parentClaim.Originator?.Fax,
                        BillingTitle = "",
                        ClaimNumber = parentClaim.Number,
                        ClientName = parentClaim.LossContactName,
                        ClaimDescription = $"{(string.IsNullOrEmpty(parentClaim.InitialLossReport) ? string.Empty : parentClaim.InitialLossReport + " |")}" +
                        $"{(string.IsNullOrEmpty(parentClaim.Cause) ? string.Empty : parentClaim.Cause + " |")}" +
                        $"{(string.IsNullOrEmpty(parentClaim.Damages) ? string.Empty : parentClaim.Damages + " |")}".Trim(),
                        UnlistedService = assignment.Notes,
                        OccurrenceDate = parentClaim.LossDate,
                        OccurrenceLocation = string.IsNullOrEmpty(parentClaim.LossAddress?.Line1) ? parentClaim.InsuredAddress?.Line1 : parentClaim.LossAddress?.Line1,
                        OccurrenceCity = string.IsNullOrEmpty(parentClaim.LossAddress?.City) ? parentClaim.InsuredAddress?.City : parentClaim.LossAddress?.City,
                        OccurrenceState = string.IsNullOrEmpty(parentClaim.LossAddress?.State) ? parentClaim.InsuredAddress?.State : parentClaim.LossAddress?.State,
                        OccurrenceZip = string.IsNullOrEmpty(parentClaim.LossAddress?.ZipCode) ? parentClaim.InsuredAddress?.ZipCode : parentClaim.LossAddress?.ZipCode,
                        InsuranceCompany = parentClaim.InsuredCompanyName,
                        InsuredName = $"{parentClaim.InsuredFirstName} {parentClaim.InsuredLastName}{(string.IsNullOrEmpty(parentClaim.InsuredFirstName2) ? string.Empty : $" and {parentClaim.InsuredFirstName2} {parentClaim.InsuredLastName2}")}",
                        InsuredPhone = string.IsNullOrEmpty(parentClaim.InsuredBusinessPhone) ? parentClaim.InsuredHomePhone : parentClaim.InsuredBusinessPhone,
                        InsuredCell = string.IsNullOrEmpty(parentClaim.InsuredMobilePhone) ? parentClaim.InsuredOtherPhone : parentClaim.InsuredMobilePhone,
                        AdjustmentCompany = parentClaim.CustomFields?.FirstOrDefault(x => x.Name.Equals("Business Unit", StringComparison.OrdinalIgnoreCase))?.Value,
                        AdjustmentPhone = parentClaim.CustomFields?.FirstOrDefault(x => x.Name.Equals("Adjuster Phone", StringComparison.OrdinalIgnoreCase))?.Value,
                        AdjustorName = parentClaim.CustomFields?.FirstOrDefault(x => x.Name.Equals("Adjuster Name", StringComparison.OrdinalIgnoreCase))?.Value,
                        AdjustorEmail = parentClaim.CustomFields?.FirstOrDefault(x => x.Name.Equals("Adjuster Email", StringComparison.OrdinalIgnoreCase))?.Value,
                        InvoiceTo = $"{parentClaim.Originator?.ContactFirstName} {parentClaim.Originator?.ContactLastName}",
                        InvoiceCompany = parentClaim.Originator?.CompanyName,
                        InvoicePhone = parentClaim.Originator?.Phone,
                        InvoiceAddress = parentClaim.Originator?.Address?.Line1,
                        InvoiceCity = parentClaim.Originator?.Address?.City,
                        InvoiceState = parentClaim.Originator?.Address?.State,
                        TPAFileNumber = parentClaim.FileNumber,
                        AdditionalData = JsonConvert.SerializeObject(parentClaim, Formatting.None),
                        ClaimUniqueId = parentClaim.UniqueID,
                        TimeStamp = DateTime.Now,
                        Title = $"{parentClaim.Originator?.ContactFirstName} {parentClaim.Originator?.ContactLastName} ({parentClaim.Originator?.Email})"
                    };

                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    db.LMAssignments.Add(lmAssignment);
                    db.SaveChanges();
                    return lmAssignment;
                }
            }
        }

        public int AddLMAssignmentToRCGMin(LMAssignment lmAssignment)
        {
            if (_appSettings.IsDebug)
            {
                using (RCGDB_DEV01Entities db = new RCGDB_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var submissionId = db.rcg_rl_ClientJob_Min_Save(null, null, "client_assignment", lmAssignment.ClaimNumber, lmAssignment.AssignmentSentDate, lmAssignment.InsuranceCompany,
                        lmAssignment.BillingCompany, lmAssignment.BillingCity, lmAssignment.BillingState, lmAssignment.BillingZip, lmAssignment.OccurrenceCity, lmAssignment.OccurrenceState,
                        lmAssignment.OccurrenceZip, null, null, lmAssignment.AdditionalData);
                    return submissionId.FirstOrDefault() ?? 0;
                }
            }
            else
            {
                using (RCGDB_PROD01Entities db = new RCGDB_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var submissionId = db.rcg_rl_ClientJob_Min_Save(null, null, "client_assignment", lmAssignment.ClaimNumber, lmAssignment.AssignmentSentDate, lmAssignment.InsuranceCompany,
                        lmAssignment.BillingCompany, lmAssignment.BillingCity, lmAssignment.BillingState, lmAssignment.BillingZip, lmAssignment.OccurrenceCity, lmAssignment.OccurrenceState,
                        lmAssignment.OccurrenceZip, null, null, lmAssignment.AdditionalData);
                    return submissionId.FirstOrDefault() ?? 0;
                }
            }
        }

        public int AddLMAssignmentToRCG(LMAssignment lmAssignment)
        {
            if (_appSettings.IsDebug)
            {
                using (RCGDB_DEV01Entities db = new RCGDB_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    var lattestSubmissionId = db.rcg_rl_ClientJob.Where(x => x.submission_id >= 100000 && x.submission_id <= 18010000).Max(x => x.submission_id) + 1;
                    var submissionId = db.rcg_rl_ClientJob_Save(
                        submission_id: lattestSubmissionId,
                        submission_type: "client_assignment",
                        title: lmAssignment.Title,
                        created_date: lmAssignment.AssignmentSentDate,
                        billing_name: lmAssignment.BillingName,
                        billing_title: lmAssignment.BillingTitle,
                        billing_company: lmAssignment.BillingCompany,
                        billing_address: lmAssignment.BillingAddress,
                        billing_city: lmAssignment.BillingCity,
                        billing_state: lmAssignment.BillingState,
                        billing_zip: lmAssignment.BillingZip,
                        billing_email: lmAssignment.BillingEmail,
                        billing_phone: lmAssignment.BillingPhone,
                        billing_cell: lmAssignment.BillingCell,
                        billing_fax: lmAssignment.BillingFax,
                        client_name: lmAssignment.ClientName,
                        adverse_party: null,
                        claim_number: lmAssignment.ClaimNumber,
                        tpa_file_number: lmAssignment.TPAFileNumber,
                        exact_engineer_request: null,
                        claim_description: lmAssignment.ClaimDescription,
                        unlisted_service: lmAssignment.UnlistedService,
                        occurrence_date: lmAssignment.OccurrenceDate,
                        loss_date: null,
                        occurrence_location: lmAssignment.OccurrenceLocation,
                        occurrence_city: lmAssignment.OccurrenceCity,
                        occurrence_state: lmAssignment.OccurrenceState,
                        occurrence_zip: lmAssignment.OccurrenceZip,
                        inspection_contact_name: null,
                        inspection_contact_phone: null,
                        inspection_contact_number: null,
                        request_design_permit_drawings: false,
                        request_business_interruption: false,
                        request_accident_reconstruction: false,
                        request_full_mechanical_inspection: false,
                        request_limited_mechanical_inspection: false,
                        request_biomechanical_evaluation: false,
                        request_fire_cause_and_origin: false,
                        request_repair_cost_estimate: false,
                        request_environmental: false,
                        request_request_other: false,
                        request_site_visit: false,
                        request_mechanical_inspection: false,
                        request_structural_analysis: false,
                        property_damage: false,
                        cost_estimate: false,
                        evidence_return: false,
                        insurance_company: lmAssignment.InsuranceCompany,
                        insured_name: lmAssignment.InsuredName,
                        insured_phone: lmAssignment.InsuredPhone,
                        insured_cell: lmAssignment.InsuredCell,
                        adjustment_company: lmAssignment.AdjustmentCompany,
                        adjustment_address: null,
                        adjustment_city: null,
                        adjustment_state: null,
                        adjustment_zip: null,
                        adjustment_phone: lmAssignment.AdjustmentPhone,
                        adjustor_name: lmAssignment.AdjustorName,
                        adjustor_cell: null,
                        adjustor_email: lmAssignment.AdjustorEmail,
                        adjustor_file_number: null,
                        adjustor_fax: null,
                        insurance_same_as_billing: false,
                        invoice_to: lmAssignment.InvoiceTo,
                        invoice_company: lmAssignment.InvoiceCompany,
                        invoice_phone: lmAssignment.InvoicePhone,
                        invoice_address: lmAssignment.InvoiceAddress,
                        invoice_city: lmAssignment.InvoiceCity,
                        invoice_state: lmAssignment.InvoiceState,
                        upload_count: 0,
                        assignment_file_1: null,
                        assignment_file_2: null,
                        user_agent: "",
                        ip_address: null,
                        additionalData: null);
                    return lattestSubmissionId;
                }
            }
            else
            {
                using (RCGDB_PROD01Entities db = new RCGDB_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    var lattestSubmissionId = db.rcg_rl_ClientJob.Where(x => x.submission_id >= 100000 && x.submission_id <= 18010000).Max(x => x.submission_id) + 1;
                    var submissionId = db.rcg_rl_ClientJob_Save(
                        submission_id: lattestSubmissionId,
                        submission_type: "client_assignment",
                        title: lmAssignment.Title,
                        created_date: lmAssignment.AssignmentSentDate,
                        billing_name: lmAssignment.BillingName,
                        billing_title: lmAssignment.BillingTitle,
                        billing_company: lmAssignment.BillingCompany,
                        billing_address: lmAssignment.BillingAddress,
                        billing_city: lmAssignment.BillingCity,
                        billing_state: lmAssignment.BillingState,
                        billing_zip: lmAssignment.BillingZip,
                        billing_email: lmAssignment.BillingEmail,
                        billing_phone: lmAssignment.BillingPhone,
                        billing_cell: lmAssignment.BillingCell,
                        billing_fax: lmAssignment.BillingFax,
                        client_name: lmAssignment.ClientName,
                        adverse_party: null,
                        claim_number: lmAssignment.ClaimNumber,
                        tpa_file_number: lmAssignment.TPAFileNumber,
                        exact_engineer_request: null,
                        claim_description: lmAssignment.ClaimDescription,
                        unlisted_service: lmAssignment.UnlistedService,
                        occurrence_date: lmAssignment.OccurrenceDate,
                        loss_date: null,
                        occurrence_location: lmAssignment.OccurrenceLocation,
                        occurrence_city: lmAssignment.OccurrenceCity,
                        occurrence_state: lmAssignment.OccurrenceState,
                        occurrence_zip: lmAssignment.OccurrenceZip,
                        inspection_contact_name: null,
                        inspection_contact_phone: null,
                        inspection_contact_number: null,
                        request_design_permit_drawings: false,
                        request_business_interruption: false,
                        request_accident_reconstruction: false,
                        request_full_mechanical_inspection: false,
                        request_limited_mechanical_inspection: false,
                        request_biomechanical_evaluation: false,
                        request_fire_cause_and_origin: false,
                        request_repair_cost_estimate: false,
                        request_environmental: false,
                        request_request_other: false,
                        request_site_visit: false,
                        request_mechanical_inspection: false,
                        request_structural_analysis: false,
                        property_damage: false,
                        cost_estimate: false,
                        evidence_return: false,
                        insurance_company: lmAssignment.InsuranceCompany,
                        insured_name: lmAssignment.InsuredName,
                        insured_phone: lmAssignment.InsuredPhone,
                        insured_cell: lmAssignment.InsuredCell,
                        adjustment_company: lmAssignment.AdjustmentCompany,
                        adjustment_address: null,
                        adjustment_city: null,
                        adjustment_state: null,
                        adjustment_zip: null,
                        adjustment_phone: lmAssignment.AdjustmentPhone,
                        adjustor_name: lmAssignment.AdjustorName,
                        adjustor_cell: null,
                        adjustor_email: lmAssignment.AdjustorEmail,
                        adjustor_file_number: null,
                        adjustor_fax: null,
                        insurance_same_as_billing: false,
                        invoice_to: lmAssignment.InvoiceTo,
                        invoice_company: lmAssignment.InvoiceCompany,
                        invoice_phone: lmAssignment.InvoicePhone,
                        invoice_address: lmAssignment.InvoiceAddress,
                        invoice_city: lmAssignment.InvoiceCity,
                        invoice_state: lmAssignment.InvoiceState,
                        upload_count: 0,
                        assignment_file_1: null,
                        assignment_file_2: null,
                        user_agent: "",
                        ip_address: null,
                        additionalData: null);
                    return lattestSubmissionId;
                }
            }
        }

        public rcg_rl_ClientJob GetRCG_RL_ClientJob(int submissionId)
        {
            if (_appSettings.IsDebug)
            {
                using (RCGDB_DEV01Entities db = new RCGDB_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    var clientJob = db.rcg_rl_ClientJob.FirstOrDefault(x => x.submission_id == submissionId);
                    return clientJob;
                }
            }
            else
            {
                using (RCGDB_PROD01Entities db = new RCGDB_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;

                    var clientJob = db.rcg_rl_ClientJob.FirstOrDefault(x => x.submission_id == submissionId);
                    return clientJob;
                }
            }
        }

        public void AddLMAssignmentLog(bool isSuccess, string ClaimNumber, string ClaimUniqueID, string Message)
        {
            if (_appSettings.IsDebug)
            {
                using (RCGCLAIMS_DEV01Entities db = new RCGCLAIMS_DEV01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var lmAssignmentLog = new LMAssignmentServiceLog()
                    {
                        ClaimNumber = ClaimNumber,
                        ClaimUniqueId = ClaimUniqueID,
                        Status = isSuccess ? "Success" : "Error",
                        Message = Message,
                        TimeStamp = DateTime.Now
                    };
                    db.LMAssignmentServiceLogs.Add(lmAssignmentLog);

                    if (!isSuccess)
                    {
                        var lmClaimNotification = db.LMClaimNotifications.FirstOrDefault(x => x.ClaimUniqueId.Equals(ClaimUniqueID));
                        lmClaimNotification.NumOfAttempts = ++lmClaimNotification.NumOfAttempts;
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                using (RCGCLAIMS_PROD01Entities db = new RCGCLAIMS_PROD01Entities())
                {
                    db.Database.CommandTimeout = _appSettings.SqlCommandTimeout;
                    var lmAssignmentLog = new LMAssignmentServiceLog()
                    {
                        ClaimNumber = ClaimNumber,
                        ClaimUniqueId = ClaimUniqueID,
                        Status = isSuccess ? "Success" : "Error",
                        Message = Message,
                        TimeStamp = DateTime.Now
                    };
                    db.LMAssignmentServiceLogs.Add(lmAssignmentLog);

                    if (!isSuccess)
                    {
                        var lmClaimNotification = db.LMClaimNotifications.FirstOrDefault(x => x.ClaimUniqueId.Equals(ClaimUniqueID));
                        lmClaimNotification.NumOfAttempts = ++lmClaimNotification.NumOfAttempts;
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}