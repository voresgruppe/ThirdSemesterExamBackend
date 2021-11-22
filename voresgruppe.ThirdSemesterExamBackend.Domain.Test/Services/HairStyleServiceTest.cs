using System.IO;
using Moq;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;
using voresgruppe.ThirdSemesterExamBackend.Domain.Services;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.Test.Services
{
    public class HairStyleServiceTest
    {
        [Fact]
        public void HairStyleService_IsIHairStyleService()
        {
            var mock = new Mock<IHairStyleRepository>();
            var service = new HairStyleService(mock.Object);
            Assert.True(service is IHairStyleService);
        }

        [Fact]
        public void HairstyleService_WithNullRepository_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new HairStyleService(null));
        }
        
        [Fact]
        public void HairstyleService_WithNullRepository_ThrowsInvalidDataExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(() => new HairStyleService(null));
            Assert.Equal("Repository cannot be null", exception.Message);
        }
    }
}