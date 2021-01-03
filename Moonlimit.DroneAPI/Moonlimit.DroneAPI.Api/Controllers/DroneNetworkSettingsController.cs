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
    public class DroneNetworkSettingsController : ControllerBase
    {
        private readonly DroneNetworkSettingsService<DroneNetworkSettingsViewModel, DroneNetworkSettings> _dronenetworksettingsService;
        public DroneNetworkSettingsController(DroneNetworkSettingsService<DroneNetworkSettingsViewModel, DroneNetworkSettings> dronenetworksettingsService)
        {
            _dronenetworksettingsService = dronenetworksettingsService;
        }
		
	    //get all
        [Authorize]
        [HttpGet]
        public IEnumerable<DroneNetworkSettingsViewModel> GetAll()
        {
            var items = _dronenetworksettingsService.GetAll();
            return items;
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _dronenetworksettingsService.GetOne(id);
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
        public IActionResult Create([FromBody] DroneNetworkSettingsViewModel dronenetworksettings)
        {
            if (dronenetworksettings == null)
                return BadRequest();

            var id = _dronenetworksettingsService.Add(dronenetworksettings);
            return Created($"api/DroneNetworkSettings/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DroneNetworkSettingsViewModel dronenetworksettings)
        {
            if (dronenetworksettings == null || dronenetworksettings.Id != id)
                return BadRequest();

	        var retVal = _dronenetworksettingsService.Update(dronenetworksettings);
            if (retVal == 0)
				return StatusCode(304);  //Not Modified
            else if (retVal == - 1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(dronenetworksettings);
        }

        //delete 
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
	        var retVal = _dronenetworksettingsService.Remove(id);
	        if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

    }
}