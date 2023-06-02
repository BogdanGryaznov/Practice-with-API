using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Cart
    {
        public int CartsId { get; set; }

        public int IdUser { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public bool IsDeleted { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;

        public virtual Product Item { get; set; } = null!;
    }
}


