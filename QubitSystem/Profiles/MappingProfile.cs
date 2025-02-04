using AutoMapper;
using QubitSystem.Models.Dtos;
using QubitSystem.Models.Entities;

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
                        Id = src.CoursesId,
                     }} : null));
            CreateMap<Student, StudentInputDto>()
                .ForMember(des => des.CoursesId,
                opt => opt.MapFrom(src => src.Courses.First().Id));
            CreateMap<Student, StudentDetailsDto>();

        }
    }
}
