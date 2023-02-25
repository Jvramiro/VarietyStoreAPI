using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarietyStoreAPI.Data;
using VarietyStoreAPI.Models;
using VarietyStoreAPI.Repositories.Interfaces;

namespace VarietyStoreAPI.Repositories {
    public class OrderRepositorie : IOrderRepositorie {
        private readonly ManagerSystemDBContext _dbContext;
        public OrderRepositorie(ManagerSystemDBContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Order> GetById(int id) {
            return await _dbContext.Orders
                .Include(x => x.User)
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.id == id);
        }
        public async Task<List<Order>> GetAllOrders() {
            return await _dbContext.Orders
                .Include(x => x.User)
                .Include(x => x.Product)
                .ToListAsync();
        }
        public async Task<Order> Add(Order order) {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return order;
        }
        public async Task<Order> Update(Order order, int id) {
            Order currentOrder = await GetById(id);

            if (currentOrder == null) {
                throw new Exception($"Order {id} not found");
            }

            currentOrder.UserId = order.UserId == 0 ? currentOrder.UserId : order.UserId;
            currentOrder.ProductId = order.ProductId == 0 ? currentOrder.ProductId : order.ProductId;
            currentOrder.Value = order.Value == 0 ? currentOrder.Value : order.Value;
            currentOrder.Quantity = order.Quantity;

            _dbContext.Orders.Update(currentOrder);
            await _dbContext.SaveChangesAsync();

            return currentOrder;
        }
        public async Task<bool> Delete(int id) {
            Order currentOrder = await GetById(id);

            if (currentOrder == null) {
                throw new Exception($"Order {id} not found");
            }

            _dbContext.Orders.Remove(currentOrder);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
