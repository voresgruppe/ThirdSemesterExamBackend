using System.Collections.Generic;
using System.IO;
using System.Linq;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories
{
    public class HairstyleRepository : IHairStyleRepository
    {
        private readonly MainDbContext _ctx;

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
                .Select(he => new HairStyle
                {
                    Id = he.Id, Name = he.Name, EstimatedTime = he.EstimatedTime
                })
                .ToList();
        }

        public HairStyle ReadById(int expectedId)
        {
            var foundHairstyleEntity = _ctx.Hairstyles.Find(expectedId);
            return new HairStyle
            {
                Id = foundHairstyleEntity.Id, 
                Name = foundHairstyleEntity.Name,
                EstimatedTime = foundHairstyleEntity.EstimatedTime
            };
        }

        public bool DeleteById(int id)
        {
            var selectedHairstyle = _ctx.Hairstyles.Find(id);
            _ctx.Hairstyles.Remove(selectedHairstyle);
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
           return new HairStyle
           {
               Id = entity.Id,
               Name = entity.Name,
               EstimatedTime = entity.EstimatedTime
           };
        }

        public HairStyle UpdateHairStyle(int oldHairStyleId, HairStyle newHairstyle)
        {
            HairstyleEntity oldHairstyle = _ctx.Hairstyles.Find(oldHairStyleId);
            oldHairstyle.Name = newHairstyle.Name;
            oldHairstyle.EstimatedTime = newHairstyle.EstimatedTime;
            
            HairstyleEntity entity =_ctx.Hairstyles.Update(oldHairstyle).Entity;
            _ctx.SaveChanges();
            return new HairStyle
            {
                Id = entity.Id,
                Name = entity.Name,
                EstimatedTime = entity.EstimatedTime
            };
        }
    }
}