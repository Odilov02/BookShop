using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class CommentaryValidation:AbstractValidator<Commentary>
    {
        public CommentaryValidation()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x=>x.BookId).NotEmpty().NotNull();
            RuleFor(x => x.Description).NotEmpty().NotNull().MinimumLength(1).MaximumLength(100);
        }
    }
}
