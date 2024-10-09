using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_HomeStay_HUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/role/getAll
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRole()
        {
            var roles = await _roleService.GetAllRole();
            return Ok(roles);
        }

        // GET: api/role/getByID/{roleId}
        [HttpGet("getByID/{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            var role = await _roleService.GetRoleById(id);
            return role != null ? Ok(role) : NotFound();
        }

        // POST: api/role/create
        [HttpPost("create")]
        public async Task<IActionResult> AddRole([FromBody] Role role)
        {
            if (role == null)
            {
                return BadRequest("Không được để trống Role");
            }

            bool state = await _roleService.AddRole(role);
            return state ? CreatedAtAction(nameof(GetRoleById), new { roleId = role.RoleID }, role) : BadRequest("Dữ liệu Role không hợp lệ");
        }

        // PUT: api/role/update
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRole([FromBody] Role role)
        {
            if (role == null || string.IsNullOrEmpty(role.RoleID))
            {
                return BadRequest("Role không được để trống");
            }

            bool state = await _roleService.UpdateRole(role);
            return state ? NoContent() : BadRequest("Dữ liệu Role không hợp lệ");
        }

        // DELETE: api/role/delete/{roleId}
        [HttpDelete("delete/{roleId}")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            bool state = await _roleService.DeleteRole(roleId);
            return state ? NoContent() : NotFound();
        }
    }
}
