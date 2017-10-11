using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicListBLL;
using MusicListBLL.BusinessObjects;

namespace MusicRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Musics")]
    public class MusicsController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/Musics
        [HttpGet]
        public IEnumerable<MusicBO> GetAll()
        {
            return facade.MusicService.GetAllMusic();
        }

        // GET: api/Musics/5
        [HttpGet("{id}")]
        public MusicBO Get(int id)
        {
            return facade.MusicService.GetMusic(id);
        }
        
        // POST: api/Musics
        [HttpPost]
        public IActionResult Post([FromBody]MusicBO Music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.MusicService.Add(Music));
        }
        
        // PUT: api/Musics/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]MusicBO Music)
        {
            if (id != Music.Id)
            {
                return BadRequest("Path Id does not exists");
            }
            try
            {
                return Ok(facade.MusicService.Edit(Music));
            }
            catch (InvalidOperationException e)
            {

                return StatusCode(404, e.Message);
            }
                      
        }
        
        // DELETE: api/Musics/6
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.MusicService.Delete(id);
        }
    }
}
