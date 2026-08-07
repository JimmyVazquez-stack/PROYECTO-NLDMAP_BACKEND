using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLDMAP.Domain.Interfaces;
using NLDMAP.Domain.Entities;

namespace NLDMAP.Infrastructure.Repositories
{
    public class EfUsuarioRepository : IUsuarioRepository
    {
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            TODO:
            return await Task.FromResult<Usuario?>(null);
        }

        public async Task AddSync(Usuario usuario)
        {
            TODO:
            await Task.CompletedTask;
        }
    }
}