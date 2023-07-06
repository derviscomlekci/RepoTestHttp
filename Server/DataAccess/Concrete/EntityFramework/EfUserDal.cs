using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, SqlServerContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using (var context = new SqlServerContext())
            {
                var result = from u in context.Users
                             select new UserDetailDto { CountNumber = u.CounterNumber };

                return result.ToList();

            }
        }
    }
}
