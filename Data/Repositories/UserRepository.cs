using EvaluacionAdvanced.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionAdvanced.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }
        protected readonly DataContext _context;

        public async Task<User> GetUserByIdAsync(int pUserID)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.UserId == pUserID);
        }
        public async Task<User> GetUserByUserNameAsync(string pUserName)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.UserName == pUserName);
        }
        public async Task<IEnumerable<User>> ListUserAsync()
        {
            return await _context.User.Where(x => x.Active).ToListAsync();
        }
        public async Task<User> Insert(User pUser)
        {
            _context.Add(pUser);
            await _context.SaveChangesAsync();
            return pUser;
        }
        public async Task<User> Update(User pUser)
        {
            _context.Entry(pUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return pUser;
        }
        
    }
}
