using System;
using System.Collections.Generic;

namespace OnionArch.Domain.Entities
{
    public partial class Category
    {
        public Category()
        {
            Charge = new HashSet<Charge>();
        }

        public int CategoryNo { get; set; }
        public string CategoryDesc { get; set; }
        public string CategoryCode { get; set; }

        public virtual ICollection<Charge> Charge { get; set; }
    }
}
