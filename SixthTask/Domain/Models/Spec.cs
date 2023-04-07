using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Spec
    {
        public int SpecId { get; set; }

        public int CategoryId { get; set; }

        public string SpecName { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<SpecsItem> SpecsItems { get; } = new List<SpecsItem>();
    }

}

