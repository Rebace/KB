namespace KitchenBook.Api.MessageContracts.AuthenticationResponseModel;

public class AuthenticationResponseDto
{
    public AuthenticationResponseDto(string token, string responseName)
    {
        AccesToken = token;
        UserName = responseName;
    }

    public string AccesToken { get; private set; }
    public string UserName { get; private set; }
}
