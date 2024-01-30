using Domain.Entities;
using FluentValidation;

namespace Application.Validations
{
    public class BookValidation : AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThan(0).WithMessage("Price is not valid");
            RuleFor(x => x.Count).NotNull().NotEmpty().GreaterThan(0).WithMessage("Count is not valid");
            RuleFor(x => x.Description).NotNull().NotEmpty().MinimumLength(30).MaximumLength(200).WithMessage("Description is not valid");
            RuleFor(x => x.ImageUrl).NotNull().NotEmpty().MinimumLength(5).WithMessage("ImageUrl is not valid");
            RuleFor(x => x.PageCount).NotNull().NotEmpty().GreaterThan(10).WithMessage("PageCount is not valid");
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(5).MinimumLength(50).WithMessage("Name is not valid");
            RuleFor(x => x.Language).NotNull().NotEmpty().MaximumLength(5).MinimumLength(50).WithMessage("Language is not valid");
        }
    }
}
