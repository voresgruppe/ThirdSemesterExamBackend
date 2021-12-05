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
            };
        }
    }
}