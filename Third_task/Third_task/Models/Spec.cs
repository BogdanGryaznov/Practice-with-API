using System;
using System.Collections.Generic;

namespace Third_task.Models
{
    public partial class Spec
    {
        public Spec()
        {
            SpecsItems = new HashSet<SpecsItem>();
        }

        public int SpecId { get; set; }
        public int CategoryId { get; set; }
        public string SpecName { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<SpecsItem> SpecsItems { get; set; }
    }
}
