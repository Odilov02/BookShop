using Application.DTOs.Books;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Categories;

public class CategoryGetDTO:BookBaseDTO
{
    public string Name { get; set; } = "";
    public ICollection<Guid>? BookIds { get; set; }
}
