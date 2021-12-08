using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using voresgruppe.ThirdSemesterExamBackend.Security.IServices;

namespace voresgruppe.ThirdSemesterExamBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public AuthController(ISecurityService securityService)
        {
            _securityService = securityService;
        }


        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public ActionResult<TokenDto> Login(LoginDto dto)
        {
            var token = _securityService.GenerateJwtToken(dto.Username, dto.Password);
            return new TokenDto()
            {
                Jwt = token.Jwt,
                Message = token.Message,
                EmployeeId = token.EmployeeId,
            };

        }
    }

    public class TokenDto
    {
        public string Jwt { get; set; }
        public string Message { get; set; }

        public int EmployeeId { get; set; }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}