using System;
using System.Collections.Generic;

namespace OnionArch.Domain.Entities
{
    public partial class Payment
    {
        public int PaymentNo { get; set; }
        public int MemberNo { get; set; }
        public DateTime PaymentDt { get; set; }
        public decimal PaymentAmt { get; set; }
        public int? StatementNo { get; set; }
        public string PaymentCode { get; set; }

        public virtual Member MemberNoNavigation { get; set; }
    }
}
