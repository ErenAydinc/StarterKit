using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Users.Commands
{
    public class CreateUserCommand : IRequest<IResult>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IResult>
    {
        private readonly IUserDal _userDal;

        public CreateUserCommandHandler(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var isUserExist = await _userDal.GetAsync(x => x.Email == request.Email);
            if (isUserExist != null)
                return new ErrorResult(Messages.UserAlreadyExists);


            var user = new User
            {
                Email = request.Email,
                FirstName=request.FirstName,
                LastName=request.LastName,
                
            };

            await _userDal.AddAsync(user);
            return new SuccessResult(Messages.Added);

        }
    }
}
