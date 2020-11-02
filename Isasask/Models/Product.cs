using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Isasask.Models
{
    public class Product
    {
        [key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int AvailableQuantity { get; set; }

        public Category Category { get; set; }

        public IEnumerable<Product_Order> Product_Orders { get; set; }

    }
}
