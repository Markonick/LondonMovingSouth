using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LondonMovingSouth.Models;
using LondonMovingSouth.Services;
using Microsoft.AspNetCore.Mvc;

namespace LondonMovingSouth.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Product>> Products()
        {
            return await _service.GetProductsAsync();
        }
    }
}
