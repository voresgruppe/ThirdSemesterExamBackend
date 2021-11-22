using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.Core.Test.Models
{
    public class CustomerTest
    {
        private readonly Customer _customer;
        public CustomerTest()
        {
            _customer = new Customer();
        }
        
        [Fact]
        public void Customer_CanBeInitialized()
        {
            Assert.NotNull(_customer);
        }

        [Fact]
        public void Customer_SetId_StoresId()
        {
            _customer.Id = 1;
            Assert.Equal(1,_customer.Id);
        }
        
        [Fact]
        public void Customer_SetName_StoresName()
        {
            _customer.Name = "Joe";
            Assert.Equal("Joe",_customer.Name);
        }
        
        [Fact]
        public void Customer_SetPhoneNumber_StoresPhoneNumber()
        {
            _customer.PhoneNumber = "88888888";
            Assert.Equal("88888888",_customer.PhoneNumber);
        }
        
        [Fact]
        public void Customer_SetEmail_StoresEmail()
        {
            _customer.Email = "vladimirputin@gmail.com";
            Assert.Equal("vladimirputin@gmail.com",_customer.Email);
        }
        
        [Fact]
        public void Customer_Id_MustBeInt()
        {
            Assert.True(_customer.Id is int);
        }
        
        
        
    }
}