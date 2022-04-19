using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Users.Queries
{
    public class GetUserByMailQuery : IRequest<IDataResult<User>>
    {
        public string Mail { get; set; }
    }
    public class GetUserByMailQueryHandler : IRequestHandler<GetUserByMailQuery, IDataResult<User>>
    {
        private readonly IUserDal _userDal;

        public GetUserByMailQueryHandler(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IDataResult<User>> Handle(GetUserByMailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userDal.GetAsync(x => x.Email == request.Mail);
            return new SuccessDataResult<User>(user, Messages.GetByMail);
        }
    }
}
