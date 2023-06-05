using Domain.Entities;
using FluentValidation;
namespace Application.Validations
{
    public class AuthorValidation : AbstractValidator<Author>
    {
        public AuthorValidation()
        {
         //   RuleFor(x => x.FullName).NotEmpty().NotNull().MaximumLength(30).MinimumLength(5).WithMessage("FullName is not valid");
          //  RuleFor(x => x.Description).NotEmpty().NotNull().MinimumLength(10).WithMessage("Description is not valid");
        }
    }
}
