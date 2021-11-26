using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories
{
    public interface IHairStyleRepository
    {
        public List<HairStyle> FindAll();
        public HairStyle ReadById(int expectedId);

        public void DeleteById(int id);
    }
}