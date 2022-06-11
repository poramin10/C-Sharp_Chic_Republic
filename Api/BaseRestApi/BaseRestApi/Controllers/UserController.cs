using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BaseRestApi.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using BaseRestApi.Services;
using BaseRestApi.Services.Interface;
using Microsoft.Extensions.Options;
using BaseRestApi.Utility;
using BaseRestApi.Utility.Interface;

// เพิ่ม
using System.Net.Http.Headers;

namespace BaseRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserService UserService { get; }
        private ILogger<UserController> Logger { get; }
        private AppSettings AppSettings { get; }
        private ITrace Trace { get; }

        public UserController(IUserService UserService, ILogger<UserController> Logger, AppSettings AppSettings, ITrace Trace)
        {
            this.UserService = UserService;
            this.Logger = Logger;
            this.AppSettings = AppSettings;
            this.Trace = Trace;
        }

        [HttpGet]
        public Result<List<UserDto>> GetUser()
        {
            Result<List<UserDto>> result;
            result = UserService.GetUser();
            return result;
        }

        [HttpPost]
        public Result<string> CreateUser([FromBody] UserDto newUser)
        {
            Result<string> result = new Result<string>(Trace);
            if (String.IsNullOrEmpty(newUser.Firstname))
            {
                result.Message = AppSettings?.ErrorMessage?.EmptyProductName!;
            }
            else
            {
                result = UserService.CreateUser(newUser);
            }
            return result;
        }



        [HttpPut]
        public Result<string> EditUser([FromBody] UserDto editUser)
        {
            Result<string> result = new Result<string>(Trace);
            if (editUser.ID == null)
            {
                // Console.WriteLine("เข้าแล้ววว");
                result.Message = AppSettings?.ErrorMessage?.EmptyUserId!;
            }
            else
            {
                result = UserService.EditUser(editUser);
            }
            return result;

        }

        [HttpDelete("{userId}")]
        public Result<string> DeleteUser(int? userId)
        {
            Result<string> result = new Result<string>(Trace);
            if (!userId.HasValue)
            {
                result.Message = AppSettings.ErrorMessage.EmptyUserId;
            }
            else
            {
                result = UserService.DeleteUser(userId.Value);
            }
            return result;
        }
    }
}