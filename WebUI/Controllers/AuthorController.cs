using Application.DTOs.Books;
using Application.DTOs.users;
using Application.DTOs.Users;
using Application.Interfaces.ServiceInterfaces;
using Application.ResponseModel;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Filters;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly IValidator<Book> _validator;

        public AuthorController(IBookService bookService, IMapper mapper, IValidator<Book> validator)
        {
            _bookService = bookService;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpPost]
        [Route("[action]")]
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
            ResponseCore<BookCreateDTO> responseCore = new ResponseCore<BookCreateDTO>()
            {
                IsSuccess = true,
                Result = result
            };
            return Ok(responseCore);
        }


        [HttpPut]
        [Route("[action]")]
        [ModelValidation]
        public async Task<ActionResult<ResponseCore<List<BookUpdateDTO>>>> UpdateBook([FromBody] BookUpdateDTO bookDTO)
        {
            Book book = _mapper.Map<Book>(bookDTO);
            var validationResult = _validator.Validate(book);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ResponseCore<UserUpdateDTO>(false, validationResult.Errors));
            }
            await _bookService.UpdateAsync(book);
            var result = _mapper.Map<BookUpdateDTO>(book);
            ResponseCore<BookUpdateDTO> responseCore = new ResponseCore<BookUpdateDTO>()
            {
                IsSuccess = true,
                Result = result
            };
            return Ok(responseCore);
        }



        [HttpPut]
        [Route("[action]")]
        [ModelValidation]
        public async Task<ActionResult<ResponseCore<bool>>> DeleteBook(Guid Id)
        {
            Book book = await _bookService.Get(Id);
            if (book == null)
            {
                return new ResponseCore<bool>() { Result = false };
            }
            await _bookService.DeleteAsync(book);
            return new ResponseCore<bool>() { Result = true };
        }
    }
}
