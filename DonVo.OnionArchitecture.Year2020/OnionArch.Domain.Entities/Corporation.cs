using System;
using System.Collections.Generic;

namespace OnionArch.Domain.Entities
{
    public partial class Corporation
    {
        public Corporation()
        {
            Member = new HashSet<Member>();
        }

        public int CorpNo { get; set; }
        public string CorpName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string Country { get; set; }
        public string MailCode { get; set; }
        public string PhoneNo { get; set; }
        public DateTime ExprDt { get; set; }
        public int RegionNo { get; set; }
        public string CorpCode { get; set; }

        public virtual Region RegionNoNavigation { get; set; }
        public virtual ICollection<Member> Member { get; set; }
    }
}
