using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.UserID);
            builder.Property(x => x.UserID).UseIdentityColumn();
            builder.Property(x => x.Username).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired(true).HasMaxLength(500);
            builder.HasOne(x => x.Employee).WithMany(x => x.User).HasForeignKey(x => x.EmployeeID);
        }
    }
}