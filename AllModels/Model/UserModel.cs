using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.Model
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        
        
    }
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
