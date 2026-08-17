using NLDMAP.Domain.ValueObjects;

namespace NLDMAP.Domain.Entities;

public class Report 
{
    public  Guid Id { get; set; } = Guid.NewGuid();
    
    //llave que conecta al reporte con la persona en la BD
    public Guid MissingPersonId { get; private set; }
    
    //Relacion con el ciudadano que reporta
    public Guid UserId { get; private set; }
    public string MissingPersonRelation { get; private set; } //Madre, amigo/conocido etc.
    
    //informacion de la desaparicion
    public DissapearEvents Events { get; private set; }

    //Datos de consentimiento legal
    public bool ConsentUseExclusive { get; private set; }
    public bool RequestInformationPublic { get; private set; }

    //estado del reporte
    public ReportStatus Status { get; private set; } = ReportStatus.Pendiente;
    
    //constructor vacio requerido por EF
    protected Report() {}
    
    //constructor de dominio
    public Report(
        Guid missingPersonId,
        Guid userId,
        string missingPersonRelation,
        DissapearEvents events,
        bool consentUseExclusive,
        bool requestInformationPublic)
    {
        if (missingPersonId ==  Guid.Empty)
            throw  new ArgumentException("El ID de la persona no puede estar vacio.", nameof(missingPersonId));
        
        if (userId ==  Guid.Empty)
            throw  new ArgumentException("El ID del usuario no puede estar vacio.", nameof(userId));

        if (string.IsNullOrWhiteSpace(missingPersonRelation))
            throw new ArgumentException("La realcion la persona es obligatoria", nameof(missingPersonRelation));
        
        MissingPersonId = missingPersonId;
        UserId = userId;
        MissingPersonRelation = missingPersonRelation;
        ConsentUseExclusive = consentUseExclusive;
        RequestInformationPublic = requestInformationPublic;
        Events = events;

    }

    public void MaskAsActive() => Status = ReportStatus.Activo;
    public void MaskAsInactive() => Status = ReportStatus.SinValidar;

}

public enum ReportStatus
{
    Pendiente,
    SinValidar,
    Activo
}

