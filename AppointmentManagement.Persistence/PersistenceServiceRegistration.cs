using Microsoft.Extensions.DependencyInjection;

namespace AppointmentManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
