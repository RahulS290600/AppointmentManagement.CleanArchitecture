using AppointmentManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Domain
{
    public class Appointment : BaseEntity
    {
        public int AppointmentId { get; set; }
        public string VisitorName { get; set; } = string.Empty;
        public string Consultant { get; set; } = string.Empty ;
        public DateTime Date { get; set; }
    }
}
