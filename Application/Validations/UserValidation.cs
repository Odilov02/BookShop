using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class UserValidation:AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.Password).NotNull().NotEmpty().NotEmpty().Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$").WithMessage("Password  is not valid");
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().Matches(@"^\+998\d{9}$").WithMessage("PhoneNumber  is not valid");
            RuleFor(x => x.FullName).NotNull().NotEmpty().WithMessage("FullName  is not valid");
        }
    }
}
