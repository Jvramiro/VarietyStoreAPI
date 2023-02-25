using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarietyStoreAPI.Models;

namespace VarietyStoreAPI.Repositories.Interfaces {
    public interface IOrderRepositorie {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetById(int id);
        Task<Order> Add(Order order);
        Task<Order> Update(Order order, int id);
        Task<bool> Delete(int id);
    }
}
