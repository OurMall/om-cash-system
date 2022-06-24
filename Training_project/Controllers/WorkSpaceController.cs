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
    public class WorkSpaceController : Controller
    {
        private IWorkSpaceCollection db = new WorkSpaceCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllWorkSpaces()
        {
            return Ok(await db.GetAllWorkSpaces());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkSpacesDetails(string id)
        {
            return Ok(await db.GetWorkSpaceById(id));
        }

        [HttpPost]

        public async Task<IActionResult> CreateWorkSpace([FromBody] WorkSpace workSpace)
        {
            if (workSpace == null) return BadRequest();

            if (workSpace.Id_categorie == string.Empty)
            {
                ModelState.AddModelError("Name", "The product shouldn't be emty");
            }

            await db.InsertWorkSpace(workSpace);
            return Created("Create", true);

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateWorkSpace([FromBody] WorkSpace workSpace, string id)
        {
            if (workSpace == null) return BadRequest();

            if (workSpace.Id_categorie == string.Empty)
            {
                ModelState.AddModelError("Name", "The product shouldn't be emty");
            }

            workSpace.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateWorkSpace(workSpace);
            return Created("Update", true);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteWorkSpace(string id)
        {
            await db.DeleteWorkSpace(id);

            return NoContent();
        }


    }
}
