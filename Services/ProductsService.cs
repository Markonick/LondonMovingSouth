using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LondonMovingSouth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LondonMovingSouth.Services
{
    public class ProductsService : IProductsService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly ILogger _logger;

        public ProductsService(HttpClient client, string baseUrl, ILogger logger)
        {
            _client = client;
            _baseUrl = baseUrl;
            _logger = logger;
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            IEnumerable<Product> products = new List<Product>();
            try
            {
                using (var response = await _client.GetAsync(_baseUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var resp = response.Content.ReadAsStringAsync().Result;

                        products = JsonConvert.DeserializeObject<IEnumerable<Product>>(resp);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return products;
        }
    }
}
