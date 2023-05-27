using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");

            builder.HasKey(x => x.GroupID);
            builder.Property(x => x.GroupID).UseIdentityColumn();
        }
    }
}