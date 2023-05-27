using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProvider>
    {
        public void Configure(EntityTypeBuilder<ServiceProvider> builder)
        {
            builder.ToTable("ServiceProvider");

            builder.HasKey(x => x.ServiceProviderID);
            builder.Property(x => x.ServiceProviderID).UseIdentityColumn();
            builder.Property(x => x.ServiceProviderName).IsRequired(true).HasMaxLength(50);
        }
    }
}