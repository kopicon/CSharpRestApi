using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicListBLL;
using MusicListBLL.BusinessObjects;

namespace MusicRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        BLLFacade bLLFacade = new BLLFacade();
        // GET api/values
        [HttpGet]
        public IEnumerable<MusicBO> Get()
        {
            return bLLFacade.MusicService.GetAllMusic();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public MusicBO Get(int id)
        {
            return bLLFacade.MusicService.GetMusic(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]MusicBO music)
        {
            bLLFacade.MusicService.Add(music); 
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
