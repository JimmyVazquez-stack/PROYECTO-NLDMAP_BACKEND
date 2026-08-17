using NLDMAP.Domain.ValueObjects;

namespace NLDMAP.Domain.Entities
{
    public class Report
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        //Relacion con el ciudadano que reporta
        public Guid MissingPersonId { get; private set; }
        public Guid UserId { get; private set; }
        public  string MissingPersonRelation { get; private set; } //Madre, amigo/conocido etc.

        //informacion de la desaparicion
        public  DisappearanceEvents Events { get; private set; }

        //Datos de consentimiento legal
        public bool ConsentUseExclusive { get; private set; }
        public bool RequestInformationPublic { get; private set; }

        //estado del reporte
        public string ReportStatus { get; private set; } = "PENDIENTE"; // "SIN_VALIDAR", "ACTIVO"
        
        //Metodos para cambiar el estado 
        public void MarkAsActive() => ReportStatus = "ACTIVO";
        public void MarkAsInvalid() => ReportStatus = "SIN_VALIDAR";

    }
    
}