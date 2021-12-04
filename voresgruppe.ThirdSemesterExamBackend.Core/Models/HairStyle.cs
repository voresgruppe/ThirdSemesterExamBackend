namespace voresgruppe.ThirdSemesterExamBackend.Core.Models
{
    public class HairStyle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EstimatedTime { get; set; }
        
        public string Description { get; set; }
        
        public double Price { get; set; }
    }
}