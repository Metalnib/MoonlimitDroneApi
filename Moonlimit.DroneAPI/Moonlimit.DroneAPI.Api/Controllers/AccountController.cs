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
using System.Security.Claims;

namespace Moonlimit.DroneAPI.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly CompanyAccountService<CompanyAccountViewModel, CompanyAccount> _companyAccountService;
        public AccountController(CompanyAccountService<CompanyAccountViewModel, CompanyAccount> companyAccountService)
        {
            _companyAccountService = companyAccountService;
        }

        //get all
        [Authorize]
        [HttpGet]
        public IEnumerable<CompanyAccountViewModel> GetAll()
        {
            var items = _companyAccountService.GetAll();
            return items;
        }

        //get by predicate example
        //get all active by name
        [Authorize]
        [HttpGet("GetActiveByName/{name}")]
        public IActionResult GetActiveByName(string name)
        {
            var items = _companyAccountService.Get(a => a.IsActive && a.Name == name);
            return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _companyAccountService.GetOne(id);
            if (item == null)
            {
                Log.Error("GetById({ ID}) NOT FOUND", id);
                return NotFound();
            }

            return Ok(item);
        }

        [Authorize]
        [HttpGet("GetAccountWithUsers/{id}")]
        public IActionResult GetAccountWithUsers(int id)
        {
            var item = _companyAccountService.GetAccountWithUsers(id);
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
        public IActionResult Create([FromBody] CompanyAccountViewModel companyAccount)
        {
            if (companyAccount == null)
                return BadRequest();

            var id = _companyAccountService.Add(companyAccount);
            return Created($"api/Account/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CompanyAccountViewModel companyAccount)
        {
            if (companyAccount == null || companyAccount.Id != id)
                return BadRequest();

            int retVal = _companyAccountService.Update(companyAccount);
            if (retVal == 0)
                return StatusCode(304);  //Not Modified
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //412 Precondition Failed  - concurrency
            else
                return Accepted(companyAccount);
        }

        //delete 
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int retVal = _companyAccountService.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }
    }
}


