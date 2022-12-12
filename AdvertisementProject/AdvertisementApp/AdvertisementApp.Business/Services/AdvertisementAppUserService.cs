using AdvertisementApp.Business.Extensions;
using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Common;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.Dtos;
using AdvertisementApp.Dtos.Interfaces;
using AdvertisementApp.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.Services
{
    public class AdvertisementAppUserService: IAdvertisementAppUserService
    {

        private readonly IUnitOfWork _uow;
        private readonly IValidator<AdvertisementAppUserCreateDto> _advertisementAppUserCreateDto;
        private readonly IMapper _mapper;


        public AdvertisementAppUserService(IUnitOfWork uow, IValidator<AdvertisementAppUserCreateDto> advertisementAppUserCreateDto, IMapper mapper)
        {
            _uow = uow;
            _advertisementAppUserCreateDto = advertisementAppUserCreateDto;
            _mapper = mapper;
        }

        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _advertisementAppUserCreateDto.Validate(dto);
              
                    if(result.IsValid)
                    {
                //daha önce başvurma kontorlü
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilter(x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);
                if (control == null)
                {
                    var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
                    await _uow.SaveChangesAsync();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }

                List<CustomValidationError> errors = new List<CustomValidationError> { new CustomValidationError { ErrorMessage = "Daha önce başvuru yapılmıştır.", PropertyName = " " } };

                return new Response<AdvertisementAppUserCreateDto>(dto,errors);

                    }
                return new Response<AdvertisementAppUserCreateDto>(dto,result.ConvertToCustomValidatonError());

                
        }

        //create ettiğimiz nesneyi dön

        public async Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query =_uow.GetRepository<AdvertisementAppUser>().GetQuery();

            var list = await query.Include(x => x.Advertisement).Include(x => x.AdvertisementAppUserStatus).Include(x => x.MilitaryStatus).Include(x => x.AppUser).ThenInclude(x=>x.Gender).Where(x => x.AdvertisementAppUserStatusId == (int)type).ToListAsync();
            return _mapper.Map<List<AdvertisementAppUserListDto>>(list);
        }


        public async Task SetStatus(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();

            var entity = await query.SingleOrDefaultAsync(x=>x.Id == advertisementAppUserId);

            entity.AdvertisementAppUserStatusId = (int)type;

            await _uow.SaveChangesAsync();
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uow.GetRepository<AdvertisementAppUser>().FindAsync(id);
            if (data == null)
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye sahip data bulunamadı.");
            _uow.GetRepository<AdvertisementAppUser>().Remove(data);
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }
    }
}
