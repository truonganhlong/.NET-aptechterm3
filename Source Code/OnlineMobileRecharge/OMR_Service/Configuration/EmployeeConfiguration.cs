using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(x => x.EmployeeID);
            builder.Property(x => x.EmployeeID).UseIdentityColumn();            
            builder.Property(x => x.Phone).IsRequired(true).HasMaxLength(20);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.AvatarLink).IsRequired(false);
            builder.Property(x => x.ServiceProviderID).IsRequired(false);
            builder.HasOne(x => x.ServiceProvider).WithMany(x => x.Employee).HasForeignKey(x => x.ServiceProviderID);
        }
    }
}