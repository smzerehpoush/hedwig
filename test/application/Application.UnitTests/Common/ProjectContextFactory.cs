using System;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence;

namespace Application.UnitTests.Common
{
    public class ProjectContextFactory
    {
        public static ProjectDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ProjectDbContext(options);

            context.Database.EnsureCreated();

            context.Users.AddRange(new[] {
                new User() { Id = Guid.Parse("12144cc2-6038-459b-b705-29635daf53ef"), Name = "test name 1", MobileNo = 9124398514},
                new User() { Id = Guid.Parse("2194f42f-d633-49d8-9824-e7b54d676ed0"), Name = "test name 2", MobileNo = 9124398515},
                new User() { Id = Guid.Parse("eb95449f-633e-4792-a7c7-a7ed80a030e6"), Name = "test name 3", MobileNo = 9124398516},
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(ProjectDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}