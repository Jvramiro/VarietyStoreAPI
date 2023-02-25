using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarietyStoreAPI.Models;
using VarietyStoreAPI.Repositories.Interfaces;

namespace VarietyStoreAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase {

        private readonly IOrderRepositorie _IOrderRepositorie;
        public OrderController(IOrderRepositorie IOrderRepositorie) {
            _IOrderRepositorie = IOrderRepositorie;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders() {
            List<Order> orders = await _IOrderRepositorie.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Order>>> GetOrderById(int id) {
            Order currentOrder = await _IOrderRepositorie.GetById(id);
            return Ok(currentOrder);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] Order order) {
            Order currentOrder = await _IOrderRepositorie.Add(order);
            return Ok(currentOrder);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder([FromBody] Order order, int id) {
            order.id = id;
            Order currentOrder = await _IOrderRepositorie.Update(order, id);
            return Ok(currentOrder);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id) {
            bool isDeleted = await _IOrderRepositorie.Delete(id);
            return Ok(isDeleted);
        }

    }
}
