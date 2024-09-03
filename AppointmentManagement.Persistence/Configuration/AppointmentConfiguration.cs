using AppointmentManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Persistence.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasData(
                new Appointment
                {
                    AppointmentId = 1,
                    VisitorName = "John Doe",
                    Consultant = "Toni Kroos",
                    Date = new DateTime(2024, 09, 10, 14, 30, 0),
                    PhoneNumber = "9234567890",
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now
                });
        }
    }
}
