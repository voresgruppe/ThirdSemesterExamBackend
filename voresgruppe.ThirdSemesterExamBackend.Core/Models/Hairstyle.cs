using System.Collections.Generic;

namespace voresgruppe.ThirdSemesterExamBackend.Core.Models
{
    public class Hairstyle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EstimatedTime { get; set; }
        
        public string Description { get; set; }
        
        public double Price { get; set; }

        public List<int> PossibleStyles { get; set; }
    }
}