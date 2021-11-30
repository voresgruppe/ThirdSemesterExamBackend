using System.Collections.Generic;
using System.IO;
using System.Linq;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories
{
    public class HairstyleRepository : IHairStyleRepository
    {
        private readonly MainDbContext _ctx;
        private HairstyleEntityUtils _hairstyleEntityUtils = new();

        public HairstyleRepository(MainDbContext ctx)
        {
            if (ctx == null)
            {
                throw new InvalidDataException("HairstyleRepository need a DBcontext");
            }

            _ctx = ctx;
        }

        public List<HairStyle> FindAll()
        {
            return _ctx.Hairstyles
                .Select(he => _hairstyleEntityUtils.EntityToHairStyle(he))
                .ToList();
        }

        public HairStyle ReadById(int expectedId)
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

        public HairStyle CreateHairStyle(HairStyle hairStyle)
        {
           HairstyleEntity hairstyleEntity = new HairstyleEntity
            {
                Name = hairStyle.Name,
                EstimatedTime = hairStyle.EstimatedTime
            };
           HairstyleEntity entity = _ctx.Hairstyles.Add(hairstyleEntity).Entity;
           _ctx.SaveChanges();
           return _hairstyleEntityUtils.EntityToHairStyle(entity);
        }

        public HairStyle UpdateHairStyle(int oldHairStyleId, HairStyle newHairstyle)
        {
            HairstyleEntity oldHairstyle = _ctx.Hairstyles.Find(oldHairStyleId);
            oldHairstyle.Name = newHairstyle.Name;
            oldHairstyle.EstimatedTime = newHairstyle.EstimatedTime;
            
            HairstyleEntity entity =_ctx.Hairstyles.Update(oldHairstyle).Entity;
            _ctx.SaveChanges();
            return _hairstyleEntityUtils.EntityToHairStyle(entity);
        }
    }
}