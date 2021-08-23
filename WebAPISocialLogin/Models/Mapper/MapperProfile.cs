using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities;
using WebAPISocialLogin.Entities.Dtos;

namespace WebAPISocialLogin.Models.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserForSetUserDto, User>()
                .ForMember(dest => dest.Id, options => options.MapFrom(userItem => userItem.Id))
                .ForMember(dest => dest.FirstName, options => options.MapFrom(userItem => userItem.FirstName))
                .ForMember(dest => dest.LastName, options => options.MapFrom(userItem => userItem.LastName))
                .ForMember(dest => dest.Address, options => options.MapFrom(userItem => userItem.Address))
                .ForMember(dest => dest.City, options => options.MapFrom(userItem => userItem.City))
                .ForMember(dest => dest.County, options => options.MapFrom(userItem => userItem.County))
                .ForMember(dest => dest.EducationInfo, options => options.MapFrom(userItem => userItem.EducationInfo))
                .ForMember(dest => dest.Email, options => options.MapFrom(userItem => userItem.Email))
                .ForMember(dest => dest.ProfileAvatarUrl, options => options.MapFrom(userItem => userItem.ProfileAvatar))
                .ForMember(dest => dest.Tel, options => options.MapFrom(userItem => userItem.Tel));


        }
    }
}
