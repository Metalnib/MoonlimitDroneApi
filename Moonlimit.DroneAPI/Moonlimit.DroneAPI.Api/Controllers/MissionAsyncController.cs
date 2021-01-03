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
    public class MissionAsyncController : ControllerBase
    {
        private readonly MissionServiceAsync<MissionViewModel, Mission> _missionServiceAsync;
        public MissionAsyncController(MissionServiceAsync<MissionViewModel, Mission> missionServiceAsync)
        {
            _missionServiceAsync = missionServiceAsync;
        }

        //get all
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _missionServiceAsync.GetAll();
            return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _missionServiceAsync.GetOne(id);
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
        public async Task<IActionResult> Create([FromBody] MissionViewModel mission)
        {
            if (mission == null)
                return BadRequest();

            var id = await _missionServiceAsync.Add(mission);
            return Created($"api/Mission/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MissionViewModel mission)
        {
            if (mission == null || mission.Id != id)
                return BadRequest();

	        var retVal = await _missionServiceAsync.Update(mission);
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
        public async Task<IActionResult> Delete(int id)
        {
	        var retVal = await _missionServiceAsync.Remove(id);
	        if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }
    }
}