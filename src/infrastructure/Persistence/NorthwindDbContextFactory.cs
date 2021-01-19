using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class NorthwindDbContextFactory : DesignTimeDbContextFactoryBase<ProjectDbContext>
    {
        protected override ProjectDbContext CreateNewInstance(DbContextOptions<ProjectDbContext> options)
        {
            return new ProjectDbContext(options);
        }
    }
}
