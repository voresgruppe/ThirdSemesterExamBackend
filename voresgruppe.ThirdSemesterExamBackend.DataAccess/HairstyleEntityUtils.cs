using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess
{
    public class HairstyleEntityUtils
    {
        public HairStyle EntityToHairStyle(HairstyleEntity entity)
        {
            HairStyle hairStyle = new HairStyle
            {
                Id = entity.Id,
                Name = entity.Name,
                EstimatedTime = entity.EstimatedTime
            };

            return hairStyle;
        }
    }
}