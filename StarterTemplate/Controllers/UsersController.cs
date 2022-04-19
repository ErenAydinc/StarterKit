using Business.Abstract;
using Business.MediatR.Command.Users;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public UsersController(IMediator mediator,IUserService userService)
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
            if (users!=null)
            {
              return Ok(users);
            }
            return BadRequest();
        }
        #endregion

    }
}
