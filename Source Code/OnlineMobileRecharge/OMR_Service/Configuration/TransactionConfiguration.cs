using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");

            builder.HasKey(x => x.TransactionID);
            builder.Property(x => x.TransactionID).UseIdentityColumn();
            builder.Property(x => x.ServiceContractID).IsRequired(true);
            builder.Property(x => x.CustomerID).IsRequired(false);
            builder.Property(x => x.PaymentID).IsRequired(true);
            builder.Property(x => x.Days).IsRequired(false);
            builder.Property(x => x.TransferTime).HasDefaultValue(DateTime.Now);
            builder.HasOne(x => x.ServiceContract).WithMany(x => x.Transaction).HasForeignKey(x => x.ServiceContractID);
            builder.HasOne(x => x.Customer).WithMany(x => x.Transaction).HasForeignKey(x => x.CustomerID);
            builder.HasOne(x => x.Payment).WithMany(x => x.Transaction).HasForeignKey(x => x.PaymentID);
        }
    }
}