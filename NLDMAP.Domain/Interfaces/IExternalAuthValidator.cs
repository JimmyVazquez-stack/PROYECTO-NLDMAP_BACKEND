using NLDMAP.Domain.ValueObjects;

namespace NLDMAP.Domain.Interfaces
{
    public class IExternalAuthValidator
    {
        Task<ExternalUserInfo?> ValidateTokenAsync(string provider, string idToken);
    }
}