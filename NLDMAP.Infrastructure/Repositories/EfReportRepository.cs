using System;
using System.Threading.Tasks;
using NLDMAP.Domain.Entities;
using NLDMAP.Domain.Repositories;

namespace NLDMAP.Infrastructure.Repositories
{

    public class EfReportRepository : IReportRepository
    {
        public async Task AddAsync(Report report)
        {
            //Implementacion en Postgresql, mongodb y neo4j
            await Task.CompletedTask;
        }

        public Task<Report> GetByFolioAsync(string folio)
        {
            //implementar busqueda real 
            return await Task.FromResult<Report>(null!);
        }

        public async Task<Report> GetByIdAsync(Guid id)
        {
            return await Task.FromResult<Report>(null!);
        }

        public Task UpdateAsync(Report report)
        {
            //implementar actualizacion real
            await Task.CompletedTask;
        }
    }
}