using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories
{
    public interface IAppointmentRepository
    {
        public List<Appointment> FindAll();
        public Appointment ReadById(int id);

        public List<Appointment> FindByCustomerId(int customerId);

        public List<Appointment> FindByEmployeeId(int id);
        bool DeleteAppointmentById(int id);
        Appointment CreateAppointment(Appointment app);
        Appointment UpdateAppointment(int id, Appointment app);
        Customer GetCustomerById(int id);
        Employee GetEmployeeById(int id);
    }
}