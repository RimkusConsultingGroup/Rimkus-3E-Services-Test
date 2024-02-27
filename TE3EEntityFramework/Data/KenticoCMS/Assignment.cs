using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE3EEntityFramework.Datasource;

namespace TE3EEntityFramework.Data.KenticoCMS
{
    [Obsolete]
    public class In3eAssignment
    {
        private InAssignmentsCM _assignment = new InAssignmentsCM();
        public InAssignmentsCM assignment 
        {
            get { return _assignment; }
            set { _assignment = value; }
        }

        private InOrderingClientsCM _orderingClient = new InOrderingClientsCM();
        public InOrderingClientsCM orderingClient
        {
            get { return _orderingClient; }
            set { _orderingClient = value; }
        }

        private List<InIncidentLocationsCM> _incidentLocations = new List<InIncidentLocationsCM>();
        public List<InIncidentLocationsCM> incidentLocations
        {
            get { return _incidentLocations; }
            set { _incidentLocations = value; }
        }

        private List<InPayorDetailsCM> _payorDetails = new List<InPayorDetailsCM>();
        public List<InPayorDetailsCM> payorDetails
        {
            get { return _payorDetails; }
            set { _payorDetails = value; }
        }

        private List<InAdditionalPartiesCM> _additionalParties = new List<InAdditionalPartiesCM>();
        public List<InAdditionalPartiesCM> additionalParties
        {
            get { return _additionalParties; }
            set { _additionalParties = value; }
        }

        private List<InCoConsultantsCM> _coConsultants = new List<InCoConsultantsCM>();
        public List<InCoConsultantsCM> coConsultants
        {
            get { return _coConsultants; }
            set { _coConsultants = value; }
        }
    }

    [Obsolete]
    public class Out3eAssignment
    {
        private OutAssignmentsCM _assignment = new OutAssignmentsCM();
        public OutAssignmentsCM assignment
        {
            get { return _assignment; }
            set { _assignment = value; }
        }

        private OutOrderingClientsCM _orderingClient = new OutOrderingClientsCM();
        public OutOrderingClientsCM orderingClient
        {
            get { return _orderingClient; }
            set { _orderingClient = value; }
        }

        private List<OutIncidentLocationsCM> _incidentLocations = new List<OutIncidentLocationsCM>();
        public List<OutIncidentLocationsCM> incidentLocations
        {
            get { return _incidentLocations; }
            set { _incidentLocations = value; }
        }

        private List<OutPayorDetailsCM> _payorDetails = new List<OutPayorDetailsCM>();
        public List<OutPayorDetailsCM> payorDetails
        {
            get { return _payorDetails; }
            set { _payorDetails = value; }
        }

        private List<OutAdditionalPartiesCM> _additionalParties = new List<OutAdditionalPartiesCM>();
        public List<OutAdditionalPartiesCM> additionalParties
        {
            get { return _additionalParties; }
            set { _additionalParties = value; }
        }

        private List<OutCoConsultantsCM> _coConsultants = new List<OutCoConsultantsCM>();
        public List<OutCoConsultantsCM> coConsultants
        {
            get { return _coConsultants; }
            set { _coConsultants = value; }
        }
    }
}
