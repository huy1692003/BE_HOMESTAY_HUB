using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRole();
        Task<Role?> GetRoleById(string roleId);
        Task<bool> AddRole(Role role);
        Task<bool> UpdateRole(Role role);
        Task<bool> DeleteRole(string roleId);
    }
}
