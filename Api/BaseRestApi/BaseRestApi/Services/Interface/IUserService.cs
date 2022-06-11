using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseRestApi.DTO;

namespace BaseRestApi.Services.Interface
{
    public interface IUserService
    {
        Result<List<UserDto>> GetUser();
        Result<string> CreateUser(UserDto user);
        Result<string> EditUser(UserDto user);
        Result<string> DeleteUser(int userId);

    }
}