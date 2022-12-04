using Common.ResponseObject;
using Dtos.Interfaces;
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
        Task<IResponse<List<WorkListDto>>> GetAll();
        Task <IResponse<WorkCreateDto>> Create(WorkCreateDto dto);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Remove(int id);
        Task <IResponse<WorkUpdateDto>> Update (WorkUpdateDto dto);

        //ResponseObject olmadan
        //Task<List<WorkListDto>> GetAll();
        //Task Create(WorkCreateDto dto);
        //Task<IDto> GetById<IDto>(int id);
        //Task Remove(int id);
        //Task Update(WorkUpdateDto dto);
    }
}
