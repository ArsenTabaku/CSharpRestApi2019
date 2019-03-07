using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //get access to CustomerAppBLL by creating an object
        BLLFacade facade = new BLLFacade();

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<CustomerBO> Get()
        {
            return facade.CustomerService.GetAll();
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        public CustomerBO Get(int id)
        {
            return facade.CustomerService.Get(id);
        }

        // POST: api/Customers
        [HttpPost]
        public IActionResult Post([FromBody] CustomerBO cust)
        {
            if(!TryValidateModel(cust))
            {
                return BadRequest("Object not valid!");
            }

            /*SECOND WAY
               if(!ModelState.IsValid)
               {
                    return BadRequest(ModelState);
               }
               return BadRequest(ModelState);
             */


            return Ok(facade.CustomerService.Create(cust));
        }




        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerBO cust)
        {
            if(id != cust.Id)
            {
                //return BadRequest("Path ID does not match Customer ID in json object");
                return StatusCode(405, "Path ID does not match Customer ID in json object");
            }
            try
            {
                var customer = facade.CustomerService.Update(cust);
                return Ok(customer);
            }
            catch(InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.CustomerService.Delete(id);
        }
    }
}
