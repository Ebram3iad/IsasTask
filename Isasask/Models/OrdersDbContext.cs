using Isasask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Isasask.Models
{
    public class OrdersDbContext:DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Order>().HasKey(po => new {po.ProductId, po.OrderId });
            modelBuilder.Entity<Product_Order>()
                .HasOne<Product>(po => po.Product)
                .WithMany(p => p.Product_Orders)
                .HasForeignKey(po => po.ProductId);

            modelBuilder.Entity<Product_Order>()
                .HasOne<Order>(po => po.Order)
                .WithMany(o => o.Product_Orders)
                .HasForeignKey(po => po.OrderId);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product_Order> Product_Orders { get; set; }

    }
}
