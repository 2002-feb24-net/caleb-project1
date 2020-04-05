using System;
using System.Collections.Generic;

namespace P0Library.Model
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? StoreId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? OrderTime { get; set; }
        public int? Quantity { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Products Product { get; set; }
        public virtual Stores Store { get; set; }
    }
}
