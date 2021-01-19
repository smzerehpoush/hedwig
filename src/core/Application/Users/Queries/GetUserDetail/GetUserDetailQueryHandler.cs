using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Users.Commands.DeleteUser;
using AutoMapper;
using MediatR;

namespace Application.Users.Queries.GetUser
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailViewModel>
    {
        private readonly IProjectDbContext _context;
        private readonly IMapper _mapper;

        public GetUserDetailQueryHandler(IProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDetailViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;

            var entity = await _context.Users.FindAsync();
            if (entity == null)
            {
                throw new UserNotFoundException(userId);
            }

            return _mapper.Map<UserDetailViewModel>(entity);
        }
    }
}