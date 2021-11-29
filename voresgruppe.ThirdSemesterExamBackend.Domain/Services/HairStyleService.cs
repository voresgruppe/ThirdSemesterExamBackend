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

        public HairStyle GetHairstyleByID(int i)
        {
            return _hairStyleRepository.ReadById(i);
        }

        public bool DeleteHairstyleById(int i)
        {
            return _hairStyleRepository.DeleteById(i);
        }

        public HairStyle CreateHairstyle(HairStyle hairStyle)
        {
            return _hairStyleRepository.CreateHairStyle(hairStyle);
        }

        public HairStyle UpdateHairstyle(int oldHairstyleId, HairStyle newHairstyle)
        {
            return _hairStyleRepository.UpdateHairStyle(oldHairstyleId, newHairstyle);
        }
    }
}