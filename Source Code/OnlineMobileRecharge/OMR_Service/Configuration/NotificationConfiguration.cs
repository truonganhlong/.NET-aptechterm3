using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notification");

            builder.HasKey(x => x.NotificationID);
            builder.Property(x => x.NotificationID).UseIdentityColumn();
            builder.Property(x => x.NotifyContent).IsRequired(true).HasMaxLength(200);
            builder.Property(x => x.Time).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.CustomerID).IsRequired(true);
            builder.HasOne(x => x.Customer).WithMany(x => x.Notification).HasForeignKey(x => x.CustomerID);
        }
    }
}