namespace NLDMAP.Domain.ValueObjects;

public class DissapearEvents
{
    public DateTime EventsDate { get; set; }
    public TimeSpan EventsHour { get; set; }
        
    public required string Circunstance { get; set; } //Rumbo al trabajo ...
    public required string DetailedDescription { get; set; } //como, cuando y donde
    public bool WasWithVictim { get; set; } //si / no
        
    //Georreferenciacion
    public required string Street  { get; set; }
    public required string Neighborhood  { get; set; }
    public required string State { get; set; }
    public required string Municipality  { get; set; }
        
    //Postgis y Neo4j
    public double Latitude { get; set; }
    public double Longitude { get; set; }
} 
