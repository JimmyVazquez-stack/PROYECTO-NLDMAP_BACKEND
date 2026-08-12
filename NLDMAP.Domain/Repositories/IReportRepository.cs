using NLDMAP.Domain.Entities;
namespace NLDMAP.Domain.Repositories;

public interface IReportRepository
{
    Task<ReportNld> GetByIdAsync(Guid id);
    Task<ReportNld> GetByFolioAsync(string folio);
    Task AddAsync(ReportNld report);
    Task UpdateAsync(ReportNld report);
}