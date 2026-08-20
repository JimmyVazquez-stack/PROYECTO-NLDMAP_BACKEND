namespace NLDMAP.Application.DTOs
{
    public class MapPointResponse
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
    }
}