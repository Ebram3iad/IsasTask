using System;

namespace Isasask.ViewModel
{
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
