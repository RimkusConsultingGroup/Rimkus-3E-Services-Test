﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EConnect.te3eDB.DbInfo
{
    public partial class Matter3e
    {
        public System.Guid MatterID { get; set; }
        public int MattIndex { get; set; }
        public string MattNumber { get; set; }
        public string MattName { get; set; }
        public string Description { get; set; }
        public string MattStatus { get; set; }
        public Nullable<System.DateTime> MattStatusDate { get; set; }
        public string MattType { get; set; }
        public Nullable<System.DateTime> OpenDate { get; set; }
        public Nullable<int> ClientIndex { get; set; }
        public string ClientNumber { get; set; }
        public string ClientName { get; set; }
        public string ClientFormattedString { get; set; }
        public string ClientStreet { get; set; }
        public string ClientCity { get; set; }
        public string ClientState { get; set; }
        public string ClientZipCode { get; set; }
        public string Contact_Email { get; set; }
        public string ClaimNo { get; set; }
        public string ReferenceNumber { get; set; }
        public string Contact_Name { get; set; }
        public string Contact_Phone { get; set; }
        public string Insured_Name { get; set; }
        public string Claimant { get; set; }
        public string Style { get; set; }
        public string Cause_Number { get; set; }
        public string Date_of_Loss { get; set; }
        public string OfficeFormattedString { get; set; }
        public string OfficeName { get; set; }
        public string OfficeStreet { get; set; }
        public string OfficeCity { get; set; }
        public string OfficeState { get; set; }
        public string OfficeZipCode { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeFax { get; set; }
        public string CertAuthNo { get; set; }
    }
}
