using Application.Users.Queries.GetUsersList;
using AutoMapper;
using Domain.Entities;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldUserToUserDto()
        {
            var entity = new User();

            var result = _mapper.Map<UserDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<UserDto>();
        }
    }
}
