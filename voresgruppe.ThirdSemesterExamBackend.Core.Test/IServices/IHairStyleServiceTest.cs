using System.Collections.Generic;
using Moq;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.Core.Test.IServices
{
    public class IHairStyleServiceTest
    {
        [Fact]
        public void IHairService_IsAvailable()
        {
            var service = new Mock<IHairStyleService>().Object;
            Assert.NotNull(service);
        }

        [Fact]
        public void GetHairstyles_WithNoParam_ReturnsListOfAllProducts()
        {
            var mock = new Mock<IHairStyleService>();
            var fakelist = new List<HairStyle>();
            mock.Setup(s => s.GetHairstyles())
                .Returns(fakelist);
            var service = mock.Object;
            Assert.Equal(fakelist, service.GetHairstyles());
        }
        
        [Fact]
        public void GetHairStyleByID_ReturnsHairstyle()
        {
            var mock = new Mock<IHairStyleService>();
            var fakeProduct = new HairStyle {Id = 1};
            mock.Setup(s => s.GetHairstyleByID(1))
                .Returns(fakeProduct);
            var service = mock.Object;

            Assert.Equal(fakeProduct, service.GetHairstyleByID(1));
        }

        [Fact]
        public void DeleteHairstyleByID_DeletesHairstyle()
        {
            var mock = new Mock<IHairStyleService>();
            mock.Setup(s => s.DeleteHairstyleById(1))
                .Returns(true);
            var service = mock.Object;  
            Assert.True(service.DeleteHairstyleById(1));
        }

        [Fact]
        public void CreateHairstyle_CreatesHairstyle()
        {
            var mock = new Mock<IHairStyleService>();
            HairStyle hairStyle = new HairStyle
            {
                Id = 1,
                Name = "krøller",
                EstimatedTime = 200,
            };
            mock.Setup(s => s.CreateHairstyle(hairStyle))
                .Returns(hairStyle);
            var service = mock.Object;
            Assert.Equal(hairStyle, service.CreateHairstyle(hairStyle));

        }
    }
}