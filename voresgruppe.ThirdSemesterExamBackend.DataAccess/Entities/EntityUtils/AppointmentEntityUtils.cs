using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils
{
    public class AppointmentEntityUtils
    {
        public Appointment EntityToAppointment(AppointmentEntity entity)
        {
            CustomerEntityUtils customerEntityUtils = new CustomerEntityUtils();
            
            Appointment appointment = new Appointment()
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                AppointmentTime = entity.AppointmentTime,
            };

            return appointment;
        }
    }
}