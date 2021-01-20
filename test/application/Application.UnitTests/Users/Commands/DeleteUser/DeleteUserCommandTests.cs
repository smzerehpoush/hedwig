using System;
using System.Threading;
using Application.UnitTests.Common;
using Application.Users.Commands.DeleteUser;
using MediatR;
using Moq;
using Xunit;

namespace Application.UnitTests.Users.Commands.DeleteUser
{
    public class DeleteUserCommandTests : CommandTestBase
    {
        private readonly IMediator _mediator;
        private readonly DeleteUserCommandHandler _sut;
        private static readonly Guid validUserId = Guid.Parse("12144cc2-6038-459b-b705-29635daf53ef");

        public DeleteUserCommandTests()
        {
            _mediator = new Mock<IMediator>().Object;
            _sut = new DeleteUserCommandHandler(_context, _mediator);
        }

        [Fact]
        public async void Handle_GivenInvalidRequest_FakeUserId_ThrowsUserNotFoundException()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new DeleteUserCommandHandler(_context, mediatorMock.Object);
            var newUserId = Guid.NewGuid();

            // Act
            await Assert.ThrowsAsync<UserNotFoundException>(() =>
                sut.Handle(new DeleteUserCommand() {UserId = newUserId}, CancellationToken.None));
            
        }
        [Fact]
        public async void Handle_GivenInvalidRequest_EmptyUserId_ThrowsUserNotFoundException()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new DeleteUserCommandHandler(_context, mediatorMock.Object);
            Guid newUserId = Guid.Empty;

            // Act
            await Assert.ThrowsAsync<UserNotFoundException>(() =>
                sut.Handle(new DeleteUserCommand() {UserId = newUserId}, CancellationToken.None));
            
        }
        
        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseUserDeletedNotification()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new DeleteUserCommandHandler(_context, mediatorMock.Object);
            var newUserId = validUserId;
        
            // Act
            var result =
                sut.Handle(new DeleteUserCommand() {UserId = newUserId}, CancellationToken.None);
        
        
            // Assert
            mediatorMock.Verify(
                m => m.Publish(It.Is<UserDeletedNotification>(
                        cc => cc.UserId == newUserId),
                    It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}