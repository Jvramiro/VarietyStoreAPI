using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarietyStoreAPI.Data.Map;
using VarietyStoreAPI.Models;

namespace VarietyStoreAPI.Data {
    public class ManagerSystemDBContext : DbContext {

        public ManagerSystemDBContext(DbContextOptions<ManagerSystemDBContext> options) : base(options){

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
