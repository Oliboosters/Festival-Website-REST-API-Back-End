using ArtistLibrary;
using EksamensProjekt3.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EksamensProjekt3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IManageArtists manager;

        /*
        public ArtistController(DatabaseContext context)
        {
            manager = new ArtistManager(context);
        }
        */

        public ArtistController()
        {
            manager = new ArtistManager();
        }

        // GET: api/<ArtistController>
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return manager.Get();
        }

        // GET api/<ArtistController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(manager.Get(id));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
            //return manager.Get(id);


        }

        // POST api/<ArtistController>
        [HttpPost]
        public bool Post([FromBody] Artist value)
        {
            return manager.Create(value);
        }

        // PUT api/<ArtistController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Artist value)
        {
            return manager.Update(id, value);
        }

        // DELETE api/<ArtistController>/5
        [HttpDelete("{id}")]
        public Artist Delete(int id)
        {
            return manager.Delete(id);
        }
    }
}
