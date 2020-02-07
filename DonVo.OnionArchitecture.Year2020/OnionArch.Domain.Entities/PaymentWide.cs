using System;
using System.Collections.Generic;

namespace OnionArch.Domain.Entities
{
    public partial class PaymentWide
    {
        public int MemberNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Middleinitial { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string MailCode { get; set; }
        public string PhoneNo { get; set; }
        public DateTime ExprDt { get; set; }
        public string MemberCode { get; set; }
        public int RegionNo { get; set; }
        public string RegionName { get; set; }
        public int PaymentNo { get; set; }
        public DateTime PaymentDt { get; set; }
        public decimal PaymentAmt { get; set; }
        public string PaymentCode { get; set; }
    }
}
