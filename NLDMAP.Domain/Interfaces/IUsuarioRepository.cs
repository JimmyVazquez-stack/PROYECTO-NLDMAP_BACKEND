using NLDMAP.Domain.Entities;
    
namespace NLDMAP.Domain.Interfaces;

public class IUsuarioRepository
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByEmailAsync(String email);

        Task AddSync(Usuario usuario);
    }
}