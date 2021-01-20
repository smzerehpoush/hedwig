using System;
using Application.Common.Interfaces;
using Persistence;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly ProjectDbContext _context;

        public CommandTestBase()
        {
            _context = ProjectContextFactory.Create();
        }

        public void Dispose()
        {
            ProjectContextFactory.Destroy(_context);
        }
    }
}