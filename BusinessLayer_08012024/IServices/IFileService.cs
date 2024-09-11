using Microsoft.AspNetCore.Http;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.IServices
{
    public interface IFileService
    {
       Task AddFileUpLoad(IFormFile[] file,Guid proId);
    }
}
