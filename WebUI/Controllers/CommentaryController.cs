using Application.DTOs.Commentaries;
using Application.Interfaces.ServiceInterfaces;
using Application.Models;
using Application.ResponseCoreModel;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Controllers;
using WebUI.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CommentaryController : ApiBaseController<Commentary>
{
    private readonly ICommentaryService _commentaryService;

    public CommentaryController(ICommentaryService commentaryService, IMapper mapper, IValidator<Commentary> validator) : base(mapper, validator)
    {
        _commentaryService = commentaryService;
    }



    [HttpPost("[action]")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<List<CommentaryCreateDTO>>>> CreateCommenatry([FromBody] CommentaryCreateDTO commentaryDto)
    {
        Commentary commentary = _mapper.Map<Commentary>(commentaryDto);
        var validationResult = _validator.Validate(commentary);
        if (!validationResult.IsValid)
        {
            return BadRequest(new ResponseCore<CommentaryCreateDTO>(false, validationResult.Errors));
        }
        await _commentaryService.AddAsync(commentary);
        var result = _mapper.Map<CommentaryCreateDTO>(commentary);
        ResponseCore<CommentaryCreateDTO> ResponseCoreCore = new ResponseCore<CommentaryCreateDTO>()
        {
            IsSuccess = true,
            Result = result
        };
        return Ok(ResponseCoreCore);
    }



    [HttpDelete]
    [Route("[action]")]
    [Authorize(Roles = "DeleteCommentary")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<bool>>> DeleteCommentary(Guid Id)
    {
        Commentary? commentary = await _commentaryService.Get(Id);
        if (commentary == null)
        {
            return BadRequest(new ResponseCore<bool>() { Result = false, Errors = "Commentary not found" });
        }
        var result = await _commentaryService.DeleteAsync(commentary);
        return Ok(new ResponseCore<bool>() { Result = result });
    }



    [HttpGet]
    [Route("[action]")]
    [AllowAnonymous]
    public async Task<ActionResult<ResponseCore<CommentaryGetDTO>>> GetCommentary(Guid Id)
    {
        Commentary? commentary = await _commentaryService.Get(Id);
        if (commentary == null)
        {
            return BadRequest(new ResponseCore<CommentaryGetDTO>() { IsSuccess = false, Errors = "Commentary not found" });
        }
        CommentaryGetDTO commentaryGetDto = _mapper.Map<CommentaryGetDTO>(commentary);
        return Ok(new ResponseCore<CommentaryGetDTO>() { IsSuccess = true, Result = commentaryGetDto });

    }



    [HttpGet("[action]")]
    [AllowAnonymous]
    public async Task<ActionResult<ResponseCore<PaginatedList<CommentaryGetDTO>>>> GetAllCommentary(int pageSize = 10, int pageIndex = 1)
    {
        List<CommentaryGetDTO> commentaryGetDtos = _mapper.Map<List<CommentaryGetDTO>>(await _commentaryService.GetAll());
        PaginatedList<CommentaryGetDTO> paginatedList = PaginatedList<CommentaryGetDTO>.CreateAsync(commentaryGetDtos, pageSize, pageIndex);
        return Ok(new ResponseCore<PaginatedList<CommentaryGetDTO>>() { IsSuccess = true, Result = paginatedList });
    }
}

