using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseRestApi.Models
{
    public class Branch
    {
        public int ID {get;set;}
        public string? Namebranch {get;set;}
        public virtual ICollection<User>? Users { get; set; }
    }
}