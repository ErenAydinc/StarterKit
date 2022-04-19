using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Users.Queries
{
    public class GetUserByIdQuery : IRequest<IDataResult<User>>
    {
        public int Id { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, IDataResult<User>>
    {
        private readonly IUserDal _userDal;

        public GetUserByIdQueryHandler(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IDataResult<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userDal.GetAsync(x => x.Id == request.Id);
            return new SuccessDataResult<User>(user, Messages.GetById);
        }
    }
}
