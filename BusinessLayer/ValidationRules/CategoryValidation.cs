using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidation:AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.CategoryName).NotEmpty()
                                        .WithMessage("The category name will not be crossed");
            RuleFor(x => x.CategoryDescription).NotEmpty()
                                        .WithMessage("The category description will not be crossed");
            RuleFor(x => x.CategoryName).MinimumLength(2)
                                        .WithMessage("The category name must be more than the usual 2 characters");
            RuleFor(x => x.CategoryName).MaximumLength(50)
                                        .WithMessage("The category name should be less than 50 characters");
            RuleFor(x => x.CategoryDescription).MinimumLength(8)
                                        .WithMessage("The category description must be more than the usual 8 characters");

        }
    }
}
