using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Categories;

public class CategoryUpdateDTO:CategoryBaseDTO
{
    public string Name { get; set; } = "";
}
