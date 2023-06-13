using Domain.Entities;
using Domain.Entities.IdentityEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class PermissionValidation: AbstractValidator<Permission>
    {
        public PermissionValidation()
        {
            
        }
    }
}
