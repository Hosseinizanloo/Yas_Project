using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EF_Core.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EF_Core
{
    public class DiscountContext : DbContext
    {
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
        public DbSet<ColleagueDiscount> ColleagueDiscounts { get; set; }
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {

        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDoscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);// این میاد اسمبلی را اسکن میکند هر کدوم که جنساشون شبیه مپینگ ها باشد خود به خود اپلای میکنه روی مدل بیلدر
            base.OnModelCreating(modelBuilder);
        }
    }
}
