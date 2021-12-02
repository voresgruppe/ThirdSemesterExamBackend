using voresgruppe.ThirdSemesterExamBackend.Security.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Security
{
    public interface IAuthService
    {
        public AuthUser GetUser(string username);
    }
}