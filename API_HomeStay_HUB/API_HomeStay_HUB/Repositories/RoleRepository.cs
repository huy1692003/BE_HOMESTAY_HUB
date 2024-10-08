using API_HomeStay_HUB.Data;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_HomeStay_HUB.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DBContext _context;

        public RoleRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRole()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleById(string roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }

        public async Task<bool> AddRole(Role role)
        {
            role.RoleID = Guid.NewGuid().ToString(); // Tạo ID ngẫu nhiên cho vai trò
            await _context.Roles.AddAsync(role);
            return await _context.SaveChangesAsync() > 0; // Trả về true nếu thêm thành công
        }

        public async Task<bool> UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            return await _context.SaveChangesAsync() > 0; // Trả về true nếu cập nhật thành công
        }

        public async Task<bool> DeleteRole(string roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role != null)
            {
                _context.Roles.Remove(role);
                return await _context.SaveChangesAsync() > 0; // Trả về true nếu xóa thành công
            }
            return false; // Vai trò không tồn tại
        }
    }
}
