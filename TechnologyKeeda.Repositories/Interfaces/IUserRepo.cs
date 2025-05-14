using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyKeeda.Entity;

namespace TechnologyKeeda.Repositories.Interfaces
{
    public interface IUserRepo
    {
        Task Register(UserInfo userInfo);
        Task<UserInfo> GetUserInfo(string username,string password);
    }
}
