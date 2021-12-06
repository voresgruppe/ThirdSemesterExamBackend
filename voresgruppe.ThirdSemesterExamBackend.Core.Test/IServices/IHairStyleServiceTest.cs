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
            var fakelist = new List<Hairstyle>();
            mock.Setup(s => s.GetHairstyles())
                .Returns(fakelist);
            var service = mock.Object;
            Assert.Equal(fakelist, service.GetHairstyles());
        }
        
        [Fact]
        public void GetHairStyleByID_ReturnsHairstyle()
        {
            var mock = new Mock<IHairStyleService>();
            var fakeProduct = new Hairstyle {Id = 1};
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
            Hairstyle hairstyle = new Hairstyle
            {
                Id = 1,
                Name = "krøller",
                EstimatedTime = 200,
            };
            mock.Setup(s => s.CreateHairstyle(hairstyle))
                .Returns(hairstyle);
            var service = mock.Object;
            Assert.Equal(hairstyle, service.CreateHairstyle(hairstyle));

        }
        
        [Fact]
        public void UpdateHairstyle_updatesHairstyle()
        {
            var mock = new Mock<IHairStyleService>();
            Hairstyle hairstyle = new Hairstyle
            {
                Id = 1,
                Name = "langt",
                EstimatedTime = 200,
            };
            
            mock.Setup(s => s.UpdateHairstyle(hairstyle.Id, hairstyle))
                .Returns(hairstyle);
            var service = mock.Object;
            Assert.Equal(hairstyle, service.UpdateHairstyle(hairstyle.Id, hairstyle));

        }
    }
}