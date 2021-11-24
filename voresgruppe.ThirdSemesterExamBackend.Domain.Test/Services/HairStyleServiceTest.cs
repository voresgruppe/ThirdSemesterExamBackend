using System.Collections.Generic;
using System.IO;
using Moq;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;
using voresgruppe.ThirdSemesterExamBackend.Domain.Services;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.Test.Services
{
    public class HairStyleServiceTest
    {
        private readonly Mock<IHairStyleRepository> _mock;
        private readonly HairStyleService _service;
        private readonly List<HairStyle> _expected;

        public HairStyleServiceTest()
        {
            _mock = new Mock<IHairStyleRepository>();
            _service = new HairStyleService(_mock.Object);
            _expected = new List<HairStyle>
            {
                new HairStyle
                {
                    Id = 1, Name = "kort"
                },
                new HairStyle
                {
                    Id = 2, Name = "langt"
                }
            };
        }

        [Fact]
        public void HairStyleService_IsIHairStyleService()
        {
            Assert.True(_service is IHairStyleService);
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

        [Fact]
        public void GetHairStyles_CallsRepositoryFindAll_ExactlyOnce()
        {
            _service.GetHairstyles();
            _mock.Verify(r =>r.FindAll(), Times.Once);
        }

        [Fact]
        public void GetHairstyles_NoFilter_ReturnsAllHairstyles()
        {
            
            _mock.Setup(r => r.FindAll())
                .Returns(_expected);
            var actual = _service.GetHairstyles();
            Assert.Equal(_expected, actual);
        }
    }
}