using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            return await _userDal.GetClaims(user);
        }

        public async Task<User> Add(User user)
        {
           var result = await _userDal.AddAsync(user);

           return result;
        }

        public async Task<User> GetByMail(string email)
        {
            return await _userDal.GetAsync(u => u.Email == email);
        }
    }
}
