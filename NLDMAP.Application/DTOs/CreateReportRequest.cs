using NLDMAP.Domain.ValueObjects;

namespace NLDMAP.Application.DTOs;

public class CreateReportRequest
{
    //Datos de la persona
    public string MissingPersonName { get; set; }
    public int MissingPersonAge { get; set; }
    public string MissingPersonGender { get; set; }
    public string MissingPersonHeight { get; set; }
    public decimal MissingPersonWeight { get; set; }
    
    //Datos de los hechos
    public DateTime DisappearanceDate { get; set; }
    
    public  TimeSpan DisappearanceHour {get; set;}
    
    public string Circumstance{ get; set; } //Rumbo al trabajo ...
    public string FactsDescription { get; set; }
    public bool ReporterPresent { get; set; } //si / no
    
    //Ubicacion
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Municipality { get; set; }
    public double LastSightingLatitude { get; set; }
    public double LastSightingLongitude { get; set; }
    
    //Datos del reporte
    public Guid CreatorId { get; set; }
    public string MissingPersonRelation { get; set; }
    public bool ConsentUseExclusive { get; set; }
    public bool RequestInformationPublic { get; set; }
}