using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Users.Queries
{
    public class GetAllUserQuery : IRequest<IDataResult<IEnumerable<User>>>
    {
    }

    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IDataResult<IEnumerable<User>>>
    {
        private readonly IUserDal _userDal;

        public GetAllUserQueryHandler(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IDataResult<IEnumerable<User>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {

            var users = await _userDal.GetListAsync();
            return new SuccessDataResult<IEnumerable<User>>(users, Messages.Listed);
        }
    }
}
