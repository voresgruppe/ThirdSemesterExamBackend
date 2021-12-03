using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private MainDbContext _ctx;
        private AppointmentEntityUtils _appointmentEntityUtils = new AppointmentEntityUtils();

        public AppointmentRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new InvalidDataException("AppointmentRepository need a DBcontext");
        }

        public List<Appointment> FindAll()
        {
            return _ctx.Appointment
                .Select(ae => _appointmentEntityUtils.EntityToAppointment(ae))
                .ToList();
        }

        public Appointment ReadById(int id)
        {
            return _appointmentEntityUtils.EntityToAppointment(_ctx.Appointment.Find(id));
        }

        public List<Appointment> FindByCustomerId(int customerId)
        {
            return _ctx.Appointment
                .Where(ae => ae.CustomerId.Equals(customerId))
                .Select(ae=> _appointmentEntityUtils.EntityToAppointment(ae))
                .ToList();
        }
    }
}