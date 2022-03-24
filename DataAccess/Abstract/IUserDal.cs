using Core.DataAccess;
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IBaseRepository<User>
    {
        Task<List<OperationClaim>> GetClaims(User user);
    }
}
