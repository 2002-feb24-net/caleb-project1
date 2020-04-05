using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Model;

namespace BookStore.UI.Models
{
    public class CreateOrderViewModel
    {
        public List<Inventory> Inventory { get; set; }
        public Orders Item { get; set; }
    }
}
