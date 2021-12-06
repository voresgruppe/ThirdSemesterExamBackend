using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories
{
    public interface IHairstyleRepository
    {
        public List<Hairstyle> FindAll();
        public Hairstyle ReadById(int expectedId);

        public bool DeleteById(int id);

        public Hairstyle CreateHairStyle(Hairstyle hairstyle);

        public Hairstyle UpdateHairStyle(int oldHairStyleId, Hairstyle newHairstyle);
    }
}