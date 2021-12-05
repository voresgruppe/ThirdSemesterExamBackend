using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils
{
    public class AppointmentEntityUtils
    {
        private readonly MainDbContext _ctx;
        private EmployeeEntityUtils _employeeEntityUtils = new();
        private CustomerEntityUtils _customerEntityUtils = new();
        public AppointmentEntityUtils(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public Appointment EntityToAppointment(AppointmentEntity entity)
        {

            Appointment appointment = new Appointment()
            {
                Id = entity.Id,
                //CustomerId = entity.CustomerId,
                AppointmentTime = entity.AppointmentTime.ToString(),
                //EmployeeId = entity.EmployeeId,
                Employee = _employeeEntityUtils.EntityToAdmin(_ctx.Employee.Find(entity.EmployeeId)),
                Customer = _customerEntityUtils.EntityToCustomer(_ctx.Customer.Find(entity.CustomerId))
            };

            return appointment;
        }
    }
}