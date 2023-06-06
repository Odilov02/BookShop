
using Application.DTOs.Authors;
using Application.DTOs.Roles;
using Application.DTOs.Users;
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
public class RoleController : ApiBaseController<Role>
{
    private readonly IRoleService _roleService;


    public RoleController(IRoleService roleService, IMapper mapper, IValidator<Role> validator) : base(mapper, validator)
    {
        _roleService = roleService;
    }



    [HttpPost("[action]")]
    [Authorize(Roles = "CreateRole")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<List<RoleCreateDTO>>>> CreateRole([FromBody] RoleCreateDTO roleDto)
    {
        Role role = _mapper.Map<Role>(roleDto);
        var validationResult = _validator.Validate(role);
        if (!validationResult.IsValid)
        {
            return BadRequest(new ResponseCore<RoleCreateDTO>(false, validationResult.Errors));
        }
        await _roleService.AddAsync(role);
        var result = _mapper.Map<RoleCreateDTO>(role);
        ResponseCore<RoleCreateDTO> ResponseCoreCore = new ResponseCore<RoleCreateDTO>()
        {
            IsSuccess = true,
            Result = result
        };
        return Ok(ResponseCoreCore);
    }



    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles = "UpdateRole")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<List<RoleUpdateDTO>>>> UpdateRole([FromBody] RoleUpdateDTO roleDto)
    {
        Role role = _mapper.Map<Role>(roleDto);
        var validationResult = _validator.Validate(role);
        if (!validationResult.IsValid)
        {
            return BadRequest(new ResponseCore<AuthorUpdateDTO>(false, validationResult.Errors));
        }
        await _roleService.UpdateAsync(role);
        var result = _mapper.Map<RoleUpdateDTO>(role);
        ResponseCore<RoleUpdateDTO> ResponseCoreCore = new ResponseCore<RoleUpdateDTO>()
        {
            IsSuccess = true,
            Result = result
        };
        return Ok(ResponseCoreCore);
    }



    [HttpDelete]
    [Route("[action]")]
    [Authorize(Roles = "DeleteRole")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<bool>>> DeleteRole(Guid Id)
    {
        Role? role = await _roleService.Get(Id);
        if (role == null)
        {
            return BadRequest(new ResponseCore<bool>() { Result = false, Errors = "Role not found" });
        }
        var result = await _roleService.DeleteAsync(role);
        return Ok(new ResponseCore<bool>() { Result = result });
    }



    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles = "GetRole")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<RoleGetDTO>>> GetRole(Guid Id)
    {
        Role? role = await _roleService.Get(Id);
        if (role == null)
        {
            return BadRequest(new ResponseCore<RoleGetDTO>() { IsSuccess = false, Errors = "Role not found" });
        }
        RoleGetDTO roleGetDto = _mapper.Map<RoleGetDTO>(role);
        return Ok(new ResponseCore<RoleGetDTO>() { IsSuccess = true, Result = roleGetDto });

    }



    [HttpGet("[action]")]
    [Authorize(Roles = "GetRole")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<PaginatedList<RoleGetDTO>>>> GetAllRole(int pageSize = 10, int pageIndex = 1)
    {
        List<RoleGetDTO> roleGetDtos = _mapper.Map<List<RoleGetDTO>>(await _roleService.GetAll());
        PaginatedList<RoleGetDTO> paginatedList = PaginatedList<RoleGetDTO>.CreateAsync(roleGetDtos, pageSize, pageIndex);
        return Ok(new ResponseCore<PaginatedList<RoleGetDTO>>() { IsSuccess = true, Result = paginatedList });
    }


    [HttpGet("SearchingRole")]
    [Authorize(Roles = "GetRole")]
    public async Task<ActionResult<ResponseCore<PaginatedList<RoleGetDTO>>>> SearchingRole(string SearchString, int pageSize = 10, int pageIndex = 1)
    {

        List<RoleGetDTO> roleGetDtos = _mapper.Map<List<RoleGetDTO>>((await _roleService.GetAll())
                                              .Where(x => x.RoleName!.Contains(SearchString)));
        PaginatedList<RoleGetDTO> paginatedList = PaginatedList<RoleGetDTO>.CreateAsync(roleGetDtos, pageSize, pageIndex);
        return Ok(new ResponseCore<PaginatedList<RoleGetDTO>>() { IsSuccess = true, Result = paginatedList });
    }
}
