using Microsoft.AspNetCore.Mvc;
using BAIS3150_WEBAPI_LAB5.Domain;
using BAIS3150_WEBAPI_LAB5.TechnicalServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAIS3150_WEBAPI_LAB5.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public List<customers> Get()
        {
            customerOperation CustomerOperationManager = new customerOperation();
            List<customers> customers = CustomerOperationManager.GetCustomers();
            return customers;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public customers Get(string customerId)
        {
            customerOperation CustomerManager = new customerOperation();
            customers customer = CustomerManager.GetCustomerByID(customerId);
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
