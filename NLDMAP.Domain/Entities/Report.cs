using NLDMAP.Domain.ValueObjects;

namespace NLDMAP.Domain.Entities;

public class Report
{
    public Guid Id { get; private set; }
    public string Folio { get; private set; }
    public Guid CreatorId { get; private set; } 
    public MissingPerson Person { get; private set; }
    public Coordinate LastSightingLocation { get; private set; }
    public string CaseStatus { get; private set; }    // Texto en español: "SIN_VALIDAR", "ACTIVO"
    public DateTime CreationDate { get; private set; }

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