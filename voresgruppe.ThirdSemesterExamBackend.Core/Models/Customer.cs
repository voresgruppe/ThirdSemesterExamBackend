using System.Collections.Generic;

namespace voresgruppe.ThirdSemesterExamBackend.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}