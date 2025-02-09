using AuthService.Data;
using AuthService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repositories
{
    public class RoleRepository(IDataContext dataContext) : IRoleRepository
    {
        public async Task<Guid> GetRoleIdByNameAsync(string name)
        {
            var role = await dataContext.Roles.FirstOrDefaultAsync(x => x.Name == name);
            return role?.Id ?? throw new Exception($"Role '{name}' not found");
        }

        public async Task<Role> GetRoleByIdAsync(Guid roleId)
        {
            var role = await dataContext.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
            return role;
        }
    }
}
