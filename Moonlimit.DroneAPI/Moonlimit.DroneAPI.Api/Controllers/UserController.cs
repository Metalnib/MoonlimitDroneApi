using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moonlimit.DroneAPI.Domain;
using Moonlimit.DroneAPI.Domain.Service;
using Moonlimit.DroneAPI.Entity;
using Moonlimit.DroneAPI.Entity.Context;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace Moonlimit.DroneAPI.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService<UserViewModel, User> _userService;
        public UserController(UserService<UserViewModel, User> userService)
        {
            _userService = userService;
        }

        //get all
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<UserViewModel> GetAll()
        {
            var items = _userService.GetAll();
            return items;
        }
        
        //get all active by username
        [Authorize]
        [HttpGet("GetActiveByFirstName/{firstname}")]
        public IActionResult GetActiveByFirstName(string firstname)
        {
            var items = _userService.Get(a => a.IsActive && a.FirstName == firstname);
            return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _userService.GetOne(id);
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
        public IActionResult Create([FromBody] UserViewModel user)
        {
            if (user == null)
                return BadRequest();

            var id = _userService.Add(user);
            return Created($"api/User/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserViewModel user)
        {
            if (user == null || user.Id != id)
                return BadRequest();

            int retVal = _userService.Update(user);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(user);
        }

        //delete
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int retVal = _userService.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

        
        [Authorize]
        [HttpGet("GetUsersByName/{firstname}/{lastname}")]
        public IActionResult GetUsersByName(string firstname, string lastname)
        {
            var items = _userService.GetUsersByName(firstname, lastname);
            return Ok(items);
        }
        
        [Authorize]
        [HttpGet("UpdateEmailbyUsername/{username}/{email}")]
        public IActionResult UpdateEmailbyUsername(string username, string email)
        {
            int id = _userService.UpdateEmailByUsername(username, email);
            return Ok(id);
        }


    }
}


