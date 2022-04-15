using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
    public class DetailsController : Controller
    {
        private IInvoice_detailsCollection db = new DetailsCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllDetails()
        {
            return Ok(await db.GetAllDetails());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneDetails(string id)
        {
            return Ok(await db.GetDetailsById(id));
        }

        [HttpPost]

        public async Task<IActionResult> CreateDetail([FromBody] Invoice_details details)
        {
            if (details == null) return BadRequest();

            if (details.Id == ObjectId.Empty)
            {
                ModelState.AddModelError("Name", "The detail shouldn't be emty");
            }

            await db.InsertDetails(details);
            return Created("Create", true);

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateDetail([FromBody] Invoice_details details, string id)
        {
            if (details == null) return BadRequest();

            if (details.Id == ObjectId.Empty)
            {
                ModelState.AddModelError("Name", "The detail shouldn't be emty");
            }

            details.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateDetails(details);
            return Created("Update", true);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDetail(string id)
        {
            await db.DeleteDetails(id);

            return NoContent();
        }


    }
}

