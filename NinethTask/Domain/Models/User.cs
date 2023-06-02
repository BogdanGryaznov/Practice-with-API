using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public int IdUser { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int RoleId { get; set; }

        public string Address { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual ICollection<Cart> Carts { get; } = new List<Cart>();

        public virtual ICollection<Order> Orders { get; } = new List<Order>();

        public virtual Role Role { get; set; } = null!;
    }
}


