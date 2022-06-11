using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseRestApi.Data.Interface;
using BaseRestApi.DTO;
using BaseRestApi.Services.Interface;
using BaseRestApi.Utility;
using BaseRestApi.Utility.Interface;
using Microsoft.Extensions.Options;

namespace BaseRestApi.Services
{
    public class UserService : IUserService
    {

        private AppSettings AppSettings { get; }
        private ITrace Trace { get; }
        private ILogger<UserService> Logger { get; }
        private IUserRepository UserRepository { get; }
        private IBranchRepository BranchRepository { get; }

        public UserService(AppSettings appSettingsAccessor, ITrace trace, ILogger<UserService> logger, IUserRepository UserRepository)
        {
            this.AppSettings = appSettingsAccessor;
            this.Trace = trace;
            this.Logger = logger;
            this.UserRepository = UserRepository;
        }

        public Result<string> CreateUser(UserDto user)
        {
            Console.WriteLine("TESTTTTTTTTTTTTTTTTTTTTTTT");

            Result<string> result = new Result<string>(Trace);
            bool isHaveBranch = UserRepository.CheckBranchById(user.Branch.ID);
            if (!isHaveBranch)
            {
                result.Message = "Branch Id นี้ ไม่มีข้อมูล";
            }
            else
            {
                UserRepository.CreateUser(user);
                result.Success = true;
                result.Message = AppSettings?.SuccessMessage?.CreateSuccess!;
            }
            return result;
        }

        public Result<string> EditUser(UserDto user)
        {
            Result<string> result = new Result<string>(Trace);
            bool isHaveUser = UserRepository.CheckUserById(user.ID.Value);
            bool isHaveBranch = UserRepository.CheckBranchById(user.Branch.ID);

            if(!isHaveUser)
            {
                result.Message = AppSettings?.ErrorMessage?.EmptyUserId!;
            }
            else if(!isHaveBranch)
            {
                result.Message = "Branch Id นี้ ไม่มีข้อมูล";
            }
            else
            {
                UserRepository.EditUser(user);
                result.Success = true;
                result.Message = AppSettings?.SuccessMessage?.ModifySuccess!;
            }
            return result;
        }

        public Result<string> DeleteUser(int userId)
        {
            Result<string> result = new Result<string>(Trace);
            bool isHaveUser = UserRepository.CheckUserById(userId);
            if (!isHaveUser)
            {
                result.Message = AppSettings.ErrorMessage.EmptyUserId;
            }
            else
            {
                UserRepository.DeleteUser(userId);
                result.Success = true;
                result.Message = AppSettings.SuccessMessage.DeleteSuccess;
            }
            return result;
        }

        public Result<List<UserDto>> GetUser()
        {
            Result<List<UserDto>> result = new Result<List<UserDto>>(Trace);
            List<UserDto> createResult = UserRepository.GetUser();
            result.Success = true;
            result.Message = AppSettings?.SuccessMessage?.GetSuccess!;
            result.Data = createResult;
            return result;
        }


    }
}