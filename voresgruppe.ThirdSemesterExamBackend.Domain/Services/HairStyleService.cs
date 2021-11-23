using System.Collections.Generic;
using System.IO;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.Services
{
    public class HairStyleService : IHairStyleService
    {
        private IHairStyleRepository _hairStyleRepository;
        public HairStyleService(IHairStyleRepository hairStyleRepository)
        {
            _hairStyleRepository = hairStyleRepository ?? throw new InvalidDataException("Repository cannot be null");
        }

        public List<HairStyle> GetHairstyles()
        {
            
            return _hairStyleRepository.FindAll();
        }
    }
}