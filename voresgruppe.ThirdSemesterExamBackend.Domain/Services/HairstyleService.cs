using System.Collections.Generic;
using System.IO;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.Services
{
    public class HairstyleService : IHairStyleService
    {
        private IHairstyleRepository _hairstyleRepository;
        public HairstyleService(IHairstyleRepository hairstyleRepository)
        {
            _hairstyleRepository = hairstyleRepository ?? throw new InvalidDataException("Repository cannot be null");
        }

        public List<Hairstyle> GetHairstyles()
        {
            
            return _hairstyleRepository.FindAll();
        }

        public Hairstyle GetHairstyleByID(int i)
        {
            return _hairstyleRepository.ReadById(i);
        }

        public bool DeleteHairstyleById(int i)
        {
            return _hairstyleRepository.DeleteById(i);
        }

        public Hairstyle CreateHairstyle(Hairstyle hairstyle)
        {
            return _hairstyleRepository.CreateHairStyle(hairstyle);
        }

        public Hairstyle UpdateHairstyle(int oldHairstyleId, Hairstyle newHairstyle)
        {
            return _hairstyleRepository.UpdateHairStyle(oldHairstyleId, newHairstyle);
        }
    }
}