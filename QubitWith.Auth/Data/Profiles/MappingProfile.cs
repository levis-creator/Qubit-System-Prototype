using AutoMapper;
using QubitWith.Auth.Data.Models.Dtos;
using QubitWith.Auth.Data.Models.Entities;

namespace QubitSystem.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDisplayDto>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.DepartmentName : string.Empty));
            CreateMap<StudentInputDto, Student>()
                .ForMember(des => des.Courses,
                opt => opt.MapFrom(src => src.CoursesId != null ? new List<Course> { new Course
                     {
                        Id = (int)src.CoursesId,
                     }} : null));
            CreateMap<Student, StudentInputDto>()
                .ForMember(des => des.CoursesId,
                opt => opt.MapFrom(src => src.Courses.First().Id));
            CreateMap<Student, StudentDetailsDto>();

        }
    }
}
