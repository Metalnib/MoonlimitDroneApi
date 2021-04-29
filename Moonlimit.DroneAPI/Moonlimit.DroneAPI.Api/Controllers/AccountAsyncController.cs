using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moonlimit.DroneAPI.Domain;
using Moonlimit.DroneAPI.Domain.Service;
using Moonlimit.DroneAPI.Entity;
using Moonlimit.DroneAPI.Entity.Context;
using Serilog;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moonlimit.DroneAPI.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccountAsyncController : ControllerBase
    {
        private readonly CompanyAccountServiceAsync<CompanyAccountViewModel, CompanyAccount> _companyAccountServiceAsync;
        public AccountAsyncController(CompanyAccountServiceAsync<CompanyAccountViewModel, CompanyAccount> companyAccountServiceAsync)
        {
            _companyAccountServiceAsync = companyAccountServiceAsync;
        }


        //get all
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _companyAccountServiceAsync.GetAll();
            return Ok(items);
        }

        //get by predicate example
        //get all active by name
        [Authorize]
        [HttpGet("GetActiveByName/{name}")]
        public async Task<IActionResult> GetActiveByName(string name)
        {
            var items = await _companyAccountServiceAsync.Get(a => a.IsActive && a.Name == name);
            return Ok(items);
        }

        //get one
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Int64 id)
        {
            var item = await _companyAccountServiceAsync.GetOne(id);
            if (item == null)
            {
                Log.Error("GetById({ ID}) NOT FOUND", id);
                return NotFound();
            }

            return Ok(item);
        }

        [Authorize]
        [HttpGet("GetAccountWithUsers/{id}")]
        public async Task<IActionResult> GetAccountWithUsers(Int64 id)
        {
            var item = await _companyAccountServiceAsync.GetAccountWithUsers(id);
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
        public async Task<IActionResult> Create([FromBody] CompanyAccountViewModel companyAccount)
        {
            if (companyAccount == null)
                return BadRequest();

            var id = await _companyAccountServiceAsync.Add(companyAccount);
            return Created($"api/Account/{id}", id);  //HTTP201 Resource created
        }

        //update
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Int64 id, [FromBody] CompanyAccountViewModel companyAccount)
        {
            if (companyAccount == null || companyAccount.Id != id)
                return BadRequest();

            var retVal = await _companyAccountServiceAsync.Update(companyAccount);
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
        public async Task<IActionResult> Delete(Int64 id)
        {
            var retVal = await _companyAccountServiceAsync.Remove(id);
            if (retVal == 0)
                return NotFound();  //Not Found 404
            else if (retVal == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");  //Precondition Failed  - concurrency
            else
                return NoContent();   	     //No Content 204
        }
    }
}


