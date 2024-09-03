using AppointmentManagement.Application.Contracts.Persistance;
using AppointmentManagement.Persistence.DatabaseContext;
using AppointmentManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppointmentDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AppointmentManagementConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
