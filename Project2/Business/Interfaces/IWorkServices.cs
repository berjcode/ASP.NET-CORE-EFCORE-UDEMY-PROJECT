using Dtos.WorkDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
     public interface IWorkServices
    {
        Task<List<WorkListDto>> GetAll();
        Task Create(WorkCreateDto dto);
        Task<WorkListDto> GetById(object id);
        Task Remove(object id);
        Task Update (WorkUpdateDto dto);
    }
}
