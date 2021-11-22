using System;

namespace voresgruppe.ThirdSemesterExamBackend.Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}