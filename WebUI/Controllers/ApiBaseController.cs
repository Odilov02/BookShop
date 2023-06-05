using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class ApiBaseController<T> : ControllerBase
{
    protected readonly IMapper _mapper;
    protected readonly IValidator<T> _validator;
    public ApiBaseController(IMapper mapper, IValidator<T> validator)
    {
        _mapper = mapper;
        _validator = validator;
    }
}
