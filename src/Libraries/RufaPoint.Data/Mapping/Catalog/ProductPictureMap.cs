using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Catalog;

namespace RufaPoint.Data.Mapping.Catalog
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class ProductPictureMap : NopEntityTypeConfiguration<ProductPicture>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductPictureMap()
        {
            //this.ToTable("Product_Picture_Mapping");
            //this.HasKey(pp => pp.Id);

            //this.HasRequired(pp => pp.Picture)
            //    .WithMany()
            //    .HasForeignKey(pp => pp.PictureId);


            //this.HasRequired(pp => pp.Product)
            //    .WithMany(p => p.ProductPictures)
            //    .HasForeignKey(pp => pp.ProductId);
        }
        protected override void DoConfig(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("Product_Picture_Mapping").HasKey(pp => pp.Id);

            builder.HasOne(pp => pp.Picture)
                .WithMany()
                .HasForeignKey(pp => pp.PictureId);


            builder.HasOne(pp => pp.Product)
                .WithMany(p => p.ProductPictures)
                .HasForeignKey(pp => pp.ProductId);
        }
    }
}