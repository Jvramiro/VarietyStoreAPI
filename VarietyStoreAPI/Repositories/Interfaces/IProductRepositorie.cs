using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarietyStoreAPI.Models;

namespace VarietyStoreAPI.Repositories.Interfaces {
    public interface IProductRepositorie {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetById(int id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product, int id);
        Task<bool> Delete(int id);
    }
}
