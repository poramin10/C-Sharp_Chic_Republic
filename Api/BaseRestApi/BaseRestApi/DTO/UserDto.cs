using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseRestApi.DTO
{
    public class UserDto
    {
        public int? ID {get;set;}
        public string? Username {get;set;}
        public string? PasswordHash {get;set;}
        public string? PasswordSalt {get;set;}
        public string? Firstname {get;set;}
        public string? Lastname {get;set;}
        public string? Phone {get;set;}
        public string? Img_profile {get;set;}
        public DateTime Create_at {get;set;} 
        public DateTime Update_at {get;set;} 
        public int Purchase_order {get;set;}
        public int Total_sales {get;set;}
        public virtual BranchDto Branch { get; set; }
    }
}