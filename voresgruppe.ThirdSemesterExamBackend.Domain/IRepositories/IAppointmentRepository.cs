using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories
{
    public interface IAppointmentRepository
    {
        public List<Appointment> FindAll();
        public Appointment ReadById(int id);

        public List<Appointment> FindByCustomerId(int customerId);
    }
}