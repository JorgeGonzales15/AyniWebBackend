using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<UserResponse> SaveAsync(User user);
    Task<UserResponse> UpdateAsync(int id, User user);
    Task<UserResponse> DeleteAsync(int id);

}