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
        private readonly Mock<ICustomerRepository> _mock;
        private readonly CustomerService _service;
        private readonly List<Customer> _expected;

        public CustomerServiceTest()
        {
            _mock = new Mock<ICustomerRepository>();
            _service = new CustomerService(_mock.Object);
            
            _expected = new List<Customer>
            {
                new Customer {Id = 1, Name = "Joe", Email = "joemåge@gmail.com", PhoneNumber = "10203040"},
                new Customer {Id = 2, Name = "Mark", Email = "marksoccerberk@facebok.com", PhoneNumber = "66666666"}
            };
        }
        
        [Fact]
        public void CustomerService_IdICustomerService()
        {
            Assert.True(_service is ICustomerService);
        }

        [Fact]
        public void CustomerService_WithNullCustomerRepository_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new CustomerService(null));
        }

        #region GetCustomers

        [Fact]
        public void GetCustomers_CallsCustomerRepositoriesFindAll_ExactlyOnce()
        {
            _service.GetCustomers();
            _mock.Verify(r => r.FindAll(), Times.Once);
        }

        [Fact]
        public void GetCustomers_NoFilter_ReturnsListOfAllCustomers()
        {
            _mock.Setup(r => r.FindAll())
                .Returns(_expected);
            Assert.Equal(_expected,_service.GetCustomers());
        }

        #endregion

        #region GetCustomersById

        [Fact]
        public void GetCustomerById_CallsCustomerRepoFindById_ExactlyOnce()
        {
            _service.GetCustomerById(1);
            _mock.Verify(r => r.FindById(1), Times.Once);
        }

        #endregion

        #region DeleteCustomerById

        [Fact]
        public void DeleteCusomerById_CallsCustomerRepoDeleteById_ExactlyOnce()
        {
            _service.DeleteCustomerById(1);
            _mock.Verify(r=>r.DeleteById(1));
        }

        #endregion
        
        
    }
}