using Domain.Entities;
using FluentValidation;

namespace Application.Validations
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Name).NotEmpty().NotEmpty().MaximumLength(30).MinimumLength(3).WithMessage("Name is not valid");

        }
    }
}
