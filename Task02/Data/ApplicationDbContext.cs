using Task02.Models;
using Microsoft.EntityFrameworkCore;

namespace Task02.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Authors> Authors { get; set; }
    }
}
