using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidation:AbstractValidator<Writer>
    {
        public WriterValidation()
        {
            RuleFor(x=>x.WriterName).NotEmpty()
                .WithMessage("The author's name and surname section cannot be left blank.");

            RuleFor(x => x.WriterName).MinimumLength(2)
                .WithMessage("Enter at least 2 characters");

            RuleFor(x=>x.WriterMail).NotEmpty()
                .WithMessage("E-mail section cannot be left blank.");

            RuleFor(x => x.WriterPassword).NotEmpty()
                .WithMessage("Password section cannot be left blank.");

            RuleFor(x => x.WriterPassword).MinimumLength(8)
                .WithMessage("Enter at least 2 characters");

        }
    }
}
