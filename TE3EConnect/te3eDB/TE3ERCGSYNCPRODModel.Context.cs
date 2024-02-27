﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TE3EConnect.te3eDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TE3ERCGSYNCPRODEntities : DbContext
    {
        public TE3ERCGSYNCPRODEntities()
            : base("name=TE3ERCGSYNCPRODEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClientMaster> ClientMasters { get; set; }
        public virtual DbSet<CustomSubjectLine> CustomSubjectLines { get; set; }
        public virtual DbSet<ExcludedClientCollectionWF> ExcludedClientCollectionWFs { get; set; }
        public virtual DbSet<TrackerSafeEMSImport> TrackerSafeEMSImports { get; set; }
    
        public virtual ObjectResult<RetrieveCollectionItemsByPastDueDays_Result> RetrieveCollectionItemsByPastDueDays(Nullable<int> numOfDays)
        {
            var numOfDaysParameter = numOfDays.HasValue ?
                new ObjectParameter("numOfDays", numOfDays) :
                new ObjectParameter("numOfDays", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetrieveCollectionItemsByPastDueDays_Result>("RetrieveCollectionItemsByPastDueDays", numOfDaysParameter);
        }
    
        public virtual ObjectResult<RetrieveItemizedInvCollection_Result> RetrieveItemizedInvCollection(string collectionItem)
        {
            var collectionItemParameter = collectionItem != null ?
                new ObjectParameter("collectionItem", collectionItem) :
                new ObjectParameter("collectionItem", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetrieveItemizedInvCollection_Result>("RetrieveItemizedInvCollection", collectionItemParameter);
        }
    
        public virtual ObjectResult<RetrieveLetterHeaderAddress_Result> RetrieveLetterHeaderAddress(string matterNo)
        {
            var matterNoParameter = matterNo != null ?
                new ObjectParameter("matterNo", matterNo) :
                new ObjectParameter("matterNo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetrieveLetterHeaderAddress_Result>("RetrieveLetterHeaderAddress", matterNoParameter);
        }
    
        public virtual ObjectResult<RetrieveMatteCPC_Result> RetrieveMatteCPC(string matterNo)
        {
            var matterNoParameter = matterNo != null ?
                new ObjectParameter("matterNo", matterNo) :
                new ObjectParameter("matterNo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetrieveMatteCPC_Result>("RetrieveMatteCPC", matterNoParameter);
        }
    
        public virtual ObjectResult<RetrieveMatterByNum_Result> RetrieveMatterByNum(string matterNo)
        {
            var matterNoParameter = matterNo != null ?
                new ObjectParameter("matterNo", matterNo) :
                new ObjectParameter("matterNo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RetrieveMatterByNum_Result>("RetrieveMatterByNum", matterNoParameter);
        }
    }
}
