
namespace AuthService.Repositories
{
    public interface IRoleRepository
    {
        Task<Guid> GetRoleIdByNameAsync(string name);
    }
}