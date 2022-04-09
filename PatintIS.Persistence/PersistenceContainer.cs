using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatintIS.Application.Contracts;
using PatintIS.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatintIS.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PatintDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PCS")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IPatintRepository), typeof(PatintRepository));
            return services;
        }
    }
}
