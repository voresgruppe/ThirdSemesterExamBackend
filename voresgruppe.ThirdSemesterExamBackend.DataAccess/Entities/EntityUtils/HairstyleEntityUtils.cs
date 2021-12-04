using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils
{
    public class HairstyleEntityUtils
    {
        public HairStyle EntityToHairStyle(HairstyleEntity entity)
        {
            HairStyle hairStyle = new HairStyle
            {
                Id = entity.Id,
                Name = entity.Name,
                EstimatedTime = entity.EstimatedTime,
                Description = entity.Description,
                Price = entity.Price
            };

            return hairStyle;
        }
    }
}