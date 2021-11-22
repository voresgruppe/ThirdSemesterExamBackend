using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using Xunit;

namespace voresgruppe.ThirdSemesterExamBackend.Core.Test.Models
{
    public class HairstyleTest
    {
        private  HairStyle _hairStyle;
        public HairstyleTest()
        {
            _hairStyle = new HairStyle();
        }

        [Fact]
        public void Hairstyle_CanBeInitialized()
        {
            
            Assert.NotNull(_hairStyle);
        }
        
        [Fact]
        public void Hairstyle_Id_MustBeInt()
        {
            
            Assert.True(_hairStyle.Id is int);
        }

        [Fact]
        public void Hairstyle_SetId_StoresId()
        {
            
            _hairStyle.Id = 1;
            _hairStyle.Id = 2;
            Assert.Equal(2, _hairStyle.Id);
        }

        [Fact]
        public void Hairstyle_SetName_StoreNameAsString()
        {
            _hairStyle.Name = "Kort";
            _hairStyle.Name = "langt";
            Assert.Equal("langt", _hairStyle.Name);
        }
    }
}