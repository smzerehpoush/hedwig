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
        private readonly DeleteUserCommandHandler _sut;
        private static readonly Guid validUserId = Guid.Parse("12144cc2-6038-459b-b705-29635daf53ef");

        public DeleteUserCommandTests()
        {
            var mediator = new Mock<IMediator>().Object;
            _sut = new DeleteUserCommandHandler(_context, mediator);
        }

        [Fact]
        public async void Handle_GivenInvalidRequest_FakeUserId_ThrowsUserNotFoundException()
        {
            // Arrange
            var newUserId = Guid.NewGuid();

            // Act
            await Assert.ThrowsAsync<UserNotFoundException>(() =>
                _sut.Handle(new DeleteUserCommand() {UserId = newUserId}, CancellationToken.None));
        }

        [Fact]
        public async void Handle_GivenInvalidRequest_EmptyUserId_ThrowsUserNotFoundException()
        {
            // Arrange
            Guid? newUserId = null;

            // Act
            await Assert.ThrowsAsync<UserNotFoundException>(() =>
                _sut.Handle(new DeleteUserCommand() {UserId = newUserId}, CancellationToken.None));
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseUserDeletedNotification()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var newUserId = validUserId;
            var sut = new DeleteUserCommandHandler(_context, mediatorMock.Object);
            // Act
            var result =
                sut.Handle(new DeleteUserCommand() {UserId = newUserId}, CancellationToken.None);


            // Assert
            Assert.NotNull(result);
            mediatorMock.Verify(
                m => m.Publish(It.Is<UserDeletedNotification>(
                        cc => cc.UserId == newUserId),
                    It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}