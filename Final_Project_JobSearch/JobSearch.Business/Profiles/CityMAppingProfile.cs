using AutoMapper;
using JobSearch.Business.DTOs.CityDTOs;
using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JobSearch.Business.Profiles
{
    public class CityMAppingProfile : Profile
    {
        public CityMAppingProfile()
        {
            
            CreateMap<CityCreateDTO, City>();
            CreateMap<CityUpdateDTO, City>();
            CreateMap<City, CityListItemDTO>();
        }
    }
}
