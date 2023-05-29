using Application.DTOs.Users;
using Application.ResponseModel;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Application.Interfaces.ServiceInterfaces;
using WebUI.Filters;
using Application.Models;
using Application.Extentions;
using Infrastructure.Services;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using FluentValidation;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class UserController : ControllerBase
    {
        protected readonly IValidator<User> _validator;

        protected IMapper _mapper => HttpContext.RequestServices.GetRequiredService<IMapper>();

        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService,ITokenService tokenService, IValidator<User> validator)
        {
            _userService = userService;
            _tokenService = tokenService;
            _validator = validator;
        }

        [HttpPost]
        [Route("CreateUser")]
      //  [ModelValidationAttribute]
      //  [AllowAnonymous]
        public async Task<ActionResult<Response<UserCreateDTO>>> CreateUser([FromBody] UserCreateDTO userDto)
        {
            userDto.Password = userDto.Password.stringHash()!;
            User user = _mapper.Map<User>(userDto);
            var validationResult = _validator.Validate(user);

            if (!validationResult.IsValid)
            {
                return BadRequest(new Response<UserCreateDTO>(false, validationResult.Errors));
            }
            User resultUser = await _userService.AddAsync(user);
            UserCreateDTO result = _mapper.Map<UserCreateDTO>(resultUser);
            return Ok(new Response<UserCreateDTO>() { IsSuccess = true, Result = result });
        }


        [HttpPost("[action]")]
        [ModelValidationAttribute]
        [AllowAnonymous]
        public async Task<ActionResult<Response<Token>>> LoginUser([FromBody] UserCredential userCredential)
        {
            userCredential.Password = userCredential.Password.stringHash()!;
            User? user = (await _userService.GetAll(x => true)).FirstOrDefault(x=>x.Password == userCredential.Password);
            if (user==null)
            {
                return BadRequest(new Response<UserCreateDTO>(false, "User not found"));
            }
            Token token = new()
            {
                AccessToken = await _tokenService.CreateAccesToken(user!),
                RefreshToken = await _tokenService.CreateRefreshAccesToken(user!)
            };
            return Ok(new Response<Token>() { IsSuccess = true, Result = token });
        }
    }
}
