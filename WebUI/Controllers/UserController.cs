using Application.DTOs.users;
using Application.DTOs.Users;
using Application.Extentions;
using Application.Interfaces.ServiceInterfaces;
using Application.Models;
using Application.ResponseCoreModel;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.IdentityEntities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Filters;
namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ApiBaseController<User>
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public UserController(IUserService userService, ITokenService tokenService, IValidator<User> validator, IMapper mapper) : base(mapper, validator)
        {
            _userService = userService;
            _tokenService = tokenService;
        }



        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        [ModelValidation]
        public async Task<ActionResult<ResponseCore<bool>>> CreateUser([FromBody] UserCreateDTO userDto)
        {
            User user = _mapper.Map<User>(userDto);
          
            var validationResult = _validator.Validate(user);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ResponseCore<bool>(false, validationResult.Errors));
            }
            user.Password = user.Password.stringHash()!;
            await _userService.AddAsync(user);
            return Ok(new ResponseCore<bool>() { IsSuccess = true, Result = true });
        }



        [HttpPost("[action]")]
        [ModelValidation]
        [AllowAnonymous]
        public async Task<ActionResult<ResponseCore<Token>>> LoginUser([FromBody] UserCredential userCredential)
        {
            userCredential.Password = userCredential.Password.stringHash()!;
            User? user = (await _userService.GetAll()).FirstOrDefault(x => x.Password == userCredential.Password);
            if (user == null)
            {
                return BadRequest(new ResponseCore<UserCreateDTO>(false, "User not found"));
            }
            Token token = new()
            {
                AccessToken = await _tokenService.CreateAccesToken(user!),
                RefreshToken = await _tokenService.CreateRefreshAccesToken(user!)
            };
            return Ok(new ResponseCore<Token>() { IsSuccess = true, Result = token });
        }



        [HttpPut]
        [Route("[action]")]
        [ModelValidation]
        public async Task<ActionResult<ResponseCore<List<UserUpdateDTO>>>> UpdateUser(UserUpdateDTO userDto, string password, string phoneNumber)
        {
            User user = _mapper.Map<User>(userDto);
            var validationResult = _validator.Validate(user);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ResponseCore<UserUpdateDTO>(false, validationResult.Errors));
            }
            user.Password = user!.Password!.stringHash()!;

            password = password!.stringHash()!;
            User? userUpdate = (await _userService.GetAll()).Where(x => x.Password == password &&
                                                                  x.PhoneNumber == phoneNumber)
                                                                            .FirstOrDefault();
            if (userUpdate == null)
            {
                return BadRequest(new ResponseCore<bool>() { Result = false, Errors = "User not found" });
            }
            userUpdate.PhoneNumber = user.PhoneNumber;
            userUpdate.FullName = user.FullName;
            userUpdate.Password = user.Password;
            await _userService.UpdateAsync(userUpdate);
            var result = _mapper.Map<UserUpdateDTO>(userUpdate);
            ResponseCore<UserUpdateDTO> ResponseCoreCore = new ResponseCore<UserUpdateDTO>()
            {
                IsSuccess = true,
                Result = result
            };
            return Ok(ResponseCoreCore);
        }



        [HttpPut]
        [Route("[action]")]
        [Authorize(Roles = "UpdateUserForAdmin")]
        [ModelValidation]
        public async Task<ActionResult<ResponseCore<List<bool>>>> UpdateUserForAdmin(Guid Id, Guid[] RolesId)
        {
            User? user = await _userService.Get(Id);
            if (user == null)
            {
                return BadRequest(new ResponseCore<bool>() { IsSuccess = false, Errors = "User not found" });
            }
            UserGetDTO userGetDTO = _mapper.Map<UserGetDTO>(user);
            userGetDTO.RoleIds = RolesId;
            User userUpdate = _mapper.Map<User>(userGetDTO);
            var result = await _userService.UpdateAsync(userUpdate);
            return Ok(new ResponseCore<bool>() { IsSuccess = true, Result = result });
        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "GetUser")]
        [ModelValidation]
        public async Task<ActionResult<ResponseCore<UserGetDTO>>> GetUser(Guid Id)
        {
            User? user = await _userService.Get(Id);
            if (user == null)
            {
                return BadRequest(new ResponseCore<UserGetDTO>() { IsSuccess = false, Errors = "User not found" });
            }
            UserGetDTO userGetDto = _mapper.Map<UserGetDTO>(user);
            return Ok(new ResponseCore<UserGetDTO>() { IsSuccess = true, Result = userGetDto });

        }



        [HttpDelete]
        [Route("[action]")]
        [ModelValidation]
        public async Task<ActionResult<ResponseCore<bool>>> DeleteUser([FromBody] UserCredential userCredential)
        {
            userCredential.Password = userCredential!.Password!.stringHash()!;
            User? user = (await _userService.GetAll()).Where(x => x.Password == userCredential.Password &&
                                                                  x.PhoneNumber == userCredential.phoneNumber)
                                                                            .FirstOrDefault();
            if (user == null)
            {
                return BadRequest(new ResponseCore<bool>() { Result = false, Errors = "User not found" });
            }
            var result = await _userService.DeleteAsync(user);
            return Ok(new ResponseCore<bool>() { Result = result });
        }



        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "GetUser")]
        [ModelValidation]
        public async Task<ActionResult<ResponseCore<PaginatedList<UserGetDTO>>>> GetAllUser(int pageSize = 10, int pageIndex = 1)
        {
            List<UserGetDTO> userGetDtos = _mapper.Map<List<UserGetDTO>>(await _userService.GetAll());
            PaginatedList<UserGetDTO> paginatedList = PaginatedList<UserGetDTO>.CreateAsync(userGetDtos, pageSize, pageIndex);
            return Ok(new ResponseCore<PaginatedList<UserGetDTO>>() { IsSuccess = true, Result = paginatedList });
        }



        [HttpGet("Search")]
        [Authorize(Roles = "GetUser")]
        public async Task<ActionResult<ResponseCore<PaginatedList<UserGetDTO>>>> Searching(string SearchString, int pageSize = 10, int pageIndex = 1)
        {

            List<UserGetDTO> userGetDtos = _mapper.Map<List<UserGetDTO>>((await _userService.GetAll())
                                                  .Where(x => x.FullName.Contains(SearchString)));
            PaginatedList<UserGetDTO> paginatedList = PaginatedList<UserGetDTO>.CreateAsync(userGetDtos, pageSize, pageIndex);
            return Ok(new ResponseCore<PaginatedList<UserGetDTO>>() { IsSuccess = true, Result = paginatedList });
        }
    }
}
