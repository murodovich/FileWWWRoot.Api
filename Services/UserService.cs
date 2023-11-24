using FileWwwroot.Api.Data;
using FileWwwroot.Api.Dtos;
using FileWwwroot.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileWwwroot.Api.Services
{
    public class UserService : IUserService
    {
        private readonly FileImageDBContext _dbContext;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _environment;

        public UserService(FileImageDBContext dbContext, IFileService fileService , IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _fileService = fileService;
            _environment = environment;
        }

        public async ValueTask<int> CreateAsync(UserDto userDto)
        {
            User user = new User();
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.ImageUrl = await _fileService.CreateFileAsync(userDto.ImageUrl);

            await _dbContext.Users.AddAsync(user);
            var result = await _dbContext.SaveChangesAsync();
            return result;
                       
        }

        public async  ValueTask<IEnumerable<UserResDto>> GetAllAsync()
        {
            IEnumerable<User> users = await _dbContext.Users.ToListAsync();

            List<UserResDto> userResponse = new List<UserResDto>();

            foreach (var i in users)
            {
                if (i != null)
                {
                    userResponse.Add(new UserResDto()
                    {
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        ImageBytes = File.ReadAllBytes($@"{_environment.WebRootPath}{i.ImageUrl}")
                    });
                }
            }

            return userResponse;

        }

        public async ValueTask<UserResDto> GetByIdAsync(int Id)
        {
            User? user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == Id);

            if (user != null)
            {
                UserResDto userResponse = new UserResDto();
                userResponse.FirstName = user.FirstName;
                userResponse.LastName = user.LastName;
                userResponse.ImageBytes = File.ReadAllBytes($@"{_environment.WebRootPath}{user.ImageUrl}");

                return userResponse;
            }
            

            if (user != null)
            {
                UserResDto userResponse = new UserResDto();
                userResponse.FirstName = user.FirstName;
                userResponse.LastName = user.LastName;
                userResponse.ImageBytes = File.ReadAllBytes($@"{_environment.WebRootPath}{user.ImageUrl}");

                return userResponse;
            }
            return new UserResDto();

        }
    }
}
