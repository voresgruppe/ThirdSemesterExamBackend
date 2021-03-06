using System;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils
{
    public class AppointmentEntityUtils
    {
        public Appointment EntityToAppointment(AppointmentEntity entity)
        {

            Appointment appointment = new Appointment()
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                AppointmentTime = entity.AppointmentTime.ToString(),
                EmployeeId = entity.EmployeeId,
                HairstyleStarterId = entity.HairstyleStarterId,
                HairstyleEndId = entity.HairstyleEndId,
            };

            return appointment;
        }

        public AppointmentEntity AppointmentToEntity(Appointment appointment)
        {
            return new AppointmentEntity()
            {
                Id = appointment.Id,
                CustomerId = appointment.CustomerId,
                AppointmentTime = DateTime.Parse(appointment.AppointmentTime),
                EmployeeId = appointment.EmployeeId,
                HairstyleStarterId = appointment.HairstyleStarterId,
                HairstyleEndId = appointment.HairstyleEndId,
            };
        }
        
        public AppointmentEntity UpdateAppointment(AppointmentEntity old, Appointment updated)
        {
            old.CustomerId = updated.CustomerId;
            old.AppointmentTime = DateTime.Parse(updated.AppointmentTime);
            old.EmployeeId = updated.EmployeeId;
            old.HairstyleEndId = updated.HairstyleEndId;
            old.HairstyleStarterId= updated.HairstyleStarterId;
            return old;
        }
    }
}