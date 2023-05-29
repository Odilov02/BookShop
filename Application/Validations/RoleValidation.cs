using Domain.Entities.IdentityEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class RoleValidation:AbstractValidator<Role>
    {
        public RoleValidation()
        {
            RuleFor(x => x.RoleName).NotEmpty().NotNull().MaximumLength(3).MaximumLength(30).WithMessage("RoleName is not valid");
        }
    }
}
