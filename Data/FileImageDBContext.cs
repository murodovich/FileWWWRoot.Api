using FileWwwroot.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileWwwroot.Api.Data
{
    public class FileImageDBContext : DbContext
    {
        public FileImageDBContext(DbContextOptions<FileImageDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        
    }
}
