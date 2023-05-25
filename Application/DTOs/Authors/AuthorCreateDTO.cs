using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Author;

public class AuthorCreateDTO
{
    public string FullName { get; set; } = "";

    public string Description { get; set; } = "";
}
