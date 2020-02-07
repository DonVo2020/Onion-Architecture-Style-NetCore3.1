using System;
using System.Collections.Generic;

namespace OnionArch.Domain.Entities
{
    public partial class Member
    {
        public Member()
        {
            Charge = new HashSet<Charge>();
            Payment = new HashSet<Payment>();
            Statement = new HashSet<Statement>();
        }

        public int MemberNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Middleinitial { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string Country { get; set; }
        public string MailCode { get; set; }
        public string PhoneNo { get; set; }
        public byte[] Photograph { get; set; }
        public DateTime IssueDt { get; set; }
        public DateTime ExprDt { get; set; }
        public int RegionNo { get; set; }
        public int? CorpNo { get; set; }
        public decimal? PrevBalance { get; set; }
        public decimal? CurrBalance { get; set; }
        public string MemberCode { get; set; }

        public virtual Corporation CorpNoNavigation { get; set; }
        public virtual Region RegionNoNavigation { get; set; }
        public virtual ICollection<Charge> Charge { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Statement> Statement { get; set; }
    }
}
