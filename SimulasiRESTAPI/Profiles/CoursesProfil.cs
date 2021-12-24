using AutoMapper;

namespace SimulasiRESTAPI.Profiles
{
    public class CoursesProfil : Profile
    {
        public CoursesProfil()
        {
            CreateMap<Models.Course, Dtos.CourseDto>();
            CreateMap<Dtos.CourseForCreateDto, Models.Course>();
        }
    }
}
