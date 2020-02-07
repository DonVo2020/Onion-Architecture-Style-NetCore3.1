using System;
using System.Collections.Generic;

namespace OnionArch.Domain.Entities
{
    public partial class Region
    {
        public Region()
        {
            Corporation = new HashSet<Corporation>();
            Member = new HashSet<Member>();
            Provider = new HashSet<Provider>();
        }

        public int RegionNo { get; set; }
        public string RegionName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string Country { get; set; }
        public string MailCode { get; set; }
        public string PhoneNo { get; set; }
        public string RegionCode { get; set; }

        public virtual ICollection<Corporation> Corporation { get; set; }
        public virtual ICollection<Member> Member { get; set; }
        public virtual ICollection<Provider> Provider { get; set; }
    }
}
