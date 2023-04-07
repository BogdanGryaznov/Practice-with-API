using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApiShop2Context repositoryContext) : base(repositoryContext) 
        {

        }
    }
}
