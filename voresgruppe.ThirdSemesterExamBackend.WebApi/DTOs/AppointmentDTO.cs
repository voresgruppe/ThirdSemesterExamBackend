using System;

namespace voresgruppe.ThirdSemesterExamBackend.WebApi.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
        
        public int EmployeeId { get; set; }
        
        public String AppointmentTime { get; set; }
    }
}