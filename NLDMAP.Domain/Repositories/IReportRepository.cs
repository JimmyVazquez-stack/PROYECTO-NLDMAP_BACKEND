using NLDMAP.Domain.Entities;
namespace NLDMAP.Domain.Repositories;

public interface IReportRepository
{
    Task<ReportNLD> GetByIdAsync(Guid id);
    Task<ReportNLD> GetByFolioAsync(string folio);
    Task AddAsync(ReportNLD report);
    Task UpdateAsync(ReportNLD report);
}