using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.CategoryDTOs
{
    public class CategoryCreateDTO
    {
        public string Name {  get; set; }
        public int? ParentId { get; set; }
    }
    public class CategoryCreateDTOValidator : AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateDTOValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);

            RuleFor(a => a.ParentId)
                .GreaterThan(0);
        }
    }

}
