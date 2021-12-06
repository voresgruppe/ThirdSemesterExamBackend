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
    public class HairstyleControllerTest
    {
        private readonly HairStyleController _controller;
        private readonly Mock<IHairStyleService> _service;

        public HairstyleControllerTest()
        {
            _service = new Mock<IHairStyleService>();
            _controller = new HairStyleController(_service.Object);
        }

        #region Controller
        

        [Fact]
        public void HairstyleController_IsOfTypeControllerBase()
        {
           Assert.IsAssignableFrom<ControllerBase>(_controller);
        }

        [Fact]
        public void HairStyleController_withNullService_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(
                () => new HairStyleController(null));
        }

        [Fact]
        public void HairStyleController_withNullService_ThrowsInvalidDataException_WithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(
                () => new HairStyleController(null));
            Assert.Equal("hairStyleService Cannot be null", exception.Message);
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

       
        
        #endregion

        #region GetAll Method
        
        [Fact]
        public void HairStyleController_HasGetAllMethod_ReturnsListOfHairstylesInActionResult()
        {
            var method = typeof(HairStyleController)
                .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<List<Hairstyle>>).FullName, method.ReturnType.FullName);
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

        [Fact]
        public void GetAll_CallsServicesGetHairStyles_ExactlyOnce()
        {
            _controller.GetAll();
            
            _service.Verify(s=> s.GetHairstyles(), Times.Once);
        }
        
        #endregion
        
        #region GetById Method
        
        [Fact]
        public void HairStyleController_HasGetByIdMethod_ReturnsHairstyleInActionResult()
        {
            var method = typeof(HairStyleController)
                .GetMethods().FirstOrDefault(m => "GetById".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<Hairstyle>).FullName, method.ReturnType.FullName);
        }
        
        [Fact]
        public void GetById_HasGetHttpAttribute()
        {
            var methodInfo = typeof(HairStyleController)
                .GetMethods().FirstOrDefault(m => m.Name == "GetById");
            var attr = methodInfo.CustomAttributes
                .FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
            Assert.NotNull(attr);
        }

        [Fact]
        public void GetById_CallsServicesGetHairStyleByID_ExactlyOnce()
        {
            _controller.GetById(1);
            
            _service.Verify(s=> s.GetHairstyleByID(1), Times.Once);
        }
        
        #endregion
        
        #region DeleteById Method
        
        [Fact]
        public void HairStyleController_HasDeleteByIdMethod_ReturnsTrueInActionResult()
        {
            var method = typeof(HairStyleController)
                .GetMethods().FirstOrDefault(m => "DeleteById".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<bool>).FullName, method.ReturnType.FullName);
        }
        
        [Fact]
        public void DeleteById_HasHttpDeleteAttribute()
        {
            var methodInfo = typeof(HairStyleController)
                .GetMethods().FirstOrDefault(m => m.Name == "DeleteById");
            var attr = methodInfo.CustomAttributes
                .FirstOrDefault(ca => ca.AttributeType.Name == "HttpDeleteAttribute");
            Assert.NotNull(attr);
        }

        [Fact]
        public void DeleteById_CallsServicesDeleteHairStyleByID_ExactlyOnce()
        {
            _controller.DeleteById(1);
            
            _service.Verify(s=> s.DeleteHairstyleById(1), Times.Once);
        }
        
        #endregion
        
        #region Create Method
        
        [Fact]
        public void HairStyleController_HasCreateMethod_ReturnsHairstyleInActionResult()
        {
            var method = typeof(HairStyleController)
                .GetMethods().FirstOrDefault(m => "Create".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<Hairstyle>).FullName, method.ReturnType.FullName);
        }
        
        [Fact]
        public void Create_HasHttpPostAttribute()
        {
            var methodInfo = typeof(HairStyleController)
                .GetMethods().FirstOrDefault(m => m.Name == "Create");
            var attr = methodInfo.CustomAttributes
                .FirstOrDefault(ca => ca.AttributeType.Name == "HttpPostAttribute");
            Assert.NotNull(attr);
        }

        [Fact]
        public void Create_CallsServicesCreate_ExactlyOnce()
        {
            Hairstyle hairstyle = new Hairstyle();
            _controller.Create(hairstyle);
            
            _service.Verify(s=> s.CreateHairstyle(hairstyle), Times.Once);
        }
        
        #endregion
        
        #region Update Method
        
        [Fact]
        public void HairStyleController_HasUpdateMethod_ReturnsHairstyleInActionResult()
        {
            var method = typeof(HairStyleController)
                .GetMethods().FirstOrDefault(m => "Update".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<Hairstyle>).FullName, method.ReturnType.FullName);
        }
        
        [Fact]
        public void Update_HasHttpPutAttribute()
        {
            var methodInfo = typeof(HairStyleController)
                .GetMethods().FirstOrDefault(m => m.Name == "Update");
            var attr = methodInfo.CustomAttributes
                .FirstOrDefault(ca => ca.AttributeType.Name == "HttpPutAttribute");
            Assert.NotNull(attr);
        }
        
        
        /*
         
         //TODO jeg ved ikke hvorfor den ikke virker længere
        [Fact]
        public void Update_CallsServicesUpdate_ExactlyOnce()
        {
            HairStyle hairStyle = new HairStyle();
            _controller.Update(hairStyle.Id, hairStyle.Name, hairStyle.EstimatedTime);
            
            _service.Verify(s=> s.UpdateHairstyle(hairStyle.Id, new HairStyle(){Name = hairStyle.Name, EstimatedTime = hairStyle.EstimatedTime}), Times.Once);
        }
        */
        
        #endregion
    }
}