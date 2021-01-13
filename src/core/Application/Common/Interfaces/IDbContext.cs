using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Application.Common.Interfaces
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
    }
}