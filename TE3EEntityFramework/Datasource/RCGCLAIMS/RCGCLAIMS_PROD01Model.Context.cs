﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RCGCLAIMS_PROD01Entities : DbContext
    {
        public RCGCLAIMS_PROD01Entities()
            : base("name=RCGCLAIMS_PROD01Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LMAssignment> LMAssignments { get; set; }
        public virtual DbSet<LMAssignmentAudit> LMAssignmentAudits { get; set; }
        public virtual DbSet<LMAssignmentServiceLog> LMAssignmentServiceLogs { get; set; }
        public virtual DbSet<LMClaimNotification> LMClaimNotifications { get; set; }
        public virtual DbSet<LMClaimNotificationsAudit> LMClaimNotificationsAudits { get; set; }
        public virtual DbSet<KeyVault> KeyVaults { get; set; }
        public virtual DbSet<AppConfig> AppConfigs { get; set; }
    }
}
