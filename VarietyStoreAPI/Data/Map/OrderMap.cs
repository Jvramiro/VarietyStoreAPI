using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarietyStoreAPI.Models;

namespace VarietyStoreAPI.Data.Map {
    public class OrderMap : IEntityTypeConfiguration<Order> {
        public void Configure(EntityTypeBuilder<Order> builder) {
            builder.HasKey(x => x.id);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();

            builder.HasOne(x => x.User);
            builder.HasOne(x => x.Product);
        }

    }
}
