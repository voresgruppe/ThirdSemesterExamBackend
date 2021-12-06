using System.Collections.Generic;
using System.IO;
using System.Linq;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories
{
    public class HairstyleRepository : IHairstyleRepository
    {
        private readonly MainDbContext _ctx;
        private readonly HairstyleEntityUtils _hairstyleEntityUtils = new();

        public HairstyleRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new InvalidDataException("HairstyleRepository need a DBcontext");
        }

        public List<Hairstyle> FindAll()
        {
            return _ctx.Hairstyles
                .Select(he => _hairstyleEntityUtils.EntityToHairStyle(he))
                .ToList();
        }

        public Hairstyle ReadById(int expectedId)
        {
            var foundHairstyleEntity = _ctx.Hairstyles.Find(expectedId);
            return _hairstyleEntityUtils.EntityToHairStyle(foundHairstyleEntity);
        }

        public bool DeleteById(int id)
        {
            var selectedHairstyle = _ctx.Hairstyles.Find(id);
            _ctx.Hairstyles.Remove(selectedHairstyle);
            _ctx.SaveChanges();
            return true;
        }

        public Hairstyle CreateHairStyle(Hairstyle hairstyle)
        {
            HairstyleEntity hairstyleEntity = _hairstyleEntityUtils.HairstyleToEntity(hairstyle);
           HairstyleEntity entity = _ctx.Hairstyles.Add(hairstyleEntity).Entity;
           _ctx.SaveChanges();
           return _hairstyleEntityUtils.EntityToHairStyle(entity);
        }

        public Hairstyle UpdateHairStyle(int oldHairStyleId, Hairstyle newHairstyle)
        {
            HairstyleEntity oldHairstyle = _ctx.Hairstyles.Find(oldHairStyleId);
            oldHairstyle = _hairstyleEntityUtils.HairstyleToEntity(newHairstyle);
            oldHairstyle.Id = oldHairStyleId;
            
            
            
            HairstyleEntity entity =_ctx.Hairstyles.Update(oldHairstyle).Entity;
            _ctx.SaveChanges();
            return _hairstyleEntityUtils.EntityToHairStyle(entity);
        }
    }
}