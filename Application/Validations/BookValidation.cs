using Domain.Entities;
using FluentValidation;

namespace Application.Validations
{
    public class BookValidation : AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Count).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Description).NotNull().NotEmpty().MinimumLength(30).MaximumLength(200);
            RuleFor(x => x.ImageUrl).NotNull().NotEmpty().MinimumLength(5);
            RuleFor(x => x.AuthorId).NotNull().NotEmpty();
            RuleFor(x => x.PageCount).NotNull().NotEmpty().GreaterThan(10);
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(5).MinimumLength(50);
            RuleFor(x => x.CategoryId).NotNull().NotEmpty();
            RuleFor(x => x.Language).NotNull().NotEmpty().MaximumLength(5).MinimumLength(50);
        }
    }
}
