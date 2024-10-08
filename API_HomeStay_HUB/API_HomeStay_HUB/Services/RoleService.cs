using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Intefaces;
using API_HomeStay_HUB.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace API_HomeStay_HUB.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> GetAllRole()
        {
            return await _roleRepository.GetAllRole();
        }

        public async Task<Role?> GetRoleById(string roleId)
        {
            return await _roleRepository.GetRoleById(roleId);
        }

        public async Task<bool> AddRole(Role role)
        {
            return await _roleRepository.AddRole(role);
        }

        public async Task<bool> UpdateRole(Role role)
        {
            return await _roleRepository.UpdateRole(role);
        }

        public async Task<bool> DeleteRole(string roleId)
        {
            return await _roleRepository.DeleteRole(roleId);
        }

    }
}
