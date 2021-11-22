using System.Collections.Generic;
using System.IO;
using Moq;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;
using voresgruppe.ThirdSemesterExamBackend.Domain.Services;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.Test.Services
{
    public class CustomerServiceTest
    {
        [Fact]
        public void CustomerService_IdICustomerService()
        {
            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();
            CustomerService service = new CustomerService(mock.Object);
            Assert.True(service is ICustomerService);
        }

        [Fact]
        public void CustomerService_WithNullCustomerRepository_ThrowsInvalidDataExeption()
        {
            Assert.Throws<InvalidDataException>(() => new CustomerService(null));
        }

        [Fact]
        public void GetCustomers_CallsCustomerRepositoriesFindAll_ExactlyOnce()
        {
            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();
            CustomerService service = new CustomerService(mock.Object);
            service.GetCustomers();
            mock.Verify(r => r.FindAll(), Times.Once);
        }

        [Fact]
        public void GetCustomers_NoFilter_ReturnsListOfAllCustomers()
        {
            List<Customer> expected = new List<Customer>
            {
                new Customer {Id = 1, Name = "Joe", Email = "joemåge@gmail.com", PhoneNumber = "10203040"},
                new Customer {Id = 2, Name = "Mark", Email = "marksoccerberk@facebok.com", PhoneNumber = "66666666"}
            };
            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();
            mock.Setup(r => r.FindAll())
                .Returns(expected);
            CustomerService service = new CustomerService(mock.Object);
            Assert.Equal(expected,service.GetCustomers());
        }
    }
}