using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ProjectDbContextFactory : DesignTimeDbContextFactoryBase<ProjectDbContext>
    {
        protected override ProjectDbContext CreateNewInstance(DbContextOptions<ProjectDbContext> options)
        {
            return new ProjectDbContext(options);
        }
    }
}
