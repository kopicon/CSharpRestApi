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
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/Orders
        [HttpGet]
        public IEnumerable<OrderBO> GetAll()
        {
            return facade.OrderService.GetAll();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public OrderBO Get(int id)
        {
            return facade.OrderService.Get(id);
        }
        
        // POST: api/Orders
        [HttpPost]
        public IActionResult Post([FromBody]OrderBO order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.OrderService.Add(order));
        }
        
        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderBO order)
        {
            if (id != order.Id)
            {
                return BadRequest("Path Id does not exists");
            }
            try
            {
                return Ok(facade.OrderService.Edit(order));
            }
            catch (InvalidOperationException e)
            {

                return StatusCode(404, e.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.OrderService.Delete(id);
        }
    }
}
