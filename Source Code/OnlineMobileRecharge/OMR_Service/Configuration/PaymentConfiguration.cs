using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");

            builder.HasKey(x => x.PaymentID);
            builder.Property(x => x.PaymentID).UseIdentityColumn();
        }
    }
}