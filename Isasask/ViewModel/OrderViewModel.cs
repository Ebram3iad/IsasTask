using Isasask.Models;
using System.Collections.Generic;
namespace Isasask.ViewModel
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public string SelectedCategory { get; set; }
        public int Quantity { get; set; }

    }
}
