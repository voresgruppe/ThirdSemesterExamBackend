using voresgruppe.ThirdSemesterExamBackend.Security.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Security
{
    public interface IAuthService
    {
        public AuthUser Login(string username, string password);
    }
}