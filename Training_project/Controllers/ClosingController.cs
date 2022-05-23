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
    public class ClosingController : Controller
    {
        private IClosingCollection db = new ClosingCollection();

        [HttpGet]

        public async Task<IActionResult> GetAllDetails()
        {
            return Ok(await db.GetAllClosing());
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetOneDetails(DateTime date)
        {
            return Ok(await db.GetClosingByDate(date));
        }

        [HttpPost]

        public async Task<IActionResult> CreateDetail([FromBody] Closing closing)
        {
            if (closing == null) return BadRequest();

            if (closing.Id == ObjectId.Empty)
            {
                ModelState.AddModelError("Name", "The closing shouldn't be emty");
            }

            await db.InsertClosing(closing);
            return Created("Create", true);

        }
    }
}
