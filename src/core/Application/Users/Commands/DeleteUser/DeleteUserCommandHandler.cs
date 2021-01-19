using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IProjectDbContext _context;
        private readonly IMediator _mediator;

        public DeleteUserCommandHandler(IProjectDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            var entity = await _context.Users.FindAsync(userId);
            if (entity == null)
            {
                throw new UserNotFoundException(userId);
            }

            _context.Users.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new UserDeletedNotification() {UserId = userId}, cancellationToken);

            return Unit.Value;
        }
    }
}