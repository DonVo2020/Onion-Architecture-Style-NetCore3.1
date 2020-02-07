using System;
using System.Collections.Generic;

namespace OnionArch.Domain.Entities
{
    public partial class ChargeWide
    {
        public int MemberNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int RegionNo { get; set; }
        public string RegionName { get; set; }
        public string ProviderName { get; set; }
        public string CategoryDesc { get; set; }
        public int ChargeNo { get; set; }
        public int ProviderNo { get; set; }
        public int CategoryNo { get; set; }
        public DateTime ChargeDt { get; set; }
        public decimal ChargeAmt { get; set; }
        public string ChargeCode { get; set; }
    }
}
