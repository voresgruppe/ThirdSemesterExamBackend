using voresgruppe.ThirdSemesterExamBackend.Security.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Security.IServices
{
    public interface ISecurityService
    {
        JwtToken GenerateJwtToken(string username, string password);

        public string HashedPassword(string plainPassword, byte[] userSalt);
    }
}