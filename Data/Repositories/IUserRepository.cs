using EvaluacionAdvanced.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionAdvanced.Data.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int pUserID);
        Task<User> GetUserByUserNameAsync(string pUserName);
        Task<IEnumerable<User>> ListUserAsync();
        Task<User> Insert(User pUser);
        Task<User> Update(User pUser);
    }
}
