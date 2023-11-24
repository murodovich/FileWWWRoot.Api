using FileWwwroot.Api.Dtos;

namespace FileWwwroot.Api.Services
{
    public interface IUserService
    {
        public ValueTask<int> CreateAsync(UserDto userDto);
        public ValueTask<UserResDto> GetByIdAsync(int UserId);
        public ValueTask<IEnumerable<UserResDto>> GetAllAsync();
    }
}
