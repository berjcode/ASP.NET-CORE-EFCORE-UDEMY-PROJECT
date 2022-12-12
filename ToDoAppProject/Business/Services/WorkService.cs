using AutoMapper;
using Business.Extension;
using Business.Interfaces;
using Common.ResponseObject;
using DataAcces.UnitOfWork;
using Dtos.Interfaces;
using Dtos.WorkDtos;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class WorkService : IWorkServices
    {
       private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkUpdateDto> _UpdateDtoValidator;
        private readonly IValidator<WorkCreateDto> _createDtoValidator;

        public WorkService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<WorkUpdateDto> updateDtoValidator, IValidator<WorkCreateDto> createDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _UpdateDtoValidator = updateDtoValidator;
            _createDtoValidator = createDtoValidator;
        }

        // AutoMapperÖncesi
        /*
        public async Task Create(WorkCreateDto dto)
        {
            await _unitOfWork.GetRepository<Work>().Create(new()
            {
                IsCompleted = dto.IsCompleted,
                Definition = dto.Definition,
            });
            await _unitOfWork.SaveChanges();
        }*/


        //AutoMapperSonrası

        public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if(validationResult.IsValid)
            {
                await _unitOfWork.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _unitOfWork.SaveChanges();
                return new Response<WorkCreateDto>(ResponseType.Succes, dto);

            }
            else
            {


                return new Response<WorkCreateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidationError());
                  
    //            Validasyon ayrı class tutmadan önce
    //            List<CustomValidationError> errors = new();
    //            foreach(var error in validationResult.Errors)
    //            {
    //                errors.Add(new ()
    //                {
    //                    ErrorMessage =error.ErrorMessage,
    //                    PropertyName = error.PropertyName
    //});
    //            }
                //return new Response<WorkCreateDto>(ResponseType.ValidationError,dto,errors);
            }

        }


        //AutoMapperÖncesi
        /*
        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _unitOfWork.GetRepository<Work>().GetAll();
            var workList = new List<WorkListDto>();

            if (list != null && list.Count > 0)
            {
                foreach (var work in list)
                {
                    workList.Add(new()
                    {
                        Definition = work.Definition,
                        Id = work.Id,
                        IsCompleted = work.IsCompleted,
                    });
                }
            }
            return workList;
        }*/

        //AutoMapper Sonrası
        public async Task<IResponse<List<WorkListDto>>> GetAll()
        {
          var data =  _mapper.Map<List<WorkListDto>>(await _unitOfWork.GetRepository<Work>().GetAll());
            return new Response<List<WorkListDto>>(ResponseType.Succes,data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {//AutoMapper Öncesi
            /*
            var work = await _unitOfWork.GetRepository<Work>().GetByFilter(x=>x.Id==id); //frame work ramden dispose edilene kadar izler. buna bir çözüm. İzlemeden bize data dönecek.
            return new()
            {
                Definition = work.Definition,
                IsCompleted = work.IsCompleted,
            };*/

            //AutoMapper Sonrası 
            //Response Object oncesi 
           // return _mapper.Map<IDto>(await _unitOfWork.GetRepository<Work>().GetByFilter(x=> x.Id ==id));


            var data = _mapper.Map<IDto>(await _unitOfWork.GetRepository<Work>().GetByFilter(x => x.Id == id));
            if(data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait data bulunamadı.");
            }
            return new Response<IDto>(ResponseType.Succes,data);
        }

        public async Task<IResponse> Remove(int id)
        {
            //AutoMapper Öncesi

            // var deletedWork = await _unitOfWork.GetRepository<Work>().GetById(id);

           var removedEntity= await _unitOfWork.GetRepository<Work>().GetByFilter(x  => x.Id == id);
          if(removedEntity !=null )
            {
                _unitOfWork.GetRepository<Work>().Remove(removedEntity);
                 await _unitOfWork.SaveChanges();


                return new Response(ResponseType.Succes);

            }
            return new Response(ResponseType.NotFound, $" {id}' ye ait değer Bulunamadı");
        }

        public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
        {

            //AutoMapper Öncesi
            /*
            _unitOfWork.GetRepository<Work>().Update(new()
            {
                Definition = dto.Definition,
                Id = dto.Id,
                IsCompleted = dto.IsCompleted,

            });

            await _unitOfWork.SaveChanges();*/

            //AutoMapper Sonrası

            var results= _UpdateDtoValidator.Validate(dto);
            if(results.IsValid)
            {
                var updatedEntity = await _unitOfWork.GetRepository<Work>().Find(dto.Id);
                if(updatedEntity != null )
                {
                    _unitOfWork.GetRepository<Work>().Update(_mapper.Map<Work>(dto),updatedEntity);

                    await _unitOfWork.SaveChanges();
                    return new Response<WorkUpdateDto>(ResponseType.Succes,dto);
                }
                return new Response<WorkUpdateDto>(ResponseType.NotFound, $" {dto.Id}' ye ait değer Bulunamadı");

            }else
            {
                //List<CustomValidationError> errors = new();
                //foreach (var error in results.Errors)
                //{
                //    errors.Add(new()
                //    {
                //        ErrorMessage = error.ErrorMessage,
                //        PropertyName = error.PropertyName
                //    });
                //}
                return new Response<WorkUpdateDto>(ResponseType.ValidationError, dto, results.ConvertToCustomValidationError());
            }

        }
    }
}
