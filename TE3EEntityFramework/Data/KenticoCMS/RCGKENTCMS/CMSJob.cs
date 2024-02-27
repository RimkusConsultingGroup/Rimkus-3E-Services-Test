using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Datasource;
using TE3EEntityFramework.Datasource.RCGKENTCMS.DataModel;

namespace TE3EEntityFramework.Data.KenticoCMS.RCGKENTCMS
{
    public class CMSJob
    {
        private CMSAssignment _assignment = new CMSAssignment();
        public CMSAssignment assignment 
        {
            get { return _assignment; }
            set { _assignment = value; }
        }

        private CMSOrderingClient _orderingClient = new CMSOrderingClient();
        public CMSOrderingClient orderingClient
        {
            get { return _orderingClient; }
            set { _orderingClient = value; }
        }

        private List<CMSIncidentLocation> _incidentLocations = new List<CMSIncidentLocation>();
        public List<CMSIncidentLocation> incidentLocations
        {
            get { return _incidentLocations; }
            set { _incidentLocations = value; }
        }

        private List<CMSPayorDetail> _payorDetails = new List<CMSPayorDetail>();
        public List<CMSPayorDetail> payorDetails
        {
            get { return _payorDetails; }
            set { _payorDetails = value; }
        }

        private List<CMSAdditionalParty> _additionalParties = new List<CMSAdditionalParty>();
        public List<CMSAdditionalParty> additionalParties
        {
            get { return _additionalParties; }
            set { _additionalParties = value; }
        }

        private List<CMSCoConsultant> _coConsultants = new List<CMSCoConsultant>();
        public List<CMSCoConsultant> coConsultants
        {
            get { return _coConsultants; }
            set { _coConsultants = value; }
        }
    }

    public enum SvcOps
    {
        [Description("ADD")]
        Add,
        [Description("EDIT")]
        Edit,
        [Description("DELETE")]
        Delete,
        [Description("IGNORE")]
        Ignore
    }

    //public class Out3eAssignment
    //{
    //    private OutAssignmentsCM _assignment = new OutAssignmentsCM();
    //    public OutAssignmentsCM assignment
    //    {
    //        get { return _assignment; }
    //        set { _assignment = value; }
    //    }

    //    private OutOrderingClientsCM _orderingClient = new OutOrderingClientsCM();
    //    public OutOrderingClientsCM orderingClient
    //    {
    //        get { return _orderingClient; }
    //        set { _orderingClient = value; }
    //    }

    //    private List<OutIncidentLocationsCM> _incidentLocations = new List<OutIncidentLocationsCM>();
    //    public List<OutIncidentLocationsCM> incidentLocations
    //    {
    //        get { return _incidentLocations; }
    //        set { _incidentLocations = value; }
    //    }

    //    private List<OutPayorDetailsCM> _payorDetails = new List<OutPayorDetailsCM>();
    //    public List<OutPayorDetailsCM> payorDetails
    //    {
    //        get { return _payorDetails; }
    //        set { _payorDetails = value; }
    //    }

    //    private List<OutAdditionalPartiesCM> _additionalParties = new List<OutAdditionalPartiesCM>();
    //    public List<OutAdditionalPartiesCM> additionalParties
    //    {
    //        get { return _additionalParties; }
    //        set { _additionalParties = value; }
    //    }

    //    private List<OutCoConsultantsCM> _coConsultants = new List<OutCoConsultantsCM>();
    //    public List<OutCoConsultantsCM> coConsultants
    //    {
    //        get { return _coConsultants; }
    //        set { _coConsultants = value; }
    //    }
    //}
}
