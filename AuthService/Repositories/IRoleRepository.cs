
using AuthService.Entities;

namespace AuthService.Repositories
{
    public interface IRoleRepository
    {
        Task<Guid> GetRoleIdByNameAsync(string name);
        Task<Role> GetRoleByIdAsync(Guid roleId);
    }
}