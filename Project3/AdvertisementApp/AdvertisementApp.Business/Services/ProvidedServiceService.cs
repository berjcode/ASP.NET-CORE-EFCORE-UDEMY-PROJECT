﻿using AdvertisementApp.Business.Interfaces;
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
    public class ProvidedServiceService : Service<ProvidedServiceCreateDto,ProvidedServiceUpdateDto,ProvidedServiceListDto,ProvidedService>,IProvidedServiceService
    {
        //DI ile Ayağa Kalkıyor

        public ProvidedServiceService(IMapper mapper, IValidator<ProvidedServiceCreateDto> createDtoValidator,IValidator<ProvidedServiceUpdateDto> updateDtoValidator,IUnitOfWork unitOfWork) :base(mapper, createDtoValidator, updateDtoValidator, unitOfWork)
        {

        }
    }
}
