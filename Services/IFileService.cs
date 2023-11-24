namespace FileWwwroot.Api.Services
{
    public interface IFileService
    {
        public ValueTask<string> CreateFileAsync(IFormFile filePath);
    }
}
