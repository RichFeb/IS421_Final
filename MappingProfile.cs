using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace SchoolAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Organization, OrganizationDto>()
                    .ForMember(c => c.FullAddress,
                        opt => opt.MapFrom(x => string.Join(' ', x.City, x.Country)));

            CreateMap<OrganizationForCreationDto, Organization>();
            CreateMap<OrganizationForUpdateDto, Organization>();

            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserForUpdateDto, User>();

            CreateMap<School, SchoolDto>();
            CreateMap<SchoolForCreationDto, School>();
            CreateMap<SchoolForUpdateDto, School>();

            CreateMap<Course, CourseDto>();
            CreateMap<CourseForCreationDto, Course>();
            CreateMap<CourseForUpdateDto, Course>();


            CreateMap<Assignment, AssignmentDto>();
            CreateMap<AssignmentForCreationDto, Assignment>();
            CreateMap<AssignmentForUpdateDto, Assignment>();

            CreateMap<Section, SectionDto>();
            CreateMap<SectionForCreationDto, Section>();
            CreateMap<SectionForUpdateDto, Section>();

            CreateMap<Submission, SubmissionDto>();
            CreateMap<SubmissionForCreationDto, Submission>();
            CreateMap<SubmissionForUpdateDto, Submission>();
        }
    }
}
