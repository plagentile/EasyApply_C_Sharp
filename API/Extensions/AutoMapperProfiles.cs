using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.HelperClasses
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Applicant, ApplicantDto>();
            CreateMap<Corporation, CorporateDto>();
            CreateMap<JobPosting, JobPostingDto>();
            CreateMap<Resume, ResumeDto>();
            CreateMap<Users, UserDto>();
        }
    }
}