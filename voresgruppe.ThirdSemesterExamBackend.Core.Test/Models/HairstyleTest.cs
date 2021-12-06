using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.Core.Test.Models
{
    public class HairstyleTest
    {
        private  Hairstyle _hairstyle;
        public HairstyleTest()
        {
            _hairstyle = new Hairstyle();
        }

        [Fact]
        public void Hairstyle_CanBeInitialized()
        {
            
            Assert.NotNull(_hairstyle);
        }
        
        [Fact]
        public void Hairstyle_Id_MustBeInt()
        {
            
            Assert.True(_hairstyle.Id is int);
        }

        [Fact]
        public void Hairstyle_SetId_StoresId()
        {
            
            _hairstyle.Id = 1;
            _hairstyle.Id = 2;
            Assert.Equal(2, _hairstyle.Id);
        }

        [Fact]
        public void Hairstyle_SetName_StoreNameAsString()
        {
            _hairstyle.Name = "Kort";
            _hairstyle.Name = "langt";
            Assert.Equal("langt", _hairstyle.Name);
        }
    }
}