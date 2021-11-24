using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.WebApi.Controllers;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.WebApi.Test.Controllers
{
    public class CustomerControllerTest
    {
        [Fact]
        public void CustomerController_IsOfTypeControllerBase()
        {
            CustomerController controller = new CustomerController();
            Assert.IsAssignableFrom<ControllerBase>(controller);
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
    }
}