using AdvertisementApp.Business.Interfaces;
using AdvertisementApp.Business.Mappings.AutoMapper;
using AdvertisementApp.Business.Services;
using AdvertisementApp.Business.ValidationRules.AdvertisementServiceRules;
using AdvertisementApp.Business.ValidationRules.AppUserRules;
using AdvertisementApp.Business.ValidationRules.GenderRules;
using AdvertisementApp.Business.ValidationRules.ProvidedServiceRules;
using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        //Extension Method
        public static void AddDependencies(this IServiceCollection services)
        {
            //SQL Connection String
            services.AddDbContext<AdvertisementAppContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\ProjectModels;database=AdvertisementApp;integrated security =true;");
            });


            //Mapping
           var mapperConfigurations =  new MapperConfiguration(opt =>
           {
               // opt.AddProfile();
               opt.AddProfile(new ProvidedServiceProfile());
               opt.AddProfile(new AdvertisementProfile());
               opt.AddProfile(new AppUserProfile());
               opt.AddProfile(new GenderProfile());


            });
           
            var mapper= mapperConfigurations.CreateMapper();
            services.AddSingleton(mapper);

            //Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Provided
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateValidator>();
            //Advertisement
            services.AddTransient<IValidator<AdvertisementCreateDto> , AdvertisementCreateDtoValidator > ();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator > ();
            //AppUser
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            //Gender
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
            //Services:  Class-Interfaces
            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IAppUserService, AppUserService>();
        }
    }
}
