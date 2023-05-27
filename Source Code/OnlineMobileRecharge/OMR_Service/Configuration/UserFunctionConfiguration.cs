using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class UserFunctionConfiguration : IEntityTypeConfiguration<UserFunction>
    {
        public void Configure(EntityTypeBuilder<UserFunction> builder)
        {
            builder.ToTable("UserFunction");

            builder.HasKey(x => new { x.UserID, x.FunctionID });
            builder.HasOne(x => x.User).WithMany(x => x.UserFunction).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.Function).WithMany(x => x.UserFunction).HasForeignKey(x => x.FunctionID);
        }
    }
}