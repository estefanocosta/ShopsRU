using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.Context.EntityConfigurations
{
    public class LogEntityConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Action).IsRequired();
            builder.Property(x => x.Controller).IsRequired();
            builder.Property(x => x.Method).IsRequired();
            builder.Property(x => x.Action).HasMaxLength(60);
            builder.Property(x => x.Controller).HasMaxLength(60);
            builder.Property(x => x.Method).HasMaxLength(60);
            builder.Property(x => x.PostDate).IsRequired();
            builder.Property(x => x.ErrorCode).IsRequired();
            builder.Property(x => x.Trace).IsRequired();
            builder.Property(x => x.UserID).IsRequired();
        }
    }
}
