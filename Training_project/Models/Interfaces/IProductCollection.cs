using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training_project.Models.Entities;

namespace Training_project.Models.Interfaces
{
    interface IProductCollection
    {
        Task InsertProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(string id);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(string id);
    }
}
