using System.ComponentModel.DataAnnotations;

namespace ViaroTestJean.Models;

public class Profesor
{
    public int Id { get; set; }    
    [Required] public string Nombre { get; set; } = string.Empty;
    [Required] public string Apellidos { get; set; } = string.Empty;
    [Required] public string Genero { get; set; } = string.Empty;
}
