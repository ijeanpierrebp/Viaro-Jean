using System.ComponentModel.DataAnnotations;

namespace ViaroTestJean.Models;

public class Alumno
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, ingresa el Nombre.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Por favor, ingresa los Apellidos.")]
    public string Apellidos { get; set; } = string.Empty;

    [Required(ErrorMessage = "Por favor, Indica el genero.")]
    public string Genero { get; set; } = string.Empty;

    [Required(ErrorMessage = "Por favor, ingrese la fecha de nacimiento.")]
    [DataType(DataType.Date, ErrorMessage = "La fecha de nacimiento no es válida.")]
    public DateTime FechaNacimiento { get; set; } = DateTime.Now;

    public virtual ICollection<AlumnoGrado>? AlumnoGrados { get; set; }
}
