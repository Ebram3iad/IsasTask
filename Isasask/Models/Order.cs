using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Isasask.Models
{
    public class Order
    {
        [key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "رقم الطلب")]
        public int OrderNumber { get; set; }
        [Required]
        [Display(Name = "تاريخ الطلب")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "أسم العميل")]
        public string ClientName { get; set; }
        public IEnumerable<Product_Order> Product_Orders { get; set; }

    }
}
