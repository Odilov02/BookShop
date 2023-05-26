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
            RuleFor(x => x.Password).NotNull().NotEmpty().NotEmpty().MinimumLength(5).MinimumLength(10);
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().Matches(@"^\+998\d{9}$");
            RuleFor(x => x.FullName).NotNull().NotEmpty();
        }
    }
}
