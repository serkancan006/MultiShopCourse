using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDataServiceExtension(this IServiceCollection services)
        {
            // DbServices
            services.AddDbContext<CargoContext>();
            // services
            services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
            services.AddScoped<ICargoCompanyService, CargoCompanyManager>();

            services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
            services.AddScoped<ICargoDetailService, CargoDetailManager>();

            services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
            services.AddScoped<ICargoCustomerService, CargoCustomerManager>();

            services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();
            services.AddScoped<ICargoOperationService, CargoOperationManager>();
        }
    }
}
