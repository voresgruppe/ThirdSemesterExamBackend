using voresgruppe.ThirdSemesterExamBackend.Security.IRepositories;
using voresgruppe.ThirdSemesterExamBackend.Security.IServices;
using voresgruppe.ThirdSemesterExamBackend.Security.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Security.Services
{
    public class AuthUserService: IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthUserService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        
        public AuthUser GetUser(string username)
        {
            return _authRepository.FindUser(username);
        }
    }
}