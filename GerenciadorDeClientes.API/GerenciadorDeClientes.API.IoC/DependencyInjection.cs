using GerenciadorDeClientes.API.Application.Mappings;
using GerenciadorDeClientes.API.Application.Services;
using GerenciadorDeClientes.API.Application.Services.Interface;
using GerenciadorDeClientes.API.Domain.Repositories;
using GerenciadorDeClientes.API.Infra.Data.Context;
using GerenciadorDeClientes.API.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GerenciadorDeClientes.API.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IClientRepository, ClientRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDTOMapping));
            services.AddScoped<IClientService, ClientService>();
            return services;
        }
    }
}
