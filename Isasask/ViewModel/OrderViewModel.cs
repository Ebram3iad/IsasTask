using Isasask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    public class ProductOrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public string ClientName { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
