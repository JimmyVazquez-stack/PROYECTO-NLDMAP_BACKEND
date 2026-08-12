namespace NLDMAP.Domain.Entities;

public class ReportNld
{
    public  Guid Id { get; set; } = Guid.NewGuid();

    //Relacion con el ciudadano que reporta
    public Guid UserId { get; set; }
    public required string MissingPersonRelation { get; set; } //Madre, amigo/conocido etc.
    
    //informacion de la desaparicion
    public required DissapearEvents Events { get; set; }

    //Datos de consentimiento legal
    public bool ConsentUseExclusive { get; set; }
    public bool RequestInformationPublic { get; set; }

    //estado del reporte
    public string ReportStatus { get; set; } = "PENDIENTE"; // "SIN_VALIDAR", "ACTIVO"
}

//Objetos de valor


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

    