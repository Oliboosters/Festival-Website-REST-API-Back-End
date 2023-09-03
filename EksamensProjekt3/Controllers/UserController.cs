using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EksamensProjekt3;
using EksamensProjekt3.Controllers;
using EksamensProjekt3.Managers;
using RestService;
using Microsoft.AspNetCore.Http;

namespace RestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};
        private readonly IManageUsers mgr;

        public UserController(DatabaseContext context)
        {
            mgr = new ManageUsers(context);
        }



        [HttpGet]
        public IEnumerable<User> Get()
        {
            return mgr.GetAll();
        }
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(mgr.Get(id));
            }
            catch (KeyNotFoundException msg)
            {
                return NotFound(msg.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            try
            {
                return Ok(mgr.Create(value));
            }
            catch (ArgumentException msg)
            {
                return NotFound(msg.Message);
            }
}
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody] User value)
        {
            try
            {
                return Ok(mgr.Update(id, value));
            }
            catch (KeyNotFoundException msg)
            {
                return NotFound(msg.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public User Delete(int id)
        {
            return mgr.Delete(id);
        }
    }
}
