using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Product
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public string? ItemDescription { get; set; }

    public int WarehouseQuantity { get; set; }

    public int? Price { get; set; }

    public int? CategoryId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrdersItem> OrdersItems { get; } = new List<OrdersItem>();

    public virtual ICollection<SpecsItem> SpecsItems { get; } = new List<SpecsItem>();
}
