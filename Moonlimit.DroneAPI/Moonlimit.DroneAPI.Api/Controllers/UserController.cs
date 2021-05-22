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
using System;

namespace Moonlimit.DroneAPI.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        public const string FullAccessRoles = "Administrator,Owner";
        public const string UpdateAccessRoles = "Administrator,Owner";
        private readonly UserService<UserViewModel, User> _userService;
        public UserController(UserService<UserViewModel, User> userService)
        {
            _userService = userService;
        }

        //get all
        [HttpGet]
        public IEnumerable<UserViewModel> GetAll()
        {
            var items = _userService.GetAll();
            return items;
        }
        
        //get all active by username
        [HttpGet("GetActiveByFirstName/{firstname}")]
        public IActionResult GetActiveByFirstName(string firstname)
        {
            var items = _userService.Get(a => a.IsActive && a.FirstName == firstname);
            return Ok(items);
        }

        //get one
        [HttpGet("{id}")]
        public IActionResult GetById(IdType id)
        {
            id = new IdType(22);
            var item = _userService.GetOne(id);
            if (item == null)
            {
                Log.Error("GetById({ ID}) NOT FOUND", id);
                return NotFound();
            }

            return Ok(item);
        }

        //add
        //[Authorize(Roles = FullAccessRoles)]
        [HttpPost]
        public IActionResult Create([FromBody] UserViewModel user)
        {
            if (user == null)
                return BadRequest();

            var id = _userService.Add(user);
            if (id < 0) return Unauthorized();
            return Created($"api/User/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = UpdateAccessRoles)]
        [HttpPut("{id}")]
        public IActionResult Update(Int64 id, [FromBody] UserViewModel user)
        {
            if (user == null || user.Id != id)
                return BadRequest();

            var retVal = _userService.Update(user);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(user);
        }

        [Authorize(Roles = UpdateAccessRoles)]
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] UserViewModel user)
        {
            return Update(Base32Convert.ToInt64(id),user);
        }

        //delete
        [Authorize(Roles = FullAccessRoles)]
        [HttpDelete("{id}")]
        public IActionResult Delete(Int64 id)
        {
            var retVal = _userService.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }

        [Authorize(Roles = FullAccessRoles)]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Delete(Base32Convert.ToInt64(id));
        }

        
        [Authorize]
        [HttpGet("GetUsersByName/{firstname}/{lastname}")]
        public IActionResult GetUsersByName(string firstname, string lastname)
        {
            var items = _userService.GetUsersByName(firstname, lastname);
            return Ok(items);
        }
        
        [Authorize(Roles = FullAccessRoles)]
        [HttpGet("UpdateEmailbyUsername/{username}/{email}")]
        public IActionResult UpdateEmailbyUsername(string username, string email)
        {
            int id = _userService.UpdateEmailByUsername(username, email);
            return Ok(id);
        }


    }
}


