namespace WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AuthorController : ApiBaseController<Author>
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService, IMapper mapper, IValidator<Author> validator) : base(mapper, validator)
    {
        _authorService = authorService;
    }


    [HttpPost("[action]")]
    [Authorize(Roles = "CreateAuthor")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<List<AuthorCreateDTO>>>> CreateAuthor([FromBody] AuthorCreateDTO authorDto)
    {
        Author author = _mapper.Map<Author>(authorDto);
        var validationResult = _validator.Validate(author);
        if (!validationResult.IsValid)
        {
            return BadRequest(new ResponseCore<UserCreateDTO>(false, validationResult.Errors));
        }
        await _authorService.AddAsync(author);
        var result = _mapper.Map<AuthorCreateDTO>(author);
        ResponseCore<AuthorCreateDTO> ResponseCoreCore = new ResponseCore<AuthorCreateDTO>()
        {
            IsSuccess = true,
            Result = result
        };
        return Ok(ResponseCoreCore);
    }


    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles = "UpdateAuthor")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<List<AuthorUpdateDTO>>>> UpdateAuthor([FromBody] AuthorUpdateDTO authorDto)
    {
        Author author = _mapper.Map<Author>(authorDto);
        var validationResult = _validator.Validate(author);
        if (!validationResult.IsValid)
        {
            return BadRequest(new ResponseCore<AuthorUpdateDTO>(false, validationResult.Errors));
        }
        await _authorService.UpdateAsync(author);
        var result = _mapper.Map<AuthorUpdateDTO>(author);
        ResponseCore<AuthorUpdateDTO> ResponseCoreCore = new ResponseCore<AuthorUpdateDTO>()
        {
            IsSuccess = true,
            Result = result
        };
        return Ok(ResponseCoreCore);
    }


    [HttpDelete]
    [Route("[action]")]
    [Authorize(Roles = "DeleteAuthor")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<bool>>> DeleteAuthor(Guid Id)
    {
        Author? author = await _authorService.GetAsync(Id);
        if (author == null)
        {
            return BadRequest(new ResponseCore<bool>() { Result = false, Errors = "Author not found" });
        }
        var result = await _authorService.DeleteAsync(author);
        return Ok(new ResponseCore<bool>() { Result = result });
    }



    [HttpGet]
    [Route("[action]")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<AuthorGetDTO>>> GetAuthor(Guid Id)
    {
        Author? author = await _authorService.GetAsync(Id);
        if (author == null)
        {
            return BadRequest(new ResponseCore<AuthorGetDTO>() { IsSuccess = false, Errors = "Author not found" });
        }
        AuthorGetDTO authorGetDto = _mapper.Map<AuthorGetDTO>(author);
        return Ok(new ResponseCore<AuthorGetDTO>() { IsSuccess = true, Result = authorGetDto });

    }


    [HttpGet("[action]")]
    [ModelValidation]
    public async Task<ActionResult<ResponseCore<PaginatedList<AuthorGetDTO>>>> GetAllAuthor(int pageSize = 10, int pageIndex = 1)
    {
        List<AuthorGetDTO> authorGetDtos = _mapper.Map<List<AuthorGetDTO>>(await _authorService.GetAllAsync());
        PaginatedList<AuthorGetDTO> paginatedList = PaginatedList<AuthorGetDTO>.CreateAsync(authorGetDtos, pageSize, pageIndex);
        return Ok(new ResponseCore<PaginatedList<AuthorGetDTO>>() { IsSuccess = true, Result = paginatedList });
    }



    [HttpGet("[action]")]
    public async Task<ActionResult<ResponseCore<PaginatedList<AuthorGetDTO>>>> SearchingAuthor(int pageSize = 10, int pageIndex = 1)
    {
        List<AuthorGetDTO> authorGetDtos = _mapper.Map<List<AuthorGetDTO>>(await _authorService.GetAllAsync());
        PaginatedList<AuthorGetDTO> paginatedList = PaginatedList<AuthorGetDTO>.CreateAsync(authorGetDtos, pageSize, pageIndex);
        return Ok(new ResponseCore<PaginatedList<AuthorGetDTO>>() { IsSuccess = true, Result = paginatedList });
    }
}
