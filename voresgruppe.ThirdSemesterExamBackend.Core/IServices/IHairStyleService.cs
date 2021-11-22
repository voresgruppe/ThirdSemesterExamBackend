using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Core.IServices
{
    public interface IHairStyleService
    {
        List<HairStyle> GetHairstyles();
    }
}