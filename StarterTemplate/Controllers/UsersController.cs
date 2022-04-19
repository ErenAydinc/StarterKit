using Business.Abstract;
using Business.Handlers.Users.Commands;
using Business.Handlers.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StarterTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        #endregion

        #region Ctor

        public UsersController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        #endregion

        #region Methods

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _mediator.Send(new GetAllUserQuery());
            if (users.Success)
                return Ok(users);
            else
                return BadRequest();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery{ Id = id});
            if (user.Success)
                return Ok(user);
            else
                return BadRequest();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var create = await _mediator.Send(createUserCommand);
            if (create.Success)
                return Ok(create);
            else
                return BadRequest(create);
        }

        #endregion

    }
}
