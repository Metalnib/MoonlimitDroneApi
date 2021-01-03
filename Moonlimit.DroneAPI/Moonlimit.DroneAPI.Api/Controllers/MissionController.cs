namespace Moonlimit.DroneAPI.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Moonlimit.DroneAPI.Domain;
    using Moonlimit.DroneAPI.Entity.Context;
    using Moonlimit.DroneAPI.Domain.Service;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;
    using Serilog;
    using Moonlimit.DroneAPI.Entity;
    using Moonlimit.DroneAPI.Entity.DroneCom;
    
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly MissionService<MissionViewModel, Mission> _missionService;
        public MissionController(MissionService<MissionViewModel, Mission> missionService)
        {
            _missionService = missionService;
        }
		
	    //get all
        [Authorize]
        [HttpGet]
        public IEnumerable<MissionViewModel> GetAll()
        {
            var items = _missionService.GetAll();
            return items;
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _missionService.GetOne(id);
            if (item == null)
            {
                Log.Error("GetById({ ID}) NOT FOUND", id);
                return NotFound();
            }

            return Ok(item);
        }

        //add
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Create([FromBody] MissionViewModel mission)
        {
            if (mission == null)
                return BadRequest();

            var id = _missionService.Add(mission);
            return Created($"api/Mission/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MissionViewModel mission)
        {
            if (mission == null || mission.Id != id)
                return BadRequest();

	        var retVal = _missionService.Update(mission);
            if (retVal == 0)
				return StatusCode(304);  //Not Modified
            else if (retVal == - 1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(mission);
        }

        //delete 
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
	        var retVal = _missionService.Remove(id);
	        if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

        [Authorize]
        [HttpGet("GetUsersByName/{userId}")]
        public IActionResult GetMissionsForUserId(int userId)
        {
            var item = _missionService.GetOne(userId);
            if (item == null)
            {
                Log.Error("GetById({ ID}) NOT FOUND", userId);
                return NotFound();
            }

            return Ok(item);
        }
    }
}