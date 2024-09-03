using AppointmentManagement.Application.Contracts.Persistance;
using AppointmentManagement.Domain;
using AppointmentManagement.Persistence.DatabaseContext;

namespace AppointmentManagement.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppointmentDatabaseContext context) : base(context)
        {

        }
    }
}
