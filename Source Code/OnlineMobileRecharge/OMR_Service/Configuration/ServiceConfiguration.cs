using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Service");

            builder.HasKey(x => x.ServiceID);
            builder.Property(x => x.ServiceID).UseIdentityColumn();
            builder.Property(x => x.ServiceName).IsRequired(true).HasMaxLength(500);
            builder.Property(x => x.Days).IsRequired(false);
            builder.Property(x => x.ServiceProviderID).IsRequired(true);
            builder.HasOne(x => x.ServiceProvider).WithMany(x => x.Service).HasForeignKey(x => x.ServiceProviderID);
        }
    }
}