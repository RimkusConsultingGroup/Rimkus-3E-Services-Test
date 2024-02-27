using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.UKGTE3E
{
    public enum UKGTE3ELookupTypes
    {
        [Description("WorkCalendar")]
        WorkCalendar = 1,
        [Description("Section")]
        Section = 2,
        [Description("RateClass")]
        RateClass = 3,
        [Description("Title")]
        Title = 4,
        [Description("Department")]
        Department = 5,
        [Description("Office")]
        Office = 6,
        [Description("Timekeeper")]
        Tkpr = 7,
        [Description("TkprType")]
        TkprType = 8,
        [Description("State")]
        State = 9,
        [Description("TkprStatus")]
        TkprStatus = 10,
        [Description("Country")]
        Country = 11,
        [Description("Supervisor_CCC")]
        Supervisor_CCC = 12

    }

    public enum UKG3EStatus
    {
        Active = 150,
        Inactive = 250
    }

    public enum UKG3ENxUnit
    {
        IsFirm = 0,
        RimkusConsultingGroup = 1,
        RCGLousiana = 2,
        RimkusAnalyticsLLC = 3,
        RimkusConsultingLtd = 4,
        RCGCanada = 5,
        RCGInc = 6,
        LeGroupIRC = 62,
        IRCBuildingSG = 61,
        ASE = 7,
        MECE = 8,
        CCI = 65,
    }
}
