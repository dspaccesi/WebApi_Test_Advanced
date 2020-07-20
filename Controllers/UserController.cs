using AutoMapper;
using EvaluacionAdvanced.Data.Context;
using EvaluacionAdvanced.Data.Repository;
using EvaluacionAdvanced.DataTransferObject;
using EvaluacionAdvanced.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EvaluacionAdvanced.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
            
        }

        [HttpGet("{id}")]
        public async Task<DTO_User> GetUserByIDAsync(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                var response = _mapper.Map<User, DTO_User>(user);
                return response;
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        [HttpGet]
        public async Task<IEnumerable<DTO_User>> GetAllAsync()
        {
            try
            {
                var listUser = await _userService.ListUserAsync();
                var response = _mapper.Map<IEnumerable<User>, IEnumerable<DTO_User>>(listUser);
                return response;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertUserAsync([FromBody] DTO_User userDto)
        {
            try
            {
                var userByUserName = await _userService.GetUserByUserNameAsync(userDto.UserName);
                if (userByUserName != null)
                {
                    return Conflict("The entered user name already exist.");
                }
                var userToInsert = _mapper.Map<DTO_User, User> (userDto);
                var userCreated = await _userService.Insert(userToInsert);
                var response = _mapper.Map<User, DTO_User>(userCreated);
                return Ok(response);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPut]
        public async Task<DTO_User> EditUserAsync([FromBody] DTO_User userDto)
        {
            try
            {
                var userToUpdate = _mapper.Map<DTO_User, User>(userDto);
                var userUpdated = await _userService.Update(userToUpdate);
                var response = _mapper.Map<User, DTO_User>(userUpdated);
                return response;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        [HttpDelete]
        public async Task<DTO_User> DeleteUserAsync([FromBody] DTO_User userDto)
        {
            try
            {
                var userToDelete = _mapper.Map<DTO_User, User>(userDto);
                var userEntitytoDelete = await _userService.GetUserByIdAsync(userDto.UserID);
                userEntitytoDelete.Active = false;
                var userDeleted = await _userService.Update(userEntitytoDelete);
                var response = _mapper.Map<User, DTO_User>(userDeleted);
                return response;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
