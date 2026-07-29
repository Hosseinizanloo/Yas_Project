using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EF_Core.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("Pictures");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x=>x.PictureAlt).HasMaxLength(200).IsRequired();
            builder.Property(x=>x.PictureTitle).HasMaxLength(200).IsRequired();

            builder.HasOne(x => x.Product).
                WithMany(x=>x.ProductsPictures).HasForeignKey(x=>x.ProductId);
        }
    }
}
