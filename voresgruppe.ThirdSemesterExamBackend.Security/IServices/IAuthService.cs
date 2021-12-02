using voresgruppe.ThirdSemesterExamBackend.Security.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Security.IServices
{
    public interface IAuthService
    {
        public AuthUser GetUser(string username);
    }
}