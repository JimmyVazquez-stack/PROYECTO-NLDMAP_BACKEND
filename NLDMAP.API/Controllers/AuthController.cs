using Microsoft.AspNetCore.Mvc;
using NLDMAP.Application.DTOs.Auth;
using NLDMAP.Application.UseCases.Auth;


namespace NLDMAP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticateExternalUserUseCase _authenticateUseCase;

        public AuthController(AuthenticateExternalUserUseCase authenticateUseCase)
        {
            _authenticateUseCase = authenticateUseCase;
        }
    
        [HttpPost("external-login")]
        public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthDto request)
        {
            try
            {   
                //Validar caso de uso y registrar al ciudadano si es nuevo
                var userEmail = await _authenticateUseCase.ExecuteAsync(request);
                //Implementar logica de signin de openiddict

                return Ok(new { Message = " Autenticación exitosa", Token = "JWT_AQUI" });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Error = ex.Message });
            }
        }
    }   
}