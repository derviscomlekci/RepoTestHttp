using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IResult>  Add(User user)
        {
            _userDal.Add(user);
            return new SuccesResult("Added");
        }

        public async Task<IDataResult<User>> GetCount()
        {
            var result =await _userDal.GetAll();
            return new SuccessDataResult<User>(result.First());
        }

        public async Task<IResult> UpdateCount(User user)
        {
            await _userDal.Update(user);
            return new SuccesResult("updated");
        }
    }
}
