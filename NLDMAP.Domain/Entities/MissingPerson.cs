namespace NLDMAP.Domain.Entities;

public class MissingPerson
{
    public string Name { get; private set; }         
    public int Age { get; private set; }
    public string Gender { get; private set; }       
    public string Height { get; private set; }      
    public DateTime DisappearanceDate { get; private set; }

    public MissingPerson(string name, int age, string gender, string height, DateTime disappearanceDate)
    {
        if (string.IsNullOrWhiteSpace(name)) 
            throw new ArgumentException("El nombre es obligatorio.");
        
        if (disappearanceDate > DateTime.UtcNow) 
            throw new ArgumentException("La fecha de desaparición no puede estar en el futuro.");

        Name = name;
        Age = age;
        Gender = gender;
        Height = height;
        DisappearanceDate = disappearanceDate;
    }
}