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
    public class SaleDetailEntityConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SaleId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.TotalPrice).IsRequired();
            builder.HasOne(c => c.Sale).WithMany(p => p.SaleDetails).HasForeignKey(p => p.SaleId);
            #region Base Entity Configuration
            builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            #endregion
        }
    }
}
