﻿using AutoMapper;
using Business.Interfaces;
using Business.Mappings;
using Business.Services;
using Business.ValidationRules;
using DataAcces.Context;
using DataAcces.UnitOfWork;
using Dtos.WorkDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Microsoft
{
    public static class DependencyExtension
    {

        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ToDoContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\ProjectModels;database=ToDoApp;integrated security =true;");
                opt.LogTo(Console.WriteLine, LogLevel.Information); 
            });


            //AutoMapper
            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkServices, WorkService>();

            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>,WorkUpdateDtoValidator>();


         
    }
    }
}
