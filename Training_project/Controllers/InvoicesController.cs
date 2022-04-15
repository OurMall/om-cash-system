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
    public class InvoicesController : Controller
    {
        private IInvoiceCollection db = new InvoiceCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            return Ok(await db.GetAllInvoices());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneInvoices(string id)
        {
            return Ok(await db.GetInvoiceById(id));
        }

        [HttpPost]

        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {

            if (invoice == null) return BadRequest();

            if (invoice.Id == ObjectId.Empty)
            {
                ModelState.AddModelError("Name", "The invoice shouldn't be emty");
            }

            await db.InsertInvoice(invoice);
            return Created("Create", true);

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateInvoice([FromBody] Invoice invoice, string id)
        {
            if (invoice == null) return BadRequest();

            if (invoice.Id == ObjectId.Empty)
            {
                ModelState.AddModelError("Name", "The invoice shouldn't be emty");
            }

            invoice.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateInvoice(invoice);
            return Created("Update", true);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteInvoice(string id)
        {
            await db.DeleteInvoice(id);

            return NoContent();
        }
    }
}
