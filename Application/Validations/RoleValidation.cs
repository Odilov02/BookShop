using Domain.Entities.IdentityEntities;
using FluentValidation;

namespace Application.Validations
{
    public class RoleValidation : AbstractValidator<Role>
    {
        public RoleValidation()
        {
            RuleFor(x => x.RoleName).NotEmpty().NotNull().MaximumLength(3).MaximumLength(30).WithMessage("RoleName is not valid");
        }
    }
}
