using voresgruppe.ThirdSemesterExamBackend.Security.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Security
{
    public interface ISecurityService
    {
        JwtToken GenerateJwtToken(string username, string password);
    }
}