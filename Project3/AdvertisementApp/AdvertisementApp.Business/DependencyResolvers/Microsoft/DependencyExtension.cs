using AdvertisementApp.Business.ValidationRules.ProvidedServiceRules;
using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.DataAccess.UnitOfWork;
using AdvertisementApp.Dtos.ProvidedServicesDtos;
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
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<AdvertisementAppContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\ProjectModels;database=AdvertisementApp;integrated security =true;");
            });

           var mapperConfigurations =  new MapperConfiguration(opt =>
           {
             // opt.AddProfile();
               ;           });
            var mapper= mapperConfigurations.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateValidator>();
        }
    }
}
