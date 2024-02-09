using AllModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.IServices
{
    public interface IEnquiryService
    {
        Task<List<Enquiry>> GetEnquiryList();
        Task AddNewEnquiry(Enquiry enquiry);
        Task UpdateEnquiry(Enquiry enquiry);
        Task<Enquiry> DeleteEnquiry(Guid id);
    }
}
