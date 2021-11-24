using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.WebApi.Controllers;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.WebApi.Test.Controllers
{
    public class HairstyleControllerTest
    {
        private readonly HairStyleController _controller;

        public HairstyleControllerTest()
        {
            _controller = new HairStyleController();
        }

        [Fact]
        public void HairstyleController_IsOfTypeControllerBase()
        {
           Assert.IsAssignableFrom<ControllerBase>(_controller);
        }

        [Fact]
        public void HairstyleController_UsesApiControllerAttribute()
        {
            var typeInfo = typeof(HairStyleController).GetTypeInfo();
            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a=> a.GetType()
                    .Name.Equals("ApiControllerAttribute"));
            Assert.NotNull(attribute);
        }

        [Fact]
        public void HairStyleController_UsesRouteAttribute()
        {
            var typeInfo = typeof(HairStyleController).GetTypeInfo();
            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a=> a.GetType()
                    .Name.Equals("RouteAttribute"));
            Assert.NotNull(attribute);
        }

        [Fact]
        public void HairStyleController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {
            var typeInfo = typeof(HairStyleController).GetTypeInfo();
            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a=> a.GetType()
                    .Name.Equals("RouteAttribute")) as RouteAttribute;
            Assert.Equal("api/[controller]", attribute.Template);
        }

        [Fact]
        public void ProductController_HasGetAllMethod_ReturnsListOfHairstylesInActionResult()
        {
            var method = typeof(HairStyleController)
                .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<List<HairStyle>>).FullName, method.ReturnType.FullName);
        }

        [Fact]
        public void GetAll_WithNoParams_HasGetHttpAttribute()
        {
            var methodInfo = typeof(HairStyleController)
                .GetMethods().FirstOrDefault(m => m.Name == "GetAll");
            var attr = methodInfo.CustomAttributes
                .FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
            Assert.NotNull(attr);
        }
    }
}