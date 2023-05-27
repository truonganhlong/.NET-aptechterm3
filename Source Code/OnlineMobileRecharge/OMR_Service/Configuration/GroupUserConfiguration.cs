using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class GroupUserConfiguration : IEntityTypeConfiguration<GroupUser>
    {
        public void Configure(EntityTypeBuilder<GroupUser> builder)
        {
            builder.ToTable("GroupUser");

            builder.HasKey(x => new { x.GroupID, x.UserID });
            builder.HasOne(x => x.User).WithMany(x => x.GroupUser).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.Group).WithMany(x => x.GroupUser).HasForeignKey(x => x.GroupID);
        }
    }
}