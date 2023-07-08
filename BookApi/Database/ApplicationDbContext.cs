using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>opt):base(opt)
        {
                
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Auther> Authers { get; set; }

    }
}
