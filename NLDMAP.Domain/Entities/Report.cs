using NLDMAP.Domain.ValueObjects;

namespace NLDMAP.Domain.Entities;

public class Report
{
    public required Guid Id { get;  set; } = Guid.NewGuid();
    public required string Folio { get;  set; }
    public required Guid CreatorId { get;  set; } 
    public  required MissingPerson Person { get;  set; }
    public required Coordinate LastSightingLocation { get;  set; }
    public required string CaseStatus { get;  set; }    // Texto en español: "SIN_VALIDAR", "ACTIVO"
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    private Report() { } 

    public static Report CreateNewReport(Guid creatorId, MissingPerson person, Coordinate location)
    {
        return new Report
        {
            Id = Guid.NewGuid(),
            Folio = $"NLD-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString()[..4].ToUpper()}",
            CreatorId = creatorId,
            Person = person,
            LastSightingLocation = location,
            CaseStatus = "SIN_VALIDAR", 
            CreationDate = DateTime.UtcNow
        };
    }
}