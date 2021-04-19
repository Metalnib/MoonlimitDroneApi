using Microsoft.AspNetCore.Identity;

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
    using Microsoft.Extensions.Options;
    

    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        public const string FullAccessRoles = "Administrator,Owner,Manager";
        public const string UpdateAccessRoles = "Administrator,Owner,Manager";
        private readonly DroneService<DroneViewModel, Drone> _droneService;
        public DroneController(DroneService<DroneViewModel, Drone> droneService)
        {
            _droneService = droneService;
            var d = User;
        }
		
	    //get all
        [Authorize]
        [HttpGet]
        public IEnumerable<DroneViewModel> GetAll()
        {
            var items = _droneService.GetAll();
            return items;
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _droneService.GetOne(id);
            if (item == null)
            {
                Log.Error("GetById({ ID}) NOT FOUND", id);
                return NotFound();
            }

            return Ok(item);
        }

        //add
        [Authorize(Roles = FullAccessRoles)]
        [HttpPost]
        public IActionResult Create([FromBody] DroneViewModel drone)
        {
            if (drone == null)
                return BadRequest();

            var id = _droneService.Add(drone);
            return Created($"api/Drone/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = UpdateAccessRoles)]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DroneViewModel drone)
        {
            if (drone == null || drone.Id != id)
                return BadRequest();

	        var retVal = _droneService.Update(drone);
            if (retVal == 0)
				return StatusCode(304);  //Not Modified
            else if (retVal == - 1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(drone);
        }

        //delete 
        [Authorize(Roles = FullAccessRoles)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
	        var retVal = _droneService.Remove(id);
	        if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }
}