using EvaluacionAdvanced.Data.Context;
using EvaluacionAdvanced.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionAdvanced.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUserByIdAsync(int pUserID)
        {
            return await _userRepository.GetUserByIdAsync(pUserID);
        }
        public async Task<User> GetUserByUserNameAsync(string pUserName)
        {
            return await _userRepository.GetUserByUserNameAsync(pUserName);
        }
        public async Task<IEnumerable<User>> ListUserAsync()
        {
            return await _userRepository.ListUserAsync();
        }
        public async Task<User> Insert(User pUser)
        {
            return await _userRepository.Insert(pUser);
        }
        public async Task<User> Update(User pUser)
        {
            return await _userRepository.Update(pUser);
        }
    }
}
