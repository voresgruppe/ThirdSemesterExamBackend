using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
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
        public void HairStyleController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {
            var typeInfo = typeof(HairStyleController).GetTypeInfo();
            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a=> a.GetType()
                    .Name.Equals("RouteAttribute"));
            Assert.NotNull(attribute);
            var routeAttr = attribute as RouteAttribute;
            Assert.Equal("api/[controller]", routeAttr.Template);
        }
    }
}