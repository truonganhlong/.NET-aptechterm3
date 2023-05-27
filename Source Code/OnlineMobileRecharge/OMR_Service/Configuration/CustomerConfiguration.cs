using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(x => x.CustomerID);
            builder.Property(x => x.CustomerID).UseIdentityColumn();
            builder.Property(x => x.Password).IsRequired(true).HasMaxLength(500);
            builder.Property(x => x.Phone).IsRequired(true).HasMaxLength(20);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.AvatarLink).IsRequired(false);
            builder.Property(x => x.TuneID).IsRequired(false);
            builder.Property(x => x.Disturb).HasDefaultValue(false);
            builder.HasOne(x => x.Tune).WithMany(x => x.Customer).HasForeignKey(x => x.TuneID);
        }
    }
}