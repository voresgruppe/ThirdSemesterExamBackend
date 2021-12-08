using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Core.IServices
{
    public interface IHairStyleService
    {
        List<Hairstyle> GetHairstyles();
        Hairstyle GetHairstyleByID(int i);
        bool DeleteHairstyleById(int i);

        Hairstyle CreateHairstyle(Hairstyle hairstyle);

        Hairstyle UpdateHairstyle(int oldHairstyleId, Hairstyle newHairstyle);

        public List<Hairstyle> GetListOfHairstyles_FromListOfId(List<int> possibleStyles);
    }
}