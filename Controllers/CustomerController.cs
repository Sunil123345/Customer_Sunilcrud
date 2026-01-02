using CustomerReactiveForms.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerReactiveForms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly Customercontext _context;
        public CustomerController(Customercontext context)
        {
            _context = context;
        }
        [HttpGet("countries")]
        public async Task<IActionResult> Getcountries()
        {
            var countries = await _context.Countries.ToListAsync();
            return Ok(countries);
        }
        [HttpGet("states/{cid}")]
        public async Task<IActionResult> GetStates(int cid)
        {
            var states = await _context.States.Where(s => s.cid == cid).ToListAsync();
            return Ok(states);
        }
        [HttpGet("cities/{stid}")]
        public async Task<IActionResult> GetCities(int stid)
        {
            var cities = await _context.Cities.Where(c => c.stid == stid).ToListAsync();
            return Ok(cities);
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var data = await (
                from cust in _context.Customers
                join c in _context.Countries on cust.cid equals c.cid
                join s in _context.States on cust.stid equals s.stid
                join ct in _context.Cities on cust.cityid equals ct.cityid
                select new
                {
                    cust.custid,
                    cust.custname,
                    cust.Email,
                    cust.Gender,
                    cust.Address,
                    cname = c.cname,
                    stname = s.stname,
                    cityname = ct.cityname
                }
            ).ToListAsync();

            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if(customer==null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(new {message="Customer Created Successfully" });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            var existingCustomer=await _context.Customers.FindAsync(id);
            if(existingCustomer==null)
            {
                return NotFound();
            }
            existingCustomer.custname = customer.custname;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Gender = customer.Gender;
            existingCustomer.Address = customer.Address;
            await _context.SaveChangesAsync();
            return Ok(new {message="Customer Updated Successfully" });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var existingCustomer=await _context.Customers.FindAsync(id);
            if(existingCustomer==null)
            {
                return NotFound();
            }
            _context.Customers.Remove(existingCustomer);
            await _context.SaveChangesAsync();
            return Ok(new {message="Customer Deleted Successfully" });
        }
    }
}
