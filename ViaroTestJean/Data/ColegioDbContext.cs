using Microsoft.EntityFrameworkCore;
using ViaroTestJean.Models;

namespace ViaroTestJean.Data;

public class ColegioDbContext : DbContext
{
    public DbSet<AlumnoGrado> AlumnoGrados { get; set; }
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Grado> Grados { get; set; }
    public DbSet<Profesor> Profesores { get; set; }

    public ColegioDbContext(DbContextOptions<ColegioDbContext> op):base(op){ }

}
