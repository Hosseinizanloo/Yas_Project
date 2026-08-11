using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EF_Core.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EF_Core
{
    public class InventoryContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);// این میاد اسمبلی را اسکن میکند هر کدوم که جنساشون شبیه مپینگ ها باشد خود به خود اپلای میکنه روی مدل بیلدر
            base.OnModelCreating(modelBuilder);
        }
    }
}
