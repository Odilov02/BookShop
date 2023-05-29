using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using FluentValidation;
namespace Application.Validations
{
    public class AuthorValidation:AbstractValidator<Author>
    {
        public AuthorValidation()
        {
            RuleFor(x => x.FullName).NotEmpty().NotNull().MaximumLength(30).MinimumLength(5).WithMessage("FullName is not valid");
            RuleFor(x=>x.Description).NotEmpty().NotNull().MinimumLength(2).MaximumLength(100).WithMessage("Description is not valid");
        }
    }
}
