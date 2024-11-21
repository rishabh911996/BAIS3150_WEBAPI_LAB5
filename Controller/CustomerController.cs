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

        // GET api/<CustomerController>/IsPrime/{number}
        [HttpGet("IsPrime/{number}")]
        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // GET api/<CustomerController>/BinaryToDecimal/{binary}
        [HttpGet("BinaryToDecimal/{binary}")]
        public int BinaryToDecimal(string binary)
        {
            int decimalValue = 0;
            int baseValue = 1;

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                if (binary[i] == '1')
                {
                    decimalValue += baseValue;
                }
                baseValue *= 2;
            }

            return decimalValue;
        }

        // GET api/<CustomerController>/DecimalToBinary/{decimalNumber}
        [HttpGet("DecimalToBinary/{decimalNumber}")]
        public string DecimalToBinary(int decimalNumber)
        {
            if (decimalNumber == 0) return "0";

            string binary = string.Empty;
            while (decimalNumber > 0)
            {
                binary = (decimalNumber % 2) + binary;
                decimalNumber /= 2;
            }

            return binary;
        }

        //// POST api/<CustomerController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CustomerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CustomerController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
