using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Core.Enums
{
    public enum MemberStatut
    {
        [Description("Active")]
        Active = 1,

        [Description("Deactivated")]
        Deactivated,

        [Description("Report")]
        Report
    }

    public enum CommentaireStatut
    {
        [Description("Active")]
        Active = 1,

        [Description("Deactivated")]
        Deactivated,

        [Description("Report")]
        Report
    }

    public enum PostStatut
    {
        [Description("Active")]
        Active = 1,

        [Description("Deactivated")]
        Deactivated,

        [Description("Report")]
        Report
    }
}