using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ViaroTestJean.Models;

public class AlumnoGrado
{
    public int Id { get; set; }
    public int AlumnoId { get; set; }
    public Alumno? Alumno { get; set; }
    public int GradoId { get; set; }
    public Grado? Grado { get; set; }
    public string Secciones { get; set; } = string.Empty;

    [NotMapped]
    public List<string> Seccion
    {
        get => Secciones.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        set => Secciones = string.Join(",", value);
    }
}
