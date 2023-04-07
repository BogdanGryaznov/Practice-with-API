using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class SpecsItem
{
    public int SpecItemId { get; set; }

    public int ItemId { get; set; }

    public int SpecId { get; set; }

    public string? SpecValue { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Product Item { get; set; } = null!;

    public virtual Spec Spec { get; set; } = null!;
}
