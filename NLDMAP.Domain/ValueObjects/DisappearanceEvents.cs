namespace NLDMAP.Domain.ValueObjects;

public class DisappearanceEvents
{
    public required DateTime EventsDate { get; init; }
    public required TimeSpan EventsHour { get; init; }
    public required string Circumstance { get; init; } //Rumbo al trabajo ...
    public required string FactsDescription { get; init; } //como, cuando y donde
    public required bool ReporterPresent { get; set; } //si / no
        
    //Georreferenciacion
    public required string Street  { get; init; }
    public required string City  { get; init; }
    public required string State { get; init; }
    public required string Municipality { get; init; }
        
    //Postgis y Neo4j
    public double Latitude { get; init; }
    public double Longitude { get; init; }
} 
