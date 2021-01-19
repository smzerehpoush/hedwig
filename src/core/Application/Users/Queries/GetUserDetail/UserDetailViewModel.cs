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
     
        //public void Mapping(Profile profile)
        // {
        //     profile.CreateMap<Customer, CustomerDetailVm>()
        //         .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.CustomerId));
        // }
    }
}