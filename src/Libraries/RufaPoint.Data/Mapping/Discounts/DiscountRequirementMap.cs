using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Discounts;

namespace RufaPoint.Data.Mapping.Discounts
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class DiscountRequirementMap : NopEntityTypeConfiguration<DiscountRequirement>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public DiscountRequirementMap()
        {
            //this.ToTable("DiscountRequirement");
            //this.HasKey(requirement => requirement.Id);

            //this.Ignore(requirement => requirement.InteractionType);
            //this.HasMany(requirement => requirement.ChildRequirements)
            //    .WithOptional()
            //    .HasForeignKey(requirement => requirement.ParentId);
        }
        protected override void DoConfig(EntityTypeBuilder<DiscountRequirement> builder)
        {
            builder.ToTable("DiscountRequirement").HasKey(requirement => requirement.Id);

            builder.Ignore(requirement => requirement.InteractionType);
            builder.HasMany(requirement => requirement.ChildRequirements)
                .WithOne()
                .HasForeignKey(requirement => requirement.ParentId);
        }
    }
}