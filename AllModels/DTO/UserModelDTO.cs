using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModels.DTO
{
    public class UserModelDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginModelDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
