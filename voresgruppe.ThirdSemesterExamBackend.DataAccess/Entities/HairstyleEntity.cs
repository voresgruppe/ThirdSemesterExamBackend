using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities
{
    public class HairstyleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EstimatedTime { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        
        public string PossibleStyles { get; set; }
        
    }
}