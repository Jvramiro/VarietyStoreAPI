using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VarietyStoreFront.Models;

namespace VarietyStoreFront.Controllers {
    public class ProductController : Controller {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger) {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product) {
            HttpClient client = new HttpClient();
            string apiUrl = $"https://localhost:44314/api/product/{product.id}";
            string json = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try {
                HttpResponseMessage response = await client.PutAsync(apiUrl, content);
                if (response.IsSuccessStatusCode) {
                    return RedirectToAction("AdmProducts", "Home");
                }
                else {
                    string errorMsg = $"Erro ao atualizar o produto. Código de status: {response.StatusCode}";
                    _logger.LogError(errorMsg);
                    return View("Error", new ErrorViewModel { Message = errorMsg });
                }
            }
            catch (Exception ex) {
                _logger.LogError($"Erro ao chamar API: {ex.Message}");
                return View("Error", new ErrorViewModel { Message = $"Erro ao atualizar o produto: {ex.Message}" });
            }
        }
    }
}
