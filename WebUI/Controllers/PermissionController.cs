using Application.DTOs.Permissions;
using Application.Interfaces.ServiceInterfaces;
using Application.Models;
using Application.ResponseCoreModel;
using AutoMapper;
using Domain.Entities.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Controllers;
using WebUI.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PermissionController : ApiBaseController<Permission>
{
    private readonly IPermissionService _permissionService;



    public PermissionController(IPermissionService permissionService, IMapper mapper, IValidator<Permission> validator) : base(mapper, validator)
    {
        _permissionService = permissionService;
    }



    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles = "GetPermission")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<PermissionGetDTO>>> GetPermission(Guid Id)
    {
        Permission? permissin = await _permissionService.Get(Id);
        if (permissin == null)
        {
            return BadRequest(new ResponseCore<PermissionGetDTO>() { IsSuccess = false, Errors = "Permission not found" });
        }
        PermissionGetDTO permissionGetDTO = _mapper.Map<PermissionGetDTO>(permissin);
        return Ok(new ResponseCore<PermissionGetDTO>() { IsSuccess = true, Result = permissionGetDTO });
    }



    [HttpGet("[action]")]
    [Authorize(Roles = "GetAllPermission")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<PaginatedList<PermissionGetDTO>>>> GetAllPermission(int pageSize = 10, int pageIndex = 1)
    {
        List<PermissionGetDTO> permissionGetDtos = _mapper.Map<List<PermissionGetDTO>>(await _permissionService.GetAll());
        PaginatedList<PermissionGetDTO> paginatedList = PaginatedList<PermissionGetDTO>.CreateAsync(permissionGetDtos, pageSize, pageIndex);
        return Ok(new ResponseCore<PaginatedList<PermissionGetDTO>>() { IsSuccess = true, Result = paginatedList });
    }
}
