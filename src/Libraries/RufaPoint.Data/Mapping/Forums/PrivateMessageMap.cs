﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RufaPoint.Core.Domain.Forums;

namespace RufaPoint.Data.Mapping.Forums
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class PrivateMessageMap : NopEntityTypeConfiguration<PrivateMessage>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public PrivateMessageMap()
        {
            //this.ToTable("Forums_PrivateMessage");
            //this.HasKey(pm => pm.Id);
            //this.Property(pm => pm.Subject).IsRequired().HasMaxLength(450);
            //this.Property(pm => pm.Text).IsRequired();

            //this.HasRequired(pm => pm.FromCustomer)
            //   .WithMany()
            //   .HasForeignKey(pm => pm.FromCustomerId)
            //   .WillCascadeOnDelete(false);

            //this.HasRequired(pm => pm.ToCustomer)
            //   .WithMany()
            //   .HasForeignKey(pm => pm.ToCustomerId)
            //   .WillCascadeOnDelete(false);
        }
        protected override void DoConfig(EntityTypeBuilder<PrivateMessage> builder)
        {
            builder.ToTable("Forums_PrivateMessage").HasKey(pm => pm.Id);
            builder.Property(pm => pm.Subject).IsRequired().HasMaxLength(450);
            builder.Property(pm => pm.Text).IsRequired();

            builder.HasOne(pm => pm.FromCustomer)
               .WithMany()
               .HasForeignKey(pm => pm.FromCustomerId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(pm => pm.ToCustomer)
               .WithMany()
               .HasForeignKey(pm => pm.ToCustomerId)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
