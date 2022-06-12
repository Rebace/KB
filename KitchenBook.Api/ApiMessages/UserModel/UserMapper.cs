using KitchenBook.Api.MessageContracts.UserModel;
using KitchenBook.Domain.UserModel;

namespace KitchenBook.Api.ApiMessages.UserModel;

public static class UserMapper
{
    public static UserDto Map(this User user)
    {
        return new UserDto()
        {
            Name = user.Name,
            Login = user.Login,
            Password = user.Password,
            Description = user.Description,
            Id = user.Id,
            Token = user.Token
        };
    }
}
