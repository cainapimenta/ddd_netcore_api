using API.Domain.Dtos.User;
using API.Domain.Models.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>()
                .ReverseMap();

            CreateMap<UserModel, UserDtoCreate>()
                .ReverseMap();

            CreateMap<UserModel, UserDtoUpdate>()
                .ReverseMap();
        }
    }
}
