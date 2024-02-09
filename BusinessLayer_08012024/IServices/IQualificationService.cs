using AllModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_08012024.IServices
{
    public interface IQualificationService
    {
        Task<List<QualificationMaster>> GetAllQualification();
        Task AddQualification(QualificationMaster qualificationMaster);
        Task<QualificationMaster> UpdateQualication(QualificationMaster qualificationMaster);
        Task<QualificationMaster> DeleteQyalication(Guid id);
        
    }
}
