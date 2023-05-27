using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class FunctionConfiguration : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.ToTable("Function");

            builder.HasKey(x => x.FunctionID);
            builder.Property(x => x.FunctionID).UseIdentityColumn();
        }
    }
}