using System.Collections.Generic;
using System.IO;
using System.Linq;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
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
    }
}