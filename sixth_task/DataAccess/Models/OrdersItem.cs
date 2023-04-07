using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class OrdersItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Product Item { get; set; } = null!;
}
