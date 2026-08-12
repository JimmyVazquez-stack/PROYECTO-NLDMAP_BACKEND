using NLDMAP.Application.DTOs;
using NLDMAP.Domain.Entities;
using NLDMAP.Domain.Repositories;
using NLDMAP.Domain.ValueObjects;

namespace NLDMAP.Application.UseCases;

public class CreateReportUseCase
{
    private readonly IReportRepository _reportRepository;

    public CreateReportUseCase(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<string> ExecuteAsync(CreateReportRequest request)
    {
        // 1. Instanciar el Value Object (Validará matemáticamente las coordenadas)
        var location = new Coordinate(request.LastSightingLatitude, request.LastSightingLongitude, request.GeoSource);

        // 2. Instanciar la entidad de la persona (Validará datos en blanco y fechas)
        var person = new MissingPerson(
            request.MissingPersonName,
            request.MissingPersonAge,
            request.MissingPersonGender,
            request.MissingPersonHeight,
            request.DisappearanceDate
        );

        // 3. Crear la entidad raíz que orquesta el reporte y genera el folio
        var report = ReportNLD.CreateNewReport(request.CreatorId, person, location);

        // 4. Guardar en base de datos de manera asíncrona usando la abstracción
        await _reportRepository.AddAsync(report);

        // 5. Retornar el folio generado al cliente móvil
        return report.Folio;
    }
}