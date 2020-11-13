using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VATUShop.MVC.Models
{
    public class VATUShopMVCDbContext : IdentityDbContext<ApplicationUser>
    {
        public VATUShopMVCDbContext(DbContextOptions<VATUShopMVCDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<StatusOrder> StatusOrders { get; set; }
        public DbSet<CustomerAnonymous> CustomerAnonymouses { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<Province>();
            //modelBuilder.Ignore<District>();
            //modelBuilder.Ignore<Ward>();

            modelBuilder.Entity<Order>()
                .HasOne<StatusOrder>(o => o.StatusOrder)
                .WithMany(so => so.Orders)
                .HasForeignKey(o => o.StatusId);

            modelBuilder.Entity<OrderDetail>()
            .HasOne<Order>(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId);
        }
    }
}
