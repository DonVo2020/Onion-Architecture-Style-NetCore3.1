using System;
using System.Collections.Generic;

namespace OnionArch.Domain.Entities
{
    public partial class Provider
    {
        public Provider()
        {
            Charge = new HashSet<Charge>();
        }

        public int ProviderNo { get; set; }
        public string ProviderName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string MailCode { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public DateTime IssueDt { get; set; }
        public DateTime ExprDt { get; set; }
        public int RegionNo { get; set; }
        public string ProviderCode { get; set; }

        public virtual Region RegionNoNavigation { get; set; }
        public virtual ICollection<Charge> Charge { get; set; }
    }
}
