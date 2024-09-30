using ViaroTestJean.Models;

namespace ViaroTestJean.Repositories.Interfaces;

public interface IAlumno
{
    public Task<List<Alumno>> GetAllAsync();
    public Task<Alumno> GetByIdAsync(int id);
    public Task CreateAsync (Alumno alumno);
    public Task UpdateAsync (Alumno alumno);
    public Task DeleteAsync (int id);
}
