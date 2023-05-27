using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OMR_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMR_Service.Configuration
{
    public class TuneConfiguration : IEntityTypeConfiguration<Tune>
    {
        public void Configure(EntityTypeBuilder<Tune> builder)
        {
            builder.ToTable("Tune");

            builder.HasKey(x => x.TuneID);
            builder.Property(x => x.TuneID).UseIdentityColumn();
        }
    }
}