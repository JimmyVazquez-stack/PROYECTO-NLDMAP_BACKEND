

namespace NLDMAP.Domain.Entities
{

    public class MissingPerson
    {
        //Identidad
        public Guid Id { get; set; } = Guid.NewGuid();

        //Propiedades encapsuladas
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string? Curp { get; private set; } //opcional si se desconoce
        public DateTime? DateOfBirth { get; private set; }
        public int Age { get; private set; }

        public bool HasDisability { get; private set; } //si / no
        public string Sex { get; private set; }
        public string Gender { get; private set; } //Masculino, femenino, indeterminado
        public string Nationality { get; private set; }

        //Propiedades opcionales que se pueden llenar despues
        public string? Height { get; private set; }
        public string? IdentifyingSigns { get; private set; } //tatuaje, cicatriz ...
        public string? PhotographyUrl { get; private set; } //ruta a img almacenada

        //Historial de reportes
        public IReadOnlyCollection<Report> ReportHistory { get; private set; } = new List<Report>();


        //Constructor vacio requerido por EF
        protected MissingPerson()
        {
        }

        //Constructor de dominio 
        public MissingPerson(string name, string lastName, int age, string sex, string gender, string nationality)
        {
            //validaciones
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("El apellido es obligatorio");

            if (age < 0)
                throw new ArgumentException("La edad no puede ser un numero negativo");
            
            //Asignaciones
            Name = name;
            LastName = lastName;
            Age = age;
            Sex = sex;
            Gender = gender;
            Nationality = nationality;
        }
        
        //Metodo para actualizar datos opcionales de la persona
        public void SetAdditionalDetails(bool hasDisability, string? height, string? identifyingSigns,
            string? photographyUrl)
        {
            HasDisability = hasDisability;
            Height = height;
            IdentifyingSigns = identifyingSigns;
            PhotographyUrl = photographyUrl;
        }
    }
}

