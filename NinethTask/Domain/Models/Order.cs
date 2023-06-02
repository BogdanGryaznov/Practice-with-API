using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Order
    {
        public int IdUser { get; set; }

        public int OrderId { get; set; }

        public int DeliveryId { get; set; }

        public int StatusId { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}


