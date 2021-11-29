using System.Collections.Generic;
using Moq;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.Core.Test.IServices
{
    public class ICustomerServiceTest
    {
        private readonly Mock<ICustomerService> _mock;
        private readonly ICustomerService _service;
        public ICustomerServiceTest()
        {
            _mock = new Mock<ICustomerService>();
            _service = _mock.Object;
        }
        
        [Fact]
        public void ICustomerService_IsAvailable()
        {
            ICustomerService service = new Mock<ICustomerService>().Object;
            Assert.NotNull(service);
        }

        [Fact]
        public void GetCustomers_WithNoParam_ReturnsListOfAllCustomers()
        {
            List<Customer> fakeList = new List<Customer>();
            _mock.Setup(s => s.GetCustomers())
                .Returns(fakeList);
            
            Assert.Equal(fakeList, _service.GetCustomers());
        }

        [Fact]
        public void GetCustomerById_ReturnsASingularCustomer()
        {
            Customer fakeCustomer = new Customer();
            fakeCustomer.Id = 1;
            _mock.Setup(s => s.GetCustomerById(1)).Returns(fakeCustomer);
            Assert.Equal(fakeCustomer,_service.GetCustomerById(1));
        }
    }
}