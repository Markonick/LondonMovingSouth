using System.Collections.Generic;
using System.Threading.Tasks;
using LondonMovingSouth.Models;

namespace LondonMovingSouth.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}