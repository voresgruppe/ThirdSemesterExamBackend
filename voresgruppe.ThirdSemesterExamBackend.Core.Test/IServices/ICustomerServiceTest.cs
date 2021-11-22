using System.Collections.Generic;
using Moq;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.Core.Test.IServices
{
    public class ICustomerServiceTest
    {
        [Fact]
        public void ICustomerService_IsAvailable()
        {
            ICustomerService service = new Mock<ICustomerService>().Object;
            Assert.NotNull(service);
        }

        [Fact]
        public void GetCustomers_WithNoParam_ReturnsListOfAllCustomers()
        {
            Mock<ICustomerService> mock = new Mock<ICustomerService>();
            List<Customer> fakeList = new List<Customer>();
            mock.Setup(s => s.GetCustomers())
                .Returns(fakeList);

            ICustomerService service = mock.Object;
            Assert.Equal(fakeList, service.GetCustomers());
        }
    }
}