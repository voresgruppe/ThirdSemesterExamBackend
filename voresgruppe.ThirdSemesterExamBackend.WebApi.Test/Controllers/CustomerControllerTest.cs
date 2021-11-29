using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Moq;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.WebApi.Controllers;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.WebApi.Test.Controllers
{
    public class CustomerControllerTest
    {
        #region constructor

        private readonly Mock<ICustomerService> _service;
        private readonly CustomerController _controller;

        public CustomerControllerTest()
        {
            _service = new Mock<ICustomerService>();
            _controller = new CustomerController(_service.Object);
        }

        #endregion

        #region Controller

        [Fact]
        public void CustomerController_IsOfTypeControllerBase()
        {
            Assert.IsAssignableFrom<ControllerBase>(_controller);
        }

        [Fact]
        public void CustomerController_UsesApiControllerAttribute()
        {
            //Arrange
            TypeInfo typeInfo = typeof(CustomerController).GetTypeInfo(); 
            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("ApiControllerAttribute"));
            //Assert
            Assert.NotNull(attribute);
        }

        [Fact]
        public void CustomerController_UsesRouteAttribute()
        {
            //Arrange
            TypeInfo typeInfo = typeof(CustomerController).GetTypeInfo(); 
            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("RouteAttribute"));
            //Assert
            Assert.NotNull(attribute);
        }
        
        [Fact]
        public void CustomerController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {
            //Arrange
            TypeInfo typeInfo = typeof(CustomerController).GetTypeInfo(); 
            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("RouteAttribute"));
            //Assert
            var routeAttribute = attribute as RouteAttribute;
            Assert.Equal("api/[controller]",routeAttribute.Template);
        }

        [Fact]
        public void CustomerController_HasGetAllMethod_IsPublic()
        {
            MethodInfo method = typeof(CustomerController)
                .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        [Fact]
        public void CustomerController_HasGetAllMethod_ReturnsListOfCustomersInActionResult()
        {
            MethodInfo method = typeof(CustomerController)
                .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<List<Customer>>).FullName, method.ReturnType.FullName);
        }
        
        [Fact]
        public void CustomerController_HasCustomerService_IsOfTypeControllerBase()
        {
            Assert.IsAssignableFrom<ControllerBase>(_controller);
        }

        [Fact]
        public void CustomerController_WithNullCustomerService_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new CustomerController(null));
        }

        [Fact]
        public void CustomerController_WithNullCustomerService_ThrowsInvalidDataExceptionWithMessage()
        {
            InvalidDataException exception = Assert.Throws<InvalidDataException>(() => new CustomerController(null));
            Assert.Equal("CustomerService cannot be null",exception.Message);
        }

        #endregion
        
        #region GetMethod

        [Fact]
        public void GetAll_WithNoParams_HasGetHttpAttribute()
        {
            var methodInfo = typeof(CustomerController)
                .GetMethods()
                .FirstOrDefault(m => m.Name == "GetAll");
            var attribute = methodInfo.CustomAttributes
                .FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
            Assert.NotNull(attribute);
        }

        [Fact]
        public void GetAll_CallsServicesGetCustomers_Once()
        {
            _controller.GetAll();
            _service.Verify(s=>s.GetCustomers(),Times.Once);
        }

        #endregion

        #region GetById

        [Fact]
        public void GetById_HasGetHttpAttribute()
        {
            var methodInfo = typeof(CustomerController)
                .GetMethods()
                .FirstOrDefault(m => m.Name == "GetById");
            var attribute = methodInfo.CustomAttributes
                .FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
            Assert.NotNull(attribute);
        }

        [Fact]
        public void GetById_CallsServicesGetCustomerById_Once()
        {
            _controller.GetById(1);
            _service.Verify(s=>s.GetCustomerById(1),Times.Once);
        }
        

        #endregion
    }
}