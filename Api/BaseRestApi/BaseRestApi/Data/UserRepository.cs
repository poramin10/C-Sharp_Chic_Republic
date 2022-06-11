using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseRestApi.Data.Interface;
using BaseRestApi.DTO;
using BaseRestApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BaseRestApi.Data
{
    public class UserRepository : IUserRepository
    {
        private BaseRestApiContext Context { get; }

        public UserRepository(BaseRestApiContext Context)
        {
            this.Context = Context;
        }

        public List<UserDto> GetUser()
        {
            List<UserDto> userList = Context.Users.Include(u => u.Branch)
                .Select((user) =>
                    new UserDto
                    {
                        ID = user.ID,
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        Username = user.Username,
                        Img_profile = user.Img_profile,
                        Phone = user.Phone,
                        Branch = new BranchDto
                        {
                            ID = user.Branch.ID,
                            Namebranch = user.Branch.Namebranch,
                        }
                    }
                ).ToList();
            return userList;
        }

        public void CreateUser(UserDto user)
        {
            Branch selectedBranch = Context.Branchs.Where(Branch => Branch.ID == user.Branch.ID).FirstOrDefault();
            User newUser = new User
            {
                Username = user.Username!,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                PasswordHash = user.PasswordHash,
                Img_profile = user.Img_profile,
                Phone = user.Phone,
                Create_at = user.Create_at,
                Update_at = user.Update_at,
                Purchase_order = user.Purchase_order,
                Total_sales = user.Total_sales,
                Branch = selectedBranch
            };

            Context.Users.Add(newUser);
            Context.SaveChanges();
        }

        public void EditUser(UserDto editUser)
        {
            User currentUser = Context.Users.Where(user => user.ID == editUser.ID).FirstOrDefault();
            Branch branchEdit = Context.Branchs.Where(branch => branch.ID == editUser.Branch.ID).FirstOrDefault();

            if (editUser.Firstname != "")
            {
                currentUser.Firstname = editUser.Firstname;
            }

            if (editUser.Lastname != "")
            {
                currentUser.Lastname = editUser.Lastname;
            }

            if (editUser.Phone != "")
            {
                currentUser.Phone = editUser.Phone;
            }

            if(editUser.Img_profile != ""){
                currentUser.Img_profile = editUser.Img_profile;
            }

            // if (editUser.PasswordHash != "")
            // {
            //     currentUser.PasswordHash = editUser.PasswordHash;
            // }


            currentUser.Branch = branchEdit;

          


            Context.SaveChanges();

        }

        public void DeleteUser(int userId)
        {

            User currentUser = Context.Users.Where(user => user.ID == userId).FirstOrDefault();
            Context.Users.Remove(currentUser);
            Context.SaveChanges();
        }

        public bool CheckUserById(int userId)
        {
            return Context.Users.Any(User => User.ID == userId);
        }

        public bool CheckBranchById(int branchId)
        {
            return Context.Branchs.Any(Branch => Branch.ID == branchId);
        }

    }
}