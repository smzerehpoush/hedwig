using System;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Users.Queries.GetUser
{
    public class UserDetailViewModel : IMapFrom<User>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long MobileNo { get; set; }
    }
}