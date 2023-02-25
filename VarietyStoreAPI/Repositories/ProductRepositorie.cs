using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarietyStoreAPI.Data;
using VarietyStoreAPI.Models;
using VarietyStoreAPI.Repositories.Interfaces;

namespace VarietyStoreAPI.Repositories {
    public class ProductRepositorie : IProductRepositorie {
        private readonly ManagerSystemDBContext _dbContext;
        public ProductRepositorie(ManagerSystemDBContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Product> GetById(int id) {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.id == id);
        }
        public async Task<List<Product>> GetAllProducts() {
            return await _dbContext.Products.ToListAsync();
        }
        public async Task<Product> Add(Product product) {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }
        public async Task<Product> Update(Product product, int id) {
            Product currentProduct = await GetById(id);

            if (currentProduct == null) {
                throw new Exception($"Product {id} not found");
            }

            currentProduct.Name = string.IsNullOrEmpty(product.Name) ? currentProduct.Name : product.Name;
            currentProduct.Price = product.Price == 0 ? currentProduct.Price : product.Price;
            currentProduct.Quantity = product.Quantity;

            _dbContext.Products.Update(currentProduct);
            await _dbContext.SaveChangesAsync();

            return currentProduct;
        }
        public async Task<bool> Delete(int id) {
            Product currentProduct = await GetById(id);

            if (currentProduct == null) {
                throw new Exception($"Product {id} not found");
            }

            _dbContext.Products.Remove(currentProduct);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
