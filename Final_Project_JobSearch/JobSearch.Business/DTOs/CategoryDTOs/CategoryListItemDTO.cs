using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.CategoryDTOs
{
   public class CategoryListItemDTO
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
    public class CategoryListItemDTOValidator : AbstractValidator<CategoryListItemDTO>
    {
        public CategoryListItemDTOValidator()
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