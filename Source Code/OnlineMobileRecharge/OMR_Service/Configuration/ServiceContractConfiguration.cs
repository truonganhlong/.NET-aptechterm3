using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class ServiceContractConfiguration : IEntityTypeConfiguration<ServiceContract>
    {
        public void Configure(EntityTypeBuilder<ServiceContract> builder)
        {
            builder.ToTable("ServiceContract");

            builder.HasKey(x => x.ServiceContractID);
            builder.Property(x => x.ServiceContractID).UseIdentityColumn();
            builder.Property(x => x.Phone).IsRequired(true).HasMaxLength(20);
            builder.Property(x => x.CustomerID).IsRequired(true);
            builder.Property(x => x.ServiceID).IsRequired(true);
            builder.HasOne(x => x.Customer).WithMany(x => x.ServiceContract).HasForeignKey(x => x.CustomerID);
            builder.HasOne(x => x.Service).WithMany(x => x.ServiceContract).HasForeignKey(x => x.ServiceID);
        }
    }
}