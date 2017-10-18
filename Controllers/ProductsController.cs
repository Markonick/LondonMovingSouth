using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LondonMovingSouth.Models;
using Microsoft.AspNetCore.Mvc;

namespace LondonMovingSouth.Controllers
{
    [Route("api/[controller]")]
    public partial class ProductsController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<Product> Products()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                Name = "prudct"+rng.ToString(),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Price = decimal.Parse(rng.ToString())
            });
        }
    }
}
