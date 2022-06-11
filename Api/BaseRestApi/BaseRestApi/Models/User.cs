using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseRestApi.Models
{
    public class User
    {
        public int ID {get;set;}
        public string Username {get;set;}  = string.Empty;
        public string PasswordHash {get;set;} = string.Empty;
        public string PasswordSalt {get;set;} = string.Empty;
        public string Firstname {get;set;} = string.Empty;
        public string Lastname {get;set;} = string.Empty;
        public string Phone {get;set;} = string.Empty;
        public string Img_profile {get;set;} = string.Empty;
        public DateTime Create_at {get;set;} 
        public DateTime Update_at {get;set;} 
        public int Purchase_order {get;set;} = 0;
        public int Total_sales {get;set;} = 0;
        public virtual Branch? Branch { get; set; }
    }
}