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
    public class ProductController : ControllerBase {

        private readonly IProductRepositorie _IProductRepositorie;
        public ProductController(IProductRepositorie IProductRepositorie) {
            _IProductRepositorie = IProductRepositorie;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts() {
            List<Product> products = await _IProductRepositorie.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProductById(int id) {
            Product currentProduct = await _IProductRepositorie.GetById(id);
            return Ok(currentProduct);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product) {
            Product currentProduct = await _IProductRepositorie.Add(product);
            return Ok(currentProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product, int id) {
            product.id = id;
            Product currentProduct = await _IProductRepositorie.Update(product, id);
            return Ok(currentProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id) {
            bool isDeleted = await _IProductRepositorie.Delete(id);
            return Ok(isDeleted);
        }

    }
}
