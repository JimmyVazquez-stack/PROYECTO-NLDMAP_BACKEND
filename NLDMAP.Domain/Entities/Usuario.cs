namespace NLDMAP.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public String FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string AlertRadioKm { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

    }
}