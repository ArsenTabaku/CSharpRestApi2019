using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        //get access to CustomerAppBLL by creating an object
        BLLFacade facade = new BLLFacade();

               
        // GET: api/orders
        [HttpGet]
        public IEnumerable<OrderBO> Get()
        {
            return facade.OrderService.GetAll();
        }
                
        
        // GET: api/orders/5
        [HttpGet("{id}")]
        public OrderBO Get(int Id)
        {
            return facade.OrderService.Get(Id);
        }


        // POST: api/orders
        [HttpPost]
        public IActionResult Post([FromBody] OrderBO order)
        {
            /*FIRST WAY
             * if (!TryValidateModel(order))
            {
                return BadRequest("Object not valid!");
            }
            */

            //SECOND WAY
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(facade.OrderService.Create(order));
        }



        // PUT: api/orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderBO order)
        {
            if (id != order.Id)
            {
                //return BadRequest("Path ID does not match Customer ID in json object");
                return StatusCode(405, "Path ID does not match Customer ID in json object");
            }
            try
            {
                var orderUpdated = facade.OrderService.Update(order);
                return Ok(orderUpdated);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }



        // DELETE api/orders/5
                [HttpDelete("{id}")]
        public void Delete(int id)
        {
             facade.OrderService.Delete(id);
        }
    }
}
