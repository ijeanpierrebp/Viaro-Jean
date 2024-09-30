using ViaroTestJean.Models;

namespace ViaroTestJean.Repositories.Interfaces;

public interface IProfesor
{
    public Task<List<Profesor>> GetAllAsync();
    public Task<Profesor> GetByIdAsync(int id);
    public Task CreateAsync(Profesor profesor);
    public Task UpdateAsync(Profesor profesor);
    public Task DeleteAsync(int id);
}
