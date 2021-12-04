using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Core.IServices
{
    public interface IAppointmentService
    {
        public List<Appointment> GetAll();
        public Appointment GetById(int id);

        public List<Appointment> GetByCustomerId(int customerId);
        public List<Appointment> GetByEmployeeId(int id);
        bool DeleteAppointmentById(int id);
        Appointment CreateAppointment(Appointment app);
        Appointment UpdateAppointment(int id, Appointment app);
    }
}