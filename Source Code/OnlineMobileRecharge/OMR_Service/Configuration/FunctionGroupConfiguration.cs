using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class FunctionGroupConfiguration : IEntityTypeConfiguration<FunctionGroup>
    {
        public void Configure(EntityTypeBuilder<FunctionGroup> builder)
        {
            builder.ToTable("FunctionGroup");

            builder.HasKey(x => new {x.GroupID, x.FunctionID});
            builder.HasOne(x => x.Function).WithMany(x => x.FunctionGroup).HasForeignKey(x => x.FunctionID);
            builder.HasOne(x => x.Group).WithMany(x => x.FunctionGroup).HasForeignKey(x => x.GroupID);
        }
    }
}