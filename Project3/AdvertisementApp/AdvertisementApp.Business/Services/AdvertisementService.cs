using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Services
{
    public class AdvertisementService : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public AdvertisementService(IMapper mapper,IValidator<AdvertisementCreateDto> createDtoValidator,IValidator<AdvertisementUpdateDto> updateDtoValidator,IUnitOfWork unitOfWork) : base(mapper,createDtoValidator,updateDtoValidator, unitOfWork)
        {
            _uow= unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResponse<List<AdvertisementListDto>>> GetActiveAsync()
        {
          var data = await   _uow.GetRepository<Advertisement>().GetAllAsync(x=>x.status,x=>x.CreatedDate,Common.Enums.OrderByType.DESC);
            var dto = _mapper.Map<List<AdvertisementListDto>>(data);

            return new Response<List<AdvertisementListDto>>(ResponseType.Success,dto);
        }
    }
}
