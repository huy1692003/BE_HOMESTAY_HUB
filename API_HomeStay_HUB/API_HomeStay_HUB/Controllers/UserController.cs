using API_HomeStay_HUB.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DBContext dbContext;
        public UserController(DBContext db)
        {
            dbContext = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsersWithCustomers()
        {
            var usersWithCustomers = await dbContext.Users.ToListAsync();

            return Ok(usersWithCustomers);
        }
        [HttpGet("getCustomer")]
        public async Task<IActionResult> GetAllUCustomer()
        {
            var usersWithCustomers = await dbContext.Customers.ToListAsync();

            return Ok(usersWithCustomers);
        }
        [HttpGet("getOwnerStay")]
        public async Task<IActionResult> GetOwnerStay()
        {
            var usersWithCustomers = await dbContext.OwnerStays.ToListAsync();

            return Ok(usersWithCustomers);
        }
        [HttpGet("getAdminstrator")]
        public async Task<IActionResult> GetAdminStator()
        {
            var usersWithCustomers = await dbContext.Administrators.ToListAsync();

            return Ok(usersWithCustomers);
        }
    }
}
