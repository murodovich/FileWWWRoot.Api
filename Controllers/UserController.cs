using FileWwwroot.Api.Dtos;
using FileWwwroot.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileWwwroot.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromForm] UserDto userModel)
        {
            await _userService.CreateAsync(userModel);
            return Ok("Created");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int Id)
        {
            UserResDto user = await _userService.GetByIdAsync(Id);

            return Ok(new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
            });
        }

        [HttpGet]
        public async ValueTask<FileContentResult> GetImageByUserIdAsync(int UserId)
        {
            UserResDto user = await _userService.GetByIdAsync(UserId);

            return File(user.ImageBytes, "image/png");
        }
    }
}
