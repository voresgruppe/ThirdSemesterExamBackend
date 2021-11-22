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
    }
}