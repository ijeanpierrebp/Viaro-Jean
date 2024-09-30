using System.ComponentModel.DataAnnotations;

namespace ViaroTestJean.Models;

public class Grado{
    public int Id { get; set; }

    [Required(ErrorMessage ="Ingresa el nombre.")] 
    public string Nombre { get; set; } = string.Empty;

    public int ProfesorId { get; set; }
    public string? NombreProfesor { get; set; }
    public Profesor? Profesor { get; set; }
    public virtual ICollection<AlumnoGrado>? AlumnoGrados { get; set; }
}
