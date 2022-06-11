using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseRestApi.DTO;


namespace BaseRestApi.Data.Interface
{
    public interface IUserRepository
    {
        List<UserDto> GetUser();
        void CreateUser (UserDto user);
        void EditUser (UserDto editUser);
        void DeleteUser (int userId);
        bool CheckUserById(int userId);
        bool CheckBranchById(int branchId);
    }
}