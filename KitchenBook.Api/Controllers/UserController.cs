using KitchenBook.Api.MessageContracts;
using KitchenBook.Api.MessageContracts.UserModel;
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
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto loiginDto)
    {
        User user = await _userRepository.GetByLogin(loiginDto.Login);

        if (Hashing.ToSHA256(loiginDto.Password) != user.Password)
        {
            return BadRequest();
        }

        string token = Guid.NewGuid().ToString();
        user.Token = token;

        _userRepository.Update(user);
        _unitOfWork.Commit();

        HttpContext.Response.Cookies.Append("Token", token);
        return Ok();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(LoginDto loiginDto)
    {
        if (await _userRepository.GetByLogin(loiginDto.Login) != null)
        {
            return BadRequest();
        }

            string token = Guid.NewGuid().ToString();

        HttpContext.Response.Cookies.Append("Token", token);

        var createdUser =
            await _userRepository.Add(new User(
                loiginDto.Name,
                loiginDto.Login,
                Hashing.ToSHA256(loiginDto.Password),
                null,
                token));
        _unitOfWork.Commit();

        return Ok();
    }

    [HttpPost]
    [Route("update")]
    public IActionResult Update([FromBody] UserDto userDto)
    {
        string login = HttpContext.Request.Cookies["Login"];

        if (login != userDto.Login)
        {
            return BadRequest();
        }

        _userRepository.Update(new User(
            userDto.Name,
            userDto.Login,
            Hashing.ToSHA256(userDto.Password),
            userDto.Description,
            userDto.Token));

        _unitOfWork.Commit();

        return Ok();
    }
}
