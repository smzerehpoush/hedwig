using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Users.Queries.GetUsersList
{
    public class UserDto : IMapFrom<User>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public long MobileNo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.MobileNo, opt => opt.MapFrom(s => s.MobileNo));
        }
    }
}