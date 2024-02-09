using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriMonialGlobalExceptionHandling_03022024.Utility.Exceptions
{
    public class BadRequestException:Exception
    {
        public BadRequestException(string message):base(message)
        {
            
        }
    }
}
