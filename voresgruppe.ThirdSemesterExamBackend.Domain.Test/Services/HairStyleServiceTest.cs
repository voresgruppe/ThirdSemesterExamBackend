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
        private readonly Mock<IHairstyleRepository> _mock;
        private readonly HairstyleService _service;
        private readonly List<Hairstyle> _expected;

        public HairStyleServiceTest()
        {
            _mock = new Mock<IHairstyleRepository>();
            _service = new HairstyleService(_mock.Object);
            _expected = new List<Hairstyle>
            {
                new Hairstyle
                {
                    Id = 1, Name = "kort"
                },
                new Hairstyle
                {
                    Id = 2, Name = "langt"
                }
            };
        }

        #region HairStyleService

        

        

        [Fact]
        public void HairStyleService_IsIHairStyleService()
        {
            Assert.True(_service is IHairStyleService);
        }

        [Fact]
        public void HairstyleService_WithNullRepository_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new HairstyleService(null));
        }
        
        [Fact]
        public void HairstyleService_WithNullRepository_ThrowsInvalidDataExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(() => new HairstyleService(null));
            Assert.Equal("Repository cannot be null", exception.Message);
        }
        
        #endregion

        #region GetHairstyles

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

        #endregion

        #region GetHairstyleByID

        [Fact]
        public void GetHairStyleByID_CallsRepositoryReadByID_ExactlyOnce()
        {
            var fakeProduct = new Hairstyle {Id = 1};
            _mock.Setup(r => r.ReadById(1))
                .Returns(fakeProduct);
            
            _service.GetHairstyleByID(1);
            _mock.Verify(r =>r.ReadById(1), Times.Once);
        }

        [Fact]
        public void GetHairstyleByID_returnsCorrectHairstyle()
        {
            var expected  = new Hairstyle {Id = 1, Name = "gryde", EstimatedTime = 10};
            _mock.Setup(r => r.ReadById(1))
                .Returns(expected);

            var actual = _service.GetHairstyleByID(1);
            Assert.Equal(expected, actual);
        }
        #endregion

        [Fact]
        public void DeleteHairstyleById_DeleteValidHairstyle_returnsTrue()
        {
            _mock.Setup(r => r.DeleteById(1))
                .Returns(true);
            Assert.True(_service.DeleteHairstyleById(1));
        }

        [Fact]
        public void CreateHairstyle_CreatesValidHairstyle()
        {
            var expected  = new Hairstyle {Id = 1, Name = "gryde", EstimatedTime = 10};
            _mock.Setup(r => r.CreateHairStyle(expected))
                .Returns(expected);
            var actual = _service.CreateHairstyle(expected);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UpdatesHairstyle_returnsHairstyle()
        {
            var oldHairstyle  = new Hairstyle {Id = 1, Name = "gryde", EstimatedTime = 10};
            var expected  = new Hairstyle {Id = 1, Name = "langt", EstimatedTime = 10};
            _mock.Setup(r => r.UpdateHairStyle(oldHairstyle.Id, expected))
                .Returns(expected);
            var actual = _service.UpdateHairstyle(oldHairstyle.Id, expected);
            Assert.Equal(expected, actual);
        }
    }
}