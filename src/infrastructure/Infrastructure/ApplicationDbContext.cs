using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}