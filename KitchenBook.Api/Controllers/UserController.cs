using KitchenBook.Api.ApiMessages.UserModel;
using KitchenBook.Api.MessageContracts.AuthenticationResponseModel;
using KitchenBook.Api.MessageContracts.UserModel;
using KitchenBook.Domain.AuthenticateModel;
using KitchenBook.Domain.UserModel;
using KitchenBook.Infrastructure.Data.UserModel;
using KitchenBook.Infrastructure.UoF;
using Microsoft.AspNetCore.Mvc;

namespace KitchenBook.Api.Controllers;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [Route("authenticate")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model)
    {
        User user = await _userRepository.Authenticate(model);

        if (user == null)
        {
            return BadRequest();
        }


        string token = Guid.NewGuid().ToString();
        user.Token = token;
        _userRepository.Update(user);
        _unitOfWork.Commit();

        var response = new AuthenticationResponseDto(token, user.Name);

        return Ok(response);
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        var createdUser =
            await _userRepository.Register(new User(userDto.Name, userDto.Login, Hashing.ToSHA256(userDto.Password), null, null));
        _unitOfWork.Commit();

        return Ok(createdUser.Map());
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<IActionResult> GetById(int userId)
    {
        User user = await _userRepository.GetById(userId);
        return Ok(user.Map());
    }

    [HttpPost]
    [Route("update")]
    public IActionResult Update([FromBody] UserDto userDto)
    {
        _userRepository.Update(new User(userDto.Name, userDto.Login, Hashing.ToSHA256(userDto.Password), userDto.Description,
            userDto.Token));
        _unitOfWork.Commit();

        return Ok();
    }
}
