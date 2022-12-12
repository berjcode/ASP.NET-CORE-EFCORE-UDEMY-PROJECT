using AutoMapper;
using Dtos.WorkDtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappings
{
    public class WorkProfile :Profile
    {
       //AutoMapperi İndir.
        public WorkProfile() 
        { 
            CreateMap<Work, WorkListDto>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDto>().ReverseMap();

            CreateMap<WorkListDto,WorkUpdateDto>().ReverseMap(); //Listu Update Cevir.



        
        }
    }
}
