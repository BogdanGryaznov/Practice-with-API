using System;
using System.Collections.Generic;

namespace Third_task.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            OrdersItems = new HashSet<OrdersItem>();
            SpecsItems = new HashSet<SpecsItem>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public string? ItemDescription { get; set; }
        public int WarehouseQuantity { get; set; }
        public int? Price { get; set; }
        public int? CategoryId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrdersItem> OrdersItems { get; set; }
        public virtual ICollection<SpecsItem> SpecsItems { get; set; }
    }
}
