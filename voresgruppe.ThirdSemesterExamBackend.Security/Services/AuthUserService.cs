using voresgruppe.ThirdSemesterExamBackend.Security.IRepositories;
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
        
        public AuthUser Login(string username, string password)
        {
            return _authRepository.FindByUsernameAndPassword(username, password);
        }
    }
}