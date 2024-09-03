using AppointmentManagement.Application.Contracts.Persistance;
using AppointmentManagement.Domain;
using AppointmentManagement.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Persistence.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppointmentDatabaseContext context) : base(context)
        {
            
        }
    }
}
