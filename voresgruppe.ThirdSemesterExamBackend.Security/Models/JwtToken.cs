namespace voresgruppe.ThirdSemesterExamBackend.Security.Models
{
    public class JwtToken
    {
        public string Jwt { get; set; }
        public string Message { get; set; }
        
        public int EmployeeId { get; set; }
    }
}