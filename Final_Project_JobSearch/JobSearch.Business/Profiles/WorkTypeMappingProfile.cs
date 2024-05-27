using AutoMapper;
using JobSearch.Business.DTOs.WorkTypeDTOs;
using JobSearch.Core.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JobSearch.Business.Profiles
{
    public class WorkTypeMappingProfile: Profile
    {
        public WorkTypeMappingProfile()
    {
        CreateMap<WorkTypeCreateDTO, WorkType>();
        CreateMap<WorkTypeUpdateDTO, WorkType>();
        CreateMap<WorkType, WorkTypeListItemDTO>();
    }
}
}
