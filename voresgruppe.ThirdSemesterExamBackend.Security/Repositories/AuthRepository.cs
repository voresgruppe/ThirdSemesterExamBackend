using System.Linq;
using voresgruppe.ThirdSemesterExamBackend.Security.IRepositories;
using voresgruppe.ThirdSemesterExamBackend.Security.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Security.Repositories
{
    public class AuthRepository: IAuthRepository
    {
        private readonly AuthDbContext _ctx;

        public AuthRepository(AuthDbContext ctx)
        {
            _ctx = ctx;
        }

        public AuthUser FindByUsernameAndPassword(string username, string password)
        {
            LoginUserEntity loginUserEntity = _ctx.LoginUsers
                .FirstOrDefault(user => 
                    username.Equals(user.Username) 
                    && password.Equals(user.Password));
            return EntityToAuthUser_NoPassword(loginUserEntity);
        }

        private AuthUser EntityToAuthUser_NoPassword(LoginUserEntity loginUserEntity)
        {
            return new AuthUser()
            {
                Id = loginUserEntity.Id,
                Username = loginUserEntity.Username
            };
        }
    }
}