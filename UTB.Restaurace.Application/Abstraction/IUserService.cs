using UTB.Restaurace.Domain.Entities;
using UTB.Restaurace.Infrastructure.Identity;

namespace UTB.Restaurace.Application.Abstraction
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string userId);
        Task<IList<string>> GetRolesAsync(string userId);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(string userId);
    }
}