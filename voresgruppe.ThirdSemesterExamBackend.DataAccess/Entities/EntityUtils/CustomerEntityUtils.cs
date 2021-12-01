using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils
{
    public class CustomerEntityUtils
    {
        public Customer EntityToCustomer(CustomerEntity entity)
        {
            Customer customer = new Customer
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber
            };

            return customer;
        }
    }
}