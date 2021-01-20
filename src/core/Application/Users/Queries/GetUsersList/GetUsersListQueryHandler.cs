using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, GetUsersListViewModel>
    {
        private readonly IProjectDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(IProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUsersListViewModel> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new GetUsersListViewModel() {Users = users};
        }
    }
}