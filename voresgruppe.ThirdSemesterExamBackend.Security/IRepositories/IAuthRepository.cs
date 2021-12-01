using voresgruppe.ThirdSemesterExamBackend.Security.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Security.IRepositories
{
    public interface IAuthRepository
    {
        public AuthUser FindByUsernameAndPassword(string username, string password);
    }
}