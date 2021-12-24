using AutoMapper;
using System;

namespace SimulasiRESTAPI.Profiles
{
    public class AuthorsProfil : Profile
    {
        public AuthorsProfil()
        {
            CreateMap<Models.Author, Dtos.AuthorDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age,
                opt => opt.MapFrom(src => $"{DateTime.Now.Year - src.DateOfBirth.Year}"));

            CreateMap<Dtos.AuthorForCreateDto, Models.Author>();

        }
    }
}
