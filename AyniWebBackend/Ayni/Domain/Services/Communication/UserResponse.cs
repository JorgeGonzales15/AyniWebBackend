using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Shared.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Domain.Services.Communication;

public class UserResponse : BaseResponse<User>
{
    public UserResponse(string message) : base(message)
    {
    }

    public UserResponse(User resource) : base(resource)
    {
    }
}