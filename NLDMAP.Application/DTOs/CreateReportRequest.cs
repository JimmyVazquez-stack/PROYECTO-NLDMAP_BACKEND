namespace NLDMAP.Application.DTOs;

public class CreateReportRequest
{
    public Guid CreatorId { get; set; }
    public string MissingPersonName { get; set; }
    public int MissingPersonAge { get; set; }
    public string MissingPersonGender { get; set; }
    public string MissingPersonHeight { get; set; }
    public DateTime DisappearanceDate { get; set; }
    
    // Coordenadas planas que llegarán desde el GPS del dispositivo
    public double LastSightingLatitude { get; set; }
    public double LastSightingLongitude { get; set; }
    public string GeoSource { get; set; } 
}