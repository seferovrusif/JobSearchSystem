using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.CityDTOs
{
    public class CityListItemDTO
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string Name { get; set; }
    }
    public class CityListItemDTOValidator : AbstractValidator<CityListItemDTO>
    {
        public CityListItemDTOValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);
                
                
        }
    }
}
