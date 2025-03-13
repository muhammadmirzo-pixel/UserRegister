using AutoMapper;
using UserRegister.Domain.Entities;
using UserRegister.Service.DTOs.UserDtos;

namespace UserRegister.Service.Mappers;

public class MappingProfile :Profile
{
    public MappingProfile()
    {
        CreateMap<User,UserForCreationDto>().ReverseMap();
        CreateMap<User,UserForResultDto>().ReverseMap();
        CreateMap<User,UserForUpdateDto>().ReverseMap();
    }
}
