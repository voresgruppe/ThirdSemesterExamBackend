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
                Customer = customerEntityUtils.EntityToCustomer(entity.Customer),
                AppointmentTime = entity.AppointmentTime,
            };

            return appointment;
        }
    }
}