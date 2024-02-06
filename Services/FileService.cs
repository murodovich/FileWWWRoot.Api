using FileWwwroot.Api.Data;
namespace FileWwwroot.Api.Services
{
    public class FileService : IFileService
    {
        private readonly FileImageDBContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment, FileImageDBContext dbContext)
        {
            _environment = environment;
            _dbContext = dbContext;
        }

        public async ValueTask<string> CreateFileAsync(IFormFile filePath)
        {
            string extention = Path.GetExtension(filePath.FileName);

            var path = "/Images/" + Guid.NewGuid() + extention;

            string fullPath = _environment.WebRootPath + path;

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                await filePath.CopyToAsync(stream);
            }

            return path;
        }
    }
}
