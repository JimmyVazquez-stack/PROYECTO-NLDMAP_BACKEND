using NLDMAP.Application.DTOs.Auth;
using NLDMAP.Domain.Interfaces;
using NLDMAP.Domain.Entities;

namespace NLDMAP.Application.UseCases.Auth
{
    public class AuthenticateExternalUserUseCase
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IExternalAuthValidator _externalAuthValidator;
        
        public AuthenticateExternalUserUseCase(
            IUsuarioRepository userRepository,
            IExternalAuthValidator externalAuthValidator)
        {
            _userRepository = userRepository;
            _externalAuthValidator = externalAuthValidator;
        }

        public async Task<string> ExecuteAsync(ExternalAuthDto request)
        {
            //Validar token externo google/facebook
            var userInfo = await _externalAuthValidator.ValidateTokenAsync(request.Provider, request.IdToken);

            if (userInfo == null)
                throw new UnauthorizedAccessException("Token externo invalido.");

            //Buscar si usuario existe en Postgresql por email
            var usuario = await _userRepository.GetByEmailAsync(userInfo.Email);

            //si no existe, es un ciudadano nuevo 
            if (usuario == null)
            {
                usuario = new Usuario
                {
                    Email = userInfo.Email,
                    Nombre = userInfo.FullName,
                    Role = "Ciudadano"
                };
                await _userRepository.AddSync(usuario);
            }

            // controlador se encarga de generar JWT de openiddict
            return usuario.Email;

        }
    }
}