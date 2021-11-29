using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Core.IServices
{
    public interface IHairStyleService
    {
        List<HairStyle> GetHairstyles();
        HairStyle GetHairstyleByID(int i);
        bool DeleteHairstyleById(int i);

        HairStyle CreateHairstyle(HairStyle hairStyle);

        HairStyle UpdateHairstyle(int oldHairstyleId, HairStyle newHairstyle);
    }
}