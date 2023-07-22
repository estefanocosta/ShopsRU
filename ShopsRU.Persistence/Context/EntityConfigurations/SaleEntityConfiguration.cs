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
    public class SaleEntityConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.TotalAmount).IsRequired();
            builder.Property(x => x.SaleDate).IsRequired();
            builder.HasMany(c => c.SaleDetails).WithOne(p => p.Sale).HasForeignKey(p => p.SaleId);
            builder.HasMany(c => c.Invoices).WithOne(p => p.Sale).HasForeignKey(p => p.SaleId);
            #region Base Entity Configuration
            builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            #endregion
        }
    }
}
