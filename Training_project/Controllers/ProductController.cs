using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training_project.Models.Entities;
using Training_project.Models.Interfaces;
using Training_project.Repositories.Collections;

namespace Training_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductCollection db = new ProductCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await db.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsDetails(string id)
        {
            return Ok(await db.GetProductById(id));
        }

        [HttpPost]

        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null) return BadRequest();

            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The product shouldn't be emty");
            }

            await db.InsertProduct(product);
            return Created("Create", true);

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateProduct([FromBody] Product product, string id)
        {
            if (product == null) return BadRequest();

            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The product shouldn't be emty");
            }

            product.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateProduct(product);
            return Created("Update", true);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await db.DeleteProduct(id);

            return NoContent();
        }


    }
}