using System;
using System.Threading.Tasks;
using NLDMAP.Application.DTOs;

namespace NLDMAP.Application.Interfaces
{

    public interface IReportRepository
    {
        //AL implementar esta interfaz  guardar el folio
        //generado y los datos que mando el ciudadano
        Task SaveReportAsync(Guid reportId, CreateReportRequest requestd);
    }
}