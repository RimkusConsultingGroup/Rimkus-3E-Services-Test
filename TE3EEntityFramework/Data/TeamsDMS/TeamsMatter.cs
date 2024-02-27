using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.TeamsDMS
{
    public class TeamsMatter
    {
        public string openTkpr { get; set; }
        public string reportingOffice { get; set; }
        public string section { get; set; }
        public string department { get; set; }
        public string mattDate { get; set; }
        public string narrative { get; set; }
        public string scopeOfWork { get; set; }
        public string assignmentId { get; set; }
        public string evidenceId { get; set; }
        public string mattDesc { get; set; }
        public string[] ownerUsers { get; set; }
        public string[] memberUsers { get; set; }
        public string mattNum { get; set; }
        public string mattName { get; set; }
        public string closeTkpr { get; set; }
        public string reason { get; set; }
        public string closeDate { get; set; }
        public string mattStatus { get; set; }
        public CaseStatus caseStatus { get; set; }
        public string mattStatusDesc { get; set; }
        public string rspkpr { get; set; }
        public bool isTeamsChanged { get; set; }
        public bool isTeamRehydrated { get; set; }
        public string processId { get; set; }
    }

    public class CaseOpened
    {
        public string openTkpr { get; set; }
        public string reportingOffice { get; set; }
        public string section { get; set; }
        public string department { get; set; }
        public string mattDate { get; set; }
        public string narrative { get; set; }
        public string scopeOfWork { get; set; }
        public string assignmentId { get; set; }
        public string evidenceId { get; set; }
        public string processId { get; set; }
        public string mattDesc { get; set; }
        public string[] ownerUsers { get; set; }
        public string[] memberUsers { get; set; }
        public string mattNum { get; set; }
        public string mattName { get; set; }
    }

    public class CaseAssignment
    {
        public string mattNum { get; set; }
        public string mattName { get; set; }
        public string rspTkpr { get; set; }
        public string[] ownerUsers { get; set; }
        public string[] memberUsers { get; set; }
        public string narrative { get; set; }
        public string scopeOfWork { get; set; }
    }

    public class CaseClosed
    {
        public string mattNum { get; set; }
        public string mattName { get; set; }
        public string closeTkpr { get; set; }
        public string reason { get; set; }
        public string closeDate { get; set; }
    }

    public class TeamAction
    {
        public string rspTkpr { get; set; }
        public string actionDirective { get; set; }
        public string reason { get; set; }
        public string processId { get; set; }
        public ExtendedProperties extendedProperties { get; set; }
        public string mattNum { get; set; }
        public string mattName { get; set; }
    }

    public class ExtendedProperties
    {
        public string ownerUsers { get; set; }
        public string memberUsers { get; set; }
    }

    public enum CaseStatus
    {
        Closed = 10,
        Complete = 20,
        OpenforEvidenceBilling = 30,
        Open = 40,
        OpenforTime = 50,
        Pending = 60,
        ClientRefused = 70,
        Declined = 80,
        Hold = 90,
        NoBilling = 99,
        AwaitingRetainer = 100
    }
}
