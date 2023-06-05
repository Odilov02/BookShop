using Application.DTOs.Books;
using Application.DTOs.users;
using Application.DTOs.Users;
using Application.Interfaces.ServiceInterfaces;
using Application.Models;
using Application.ResponseCoreModel;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Filters;
namespace WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BookController : ApiBaseController<Book>
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService, IMapper mapper, IValidator<Book> validator) : base(mapper, validator)
    {
        _bookService = bookService;
    }


    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles = "CreateBook")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<List<BookCreateDTO>>>> CreateBook([FromBody] BookCreateDTO bookDTO)
    {
        Book book = _mapper.Map<Book>(bookDTO);
        var validationResult = _validator.Validate(book);
        if (!validationResult.IsValid)
        {
            return BadRequest(new ResponseCore<UserCreateDTO>(false, validationResult.Errors));
        }
        await _bookService.AddAsync(book);
        var result = _mapper.Map<BookCreateDTO>(book);
        ResponseCore<BookCreateDTO> ResponseCoreCore = new ResponseCore<BookCreateDTO>()
        {
            IsSuccess = true,
            Result = result
        };
        return Ok(ResponseCoreCore);
    }


    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles = "UpdateBook")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<List<BookUpdateDTO>>>> UpdateBook([FromBody] BookUpdateDTO bookDTO)
    {
        Book book = _mapper.Map<Book>(bookDTO);
        var validationResult = _validator.Validate(book);
        if (!validationResult.IsValid)
        {
            return BadRequest(new ResponseCore<BookUpdateDTO>(false, validationResult.Errors));
        }
        await _bookService.UpdateAsync(book);
        var result = _mapper.Map<BookUpdateDTO>(book);
        ResponseCore<BookUpdateDTO> ResponseCoreCore = new ResponseCore<BookUpdateDTO>()
        {
            IsSuccess = true,
            Result = result
        };
        return Ok(ResponseCoreCore);
    }



    [HttpDelete]
    [Route("[action]")]
    [Authorize(Roles = "DeleteBook")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<bool>>> DeleteBook(Guid Id)
    {
        Book? book = await _bookService.Get(Id);
        if (book == null)
        {
            return BadRequest(new ResponseCore<bool>() { Result = false, Errors = "Book not found" });
        }
        var result = await _bookService.DeleteAsync(book);
        return Ok(new ResponseCore<bool>() { Result = result });
    }



    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles = "GetBook")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<BookGetDTO>>> GetBook(Guid Id)
    {
        Book? book = await _bookService.Get(Id);
        if (book == null)
        {
            return BadRequest(new ResponseCore<BookGetDTO>() { IsSuccess = false, Errors = "User not found" });
        }
        BookGetDTO bookGetDto = _mapper.Map<BookGetDTO>(book);
        return Ok(new ResponseCore<BookGetDTO>() { IsSuccess = true, Result = bookGetDto });

    }



    [HttpGet]
    [Route("[action]")]
    [AllowAnonymous]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<PaginatedList<BookGetDTO>>>> GetAllBook(int pageSize = 10, int pageIndex = 1)
    {
        List<BookGetDTO> bookGetDtos = _mapper.Map<List<BookGetDTO>>(await _bookService.GetAll());
        PaginatedList<BookGetDTO> paginatedList = PaginatedList<BookGetDTO>.CreateAsync(bookGetDtos, pageSize, pageIndex);
        return Ok(new ResponseCore<PaginatedList<BookGetDTO>>() { IsSuccess = true, Result = paginatedList });
    }

}
