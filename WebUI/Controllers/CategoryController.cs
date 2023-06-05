using Application.DTOs.Categories;
using Application.Interfaces.ServiceInterfaces;
using Application.Models;
using Application.ResponseCoreModel;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Controllers;
using WebUI.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoryController : ApiBaseController<Category>
{
    private readonly ICategoryService _categoryService;



    public CategoryController(ICategoryService categoryService, IMapper mapper, IValidator<Category> validator) : base(mapper, validator)
    {
        _categoryService = categoryService;
    }



    [HttpPost("[action]")]
    [Authorize(Roles = "CreateCategory")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<List<CategoryCreateDTO>>>> CreateCategory([FromBody] CategoryCreateDTO categoryDto)
    {
        Category category = _mapper.Map<Category>(categoryDto);
        var validationResult = _validator.Validate(category);
        if (!validationResult.IsValid)
        {
            return BadRequest(new ResponseCore<CategoryCreateDTO>(false, validationResult.Errors));
        }
        await _categoryService.AddAsync(category);
        var result = _mapper.Map<CategoryCreateDTO>(category);
        ResponseCore<CategoryCreateDTO> ResponseCoreCore = new ResponseCore<CategoryCreateDTO>()
        {
            IsSuccess = true,
            Result = result
        };
        return Ok(ResponseCoreCore);
    }



    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles = "UpdateCategory")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<List<CategoryUpdateDTO>>>> UpdateCategory([FromBody] CategoryUpdateDTO categoryDto)
    {
        Category category  = _mapper.Map<Category>(categoryDto);
        var validationResult = _validator.Validate(category);
        if (!validationResult.IsValid)
        {
            return BadRequest(new ResponseCore<CategoryUpdateDTO>(false, validationResult.Errors));
        }
        await _categoryService.UpdateAsync(category);
        var result = _mapper.Map<CategoryUpdateDTO>(category);
        ResponseCore<CategoryUpdateDTO> ResponseCoreCore = new ResponseCore<CategoryUpdateDTO>()
        {
            IsSuccess = true,
            Result = result
        };
        return Ok(ResponseCoreCore);
    }



    [HttpDelete]
    [Route("[action]")]
    [Authorize(Roles = "DeleteCategory")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<bool>>> DeleteCategory(Guid Id)
    {
        Category? category = await _categoryService.Get(Id);
        if (category == null)
        {
            return BadRequest(new ResponseCore<bool>() { Result = false, Errors = "Category not found" });
        }
        var result = await _categoryService.DeleteAsync(category);
        return Ok(new ResponseCore<bool>() { Result = result });
    }



    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles = "GetCategory")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<CategoryGetDTO>>> GetCategory(Guid Id)
    {
        Category? category = await _categoryService.Get(Id);
        if (category == null)
        {
            return BadRequest(new ResponseCore<CategoryGetDTO>() { IsSuccess = false, Errors = "Category not found" });
        }
        CategoryGetDTO authorGetDto = _mapper.Map<CategoryGetDTO>(category);
        return Ok(new ResponseCore<CategoryGetDTO>() { IsSuccess = true, Result = authorGetDto });

    }



    [HttpGet("[action]")]
    [Authorize(Roles = "GetAllCategory")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<PaginatedList<CategoryGetDTO>>>> GetAllCAtegory(int pageSize = 10, int pageIndex = 1)
    {
        List<CategoryGetDTO> commentaryGetDtos = _mapper.Map<List<CategoryGetDTO>>(await _categoryService.GetAll());
        PaginatedList<CategoryGetDTO> paginatedList = PaginatedList<CategoryGetDTO>.CreateAsync(commentaryGetDtos, pageSize, pageIndex);
        return Ok(new ResponseCore<PaginatedList<CategoryGetDTO>>() { IsSuccess = true, Result = paginatedList });
    }
}

