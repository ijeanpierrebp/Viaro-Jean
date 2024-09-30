using Microsoft.EntityFrameworkCore;
using ViaroTestJean.Models;

namespace ViaroTestJean.Repositories.Interfaces;

public interface IAlumnoGrado
{  
    public Task<List<AlumnoGrado>> GetAllAsync();
    public Task<AlumnoGrado> GetByIdAsync(int id);
    public Task CreateAsync(AlumnoGrado alumnoGrado);
    public Task UpdateAsync(AlumnoGrado alumnoGrado);
    public Task DeleteAsync(int id);
    public Task<List<Alumno>> GetAllAlumnosAsync();
    public Task<List<Grado>> GetAllGradosAsync();    
}
