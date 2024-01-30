using Domain.Entities;
using FluentValidation;

namespace Application.Validations
{
    public class CommentaryValidation : AbstractValidator<Commentary>
    {
        public CommentaryValidation()
        {
            RuleFor(x => x.Description).NotEmpty().NotNull().MinimumLength(1).MaximumLength(100).WithMessage("Description is not valid");
        }
    }
}
