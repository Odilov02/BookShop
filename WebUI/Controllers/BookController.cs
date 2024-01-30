using Application.DTOs.Books;
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
    private readonly IAuthorService _authorService;
    private readonly ICategoryService _categoryService;

    public BookController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService, IMapper mapper, IValidator<Book> validator) : base(mapper, validator)
    {
        _bookService = bookService;
        _authorService = authorService;
        _categoryService= categoryService;
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
    public async Task<ActionResult<ResponseCore<bool>>> UpdateBook([FromBody] BookUpdateDTO bookDTO)
    {
        Book book = _mapper.Map<Book>(bookDTO);
        var validationResult = _validator.Validate(book);
        if (!validationResult.IsValid)
        {
            return BadRequest(new ResponseCore<BookUpdateDTO>(false, validationResult.Errors));
        }
        Author? author =await _authorService.GetAsync(bookDTO.AuthorId);
        if (author==null)
        {
            return BadRequest(new ResponseCore<bool>() { Result = false, Errors = "Author not found" });
        }
        Category? category =await _categoryService.GetAsync(bookDTO.CategoryId);
        if (category==null)
        {

            return BadRequest(new ResponseCore<bool>() { Result = false, Errors = "Category not found" });
        }
        await _bookService.UpdateAsync(book);
        var result = await _bookService.UpdateAsync(book);
        ResponseCore<bool> ResponseCoreCore = new ResponseCore<bool>()
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
        Book? book = await _bookService.GetAsync(Id);
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
        Book? book = await _bookService.GetAsync(Id);
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
    public async Task<ActionResult<ResponseCore<PaginatedList<BookGetDTO>>>> GetAllBook(int pageSize = 10, int pageIndex = 1)
    {
        List<BookGetDTO> bookGetDtos = _mapper.Map<List<BookGetDTO>>(await _bookService.GetAllAsync());
        PaginatedList<BookGetDTO> paginatedList = PaginatedList<BookGetDTO>.CreateAsync(bookGetDtos, pageSize, pageIndex);
        return Ok(new ResponseCore<PaginatedList<BookGetDTO>>() { IsSuccess = true, Result = paginatedList });
    }


    [HttpGet]
    [Route("[action]")]
    [AllowAnonymous]
    public async Task<ActionResult<ResponseCore<PaginatedList<BookGetDTO>>>> SearchingBook(string searchingString, int pageSize = 10, int pageIndex = 1)
    {
        List<BookGetDTO> bookGetDtos = _mapper.Map<List<BookGetDTO>>(await _bookService.GetAllAsync())
                                              .Where(x => x.Language.Contains(searchingString) ||
                                                          x.Count.ToString().Contains(searchingString) ||
                                                          x.Description.Contains(searchingString) ||
                                                          x.Name.Contains(searchingString)
                                              ).ToList();
        PaginatedList<BookGetDTO> paginatedList = PaginatedList<BookGetDTO>.CreateAsync(bookGetDtos, pageSize, pageIndex);
        return Ok(new ResponseCore<PaginatedList<BookGetDTO>>() { IsSuccess = true, Result = paginatedList });
    }

}
