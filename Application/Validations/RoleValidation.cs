using Domain.Entities.IdentityEntities;
using FluentValidation;

namespace Application.Validations
{
    public class RoleValidation : AbstractValidator<Role>
    {
        public RoleValidation()
        {
            RuleFor(x => x.RoleName).NotEmpty().NotNull().WithMessage("RoleName is not valid");
        }
    }
}
