using System;
using System.Collections.Generic;

namespace OnionArch.Domain.Entities
{
    public partial class Charge
    {
        public int ChargeNo { get; set; }
        public int MemberNo { get; set; }
        public int ProviderNo { get; set; }
        public int CategoryNo { get; set; }
        public DateTime ChargeDt { get; set; }
        public decimal ChargeAmt { get; set; }
        public int StatementNo { get; set; }
        public string ChargeCode { get; set; }

        public virtual Category CategoryNoNavigation { get; set; }
        public virtual Member MemberNoNavigation { get; set; }
        public virtual Provider ProviderNoNavigation { get; set; }
    }
}
