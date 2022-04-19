using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.MediatR.Command.Users
{
    public class GetAllUserQuery : IRequest<IDataResult<IEnumerable<User>>> 
    {
    }
}
