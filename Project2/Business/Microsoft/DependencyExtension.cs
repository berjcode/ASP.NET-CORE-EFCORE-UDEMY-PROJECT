using Business.Interfaces;
using Business.Services;
using DataAcces.Context;
using DataAcces.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkServices, WorkService>();
        }
    }
}
