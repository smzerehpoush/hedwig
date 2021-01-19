using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Users.Commands.DeleteUser
{
    public class UserDeletedNotificationHandler : INotificationHandler<UserDeletedNotification>
    {
        private readonly ILogger _logger;

        public UserDeletedNotificationHandler(ILogger logger)
        {
            _logger = logger;
        }

        public Task Handle(UserDeletedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"User with id {notification.UserId} deleted successfully.");
            return Task.CompletedTask;
        }
    }
}