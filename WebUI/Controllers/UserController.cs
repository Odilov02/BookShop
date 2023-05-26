using Application.DTOs.Users;
using Application.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public ActionResult<Response<UserCreateDTO>> Create([FromBody] UserCreateDTO  user)
        {

        }
    }
}
