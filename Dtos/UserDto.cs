namespace FileWwwroot.Api.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile ImageUrl { get; set; }

    }
}
