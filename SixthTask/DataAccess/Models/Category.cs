using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual ICollection<Spec> Specs { get; } = new List<Spec>();
}
