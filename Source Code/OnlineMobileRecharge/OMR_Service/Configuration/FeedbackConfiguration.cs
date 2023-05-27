using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedback");

            builder.HasKey(x => x.FeedbackID);
            builder.Property(x => x.FeedbackID).UseIdentityColumn();
            builder.Property(x => x.StarRate).IsRequired(false);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.CustomerID).IsRequired(true);
            builder.Property(x => x.ServiceID).IsRequired(false);
            builder.HasOne(x => x.Customer).WithMany(x => x.Feedback).HasForeignKey(x => x.CustomerID);
            builder.HasOne(x => x.Service).WithMany(x => x.Feedback).HasForeignKey(x => x.ServiceID);
        }
    }
}