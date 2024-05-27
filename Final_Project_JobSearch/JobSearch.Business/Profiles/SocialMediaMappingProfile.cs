using AutoMapper;
using JobSearch.Business.DTOs.SocialMediaDTOs;
using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Profiles
{
    public class SocialMediaMappingProfile : Profile
    {
        public SocialMediaMappingProfile()
        {
            CreateMap<SocialMediaCreateDTO, SocialMedia>();
            CreateMap<SocialMedia, SocialMediaListItemDTO>();
        }
    }
}
