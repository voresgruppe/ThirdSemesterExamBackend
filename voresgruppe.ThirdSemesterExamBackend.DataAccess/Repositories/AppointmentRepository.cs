using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;
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
        
        public List<Appointment> FindByEmployeeId(int id)
        {
            return _ctx.Appointment
                .Where(ae => ae.EmployeeId.Equals(id))
                .Select(ae=> _appointmentEntityUtils.EntityToAppointment(ae))
                .ToList();
        }

        public bool DeleteAppointmentById(int id)
        {
            var app = _ctx.Appointment.Find(id);
            _ctx.Appointment.Remove(app);
            _ctx.SaveChanges();
            return true;
        }

        public Appointment CreateAppointment(Appointment app)
        {


            AppointmentEntity ae = _appointmentEntityUtils.AppointmentToEntity(app);
            
            _ctx.Appointment.Add(ae);
            _ctx.SaveChanges();
            return _appointmentEntityUtils.EntityToAppointment(ae);
        }

        public Appointment UpdateAppointment(int id, Appointment app)
        {
            AppointmentEntity old = _ctx.Appointment.Find(id);
            
            AppointmentEntity entity =_ctx.Appointment.Update(_appointmentEntityUtils.UpdateAppointment(old, app)).Entity;
            _ctx.SaveChanges();
            return _appointmentEntityUtils.EntityToAppointment(entity);
        }
    }
}