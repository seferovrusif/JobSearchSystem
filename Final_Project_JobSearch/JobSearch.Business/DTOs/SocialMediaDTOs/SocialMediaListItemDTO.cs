using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.SocialMediaDTOs
{
    public class SocialMediaListItemDTO
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string MainLink { get; set; }
    }
    public class SocialMediaListItemDTOValidator : AbstractValidator<SocialMediaListItemDTO>
    {
        public SocialMediaListItemDTOValidator()
        {
            RuleFor(a => a.Title)
                .MaximumLength(32)
                .NotEmpty()
                .NotNull(); 
            RuleFor(a => a.MainLink)
                .MaximumLength(128)
                .NotEmpty()
                .NotNull();
            RuleFor(a => a.Icon)
                .MaximumLength(128)
                .NotEmpty()
                .NotNull();
        }
    }
}
