using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Model;

namespace BookStore.UI.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Orders = new HashSet<Orders>();
        }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(30, ErrorMessage = "Maximum username length is 30")]
        [MinLength(3, ErrorMessage = "Minimum username length is 3")]
        public string Username { get; set; }

        /// <summary>
        /// Password, between 3 and 100 characters
        /// </summary>
        [Display(Name = "Password")]
        [MinLength(3, ErrorMessage = "Minium password length is 3")]
        [MaxLength(100, ErrorMessage = "Maximum password length is 100")]
        [ScaffoldColumn(false)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public int Id { get; set; }

        /// <summary>
        /// Customer which placed the order
        /// </summary>
        [Required(ErrorMessage = "Customer name is required")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Location order was placed to 
        /// </summary>
        [Required(ErrorMessage = "Location name is required")]
        public int StoreId { get; set; }

        /// <summary>
        /// Total value of the order
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Time order wwas created client side
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// nav prop to ordered from location
        /// </summary>
        public virtual Stores Stores { get; set; }
        /// <summary>
        /// Navigation property to ordering customer
        /// </summary>
        public virtual Customers Customers { get; set; }

        /// <summary>
        /// Items belonging to this order
        /// </summary>
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
