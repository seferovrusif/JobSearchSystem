using AutoMapper;
using JobSearch.Business.DTOs.SalaryDTOs;
using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JobSearch.Business.Profiles
{
    public class SalaryMappingProfile : Profile
    {
        public SalaryMappingProfile()
        {
            CreateMap<SalaryCreateDTO, Salary>();
            CreateMap<SalaryUpdateDTO, Salary>();
            CreateMap<Salary, SalaryListItemDTO>();
        }
    }
}
