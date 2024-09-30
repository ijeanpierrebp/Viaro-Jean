using ViaroTestJean.Models;

namespace ViaroTestJean.Repositories.Interfaces;

public interface IGrado
{
    public Task<List<Grado>> GetAllAsync();
    public Task<Grado> GetByIdAsync(int id);
    public Task CreateAsync(Grado grado);
    public Task UpdateAsync(Grado grado);
    public Task DeleteAsync(int id);

    public Task<List<Profesor>> GetAllProfesoresAsync();
    public Task<Profesor> GetProfesorByIdAsync(int id);
}
