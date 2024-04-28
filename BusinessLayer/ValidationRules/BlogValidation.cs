using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidation:AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("The blog title should not be empty");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("The blog content should not be empty");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("The blog image should not be empty");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("The blog title should not exceed 150 characters");
            RuleFor(x => x.BlogTitle).MinimumLength(4).WithMessage("The blog title should  exceed 4 characters");


        }
    }
}
