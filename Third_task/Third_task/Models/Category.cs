using System;
using System.Collections.Generic;

namespace Third_task.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            Specs = new HashSet<Spec>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Spec> Specs { get; set; }
    }
}
