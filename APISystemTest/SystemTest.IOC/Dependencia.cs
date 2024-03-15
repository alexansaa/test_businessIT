using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemTest.BLL.Servicios;
using SystemTest.BLL.Servicios.Contrato;
using SystemTest.DAL.DBContext;
using SystemTest.DAL.Repositorios;
using SystemTest.DAL.Repositorios.Contrato;

using SystemTest.Utility;

namespace SystemTest.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<DbtestContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, ClienteRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IClientService, ClienteService>();
            services.AddScoped<IServicesService, ServicioService>();

            services.AddScoped<IDashBoardService, DashBoardService>();
        }
    }
}
