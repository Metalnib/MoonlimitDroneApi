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
    public class DroneAsyncController : ControllerBase
    {
        private readonly DroneServiceAsync<DroneViewModel, Drone> _droneServiceAsync;
        public DroneAsyncController(DroneServiceAsync<DroneViewModel, Drone> droneServiceAsync)
        {
            _droneServiceAsync = droneServiceAsync;
        }


        //get all
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _droneServiceAsync.GetAll();
            return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _droneServiceAsync.GetOne(id);
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
        public async Task<IActionResult> Create([FromBody] DroneViewModel drone)
        {
            if (drone == null)
                return BadRequest();

            var id = await _droneServiceAsync.Add(drone);
            return Created($"api/Drone/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DroneViewModel drone)
        {
            if (drone == null || drone.Id != id)
                return BadRequest();

	        var retVal = await _droneServiceAsync.Update(drone);
            if (retVal == 0)
				return StatusCode(304);  //Not Modified
            else if (retVal == - 1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(drone);
        }


        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
	        var retVal = await _droneServiceAsync.Remove(id);
	        if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }
    }
}