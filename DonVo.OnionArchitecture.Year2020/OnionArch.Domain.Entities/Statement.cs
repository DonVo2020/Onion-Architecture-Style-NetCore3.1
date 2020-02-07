using System;
using System.Collections.Generic;

namespace OnionArch.Domain.Entities
{
    public partial class Statement
    {
        public int StatementNo { get; set; }
        public int MemberNo { get; set; }
        public DateTime StatementDt { get; set; }
        public DateTime DueDt { get; set; }
        public decimal StatementAmt { get; set; }
        public string StatementCode { get; set; }

        public virtual Member MemberNoNavigation { get; set; }
    }
}
