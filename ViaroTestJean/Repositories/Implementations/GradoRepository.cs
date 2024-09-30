using Microsoft.EntityFrameworkCore;
using ViaroTestJean.Data;
using ViaroTestJean.Models;
using ViaroTestJean.Repositories.Interfaces;

namespace ViaroTestJean.Repositories.Implementations;

public class GradoRepository : IGrado
{

    private readonly ColegioDbContext _db;


    public GradoRepository(ColegioDbContext db)
    {
        _db = db;
    }

    public async Task CreateAsync(Grado grado)
    {
        try
        {
            await _db.AddAsync(grado);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var data = await _db.Grados.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (data != null)
            {
                _db.Remove(data);
                await _db.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }

    public async Task<List<Grado>> GetAllAsync()
    {
        try
        {
            var data = await _db.Grados.ToListAsync();
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new List<Grado>();
    }

    public async Task<Grado> GetByIdAsync(int id)
    {
        try
        {
            var data = await _db.Grados.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new Grado();
    }

    public async Task UpdateAsync(Grado grado)
    {
        try
        {
            _db.Update(grado);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task<List<Profesor>> GetAllProfesoresAsync()
    {
        try
        {
            var data = await _db.Profesores.ToListAsync();
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new List<Profesor>();
    }

    public async Task<Profesor> GetProfesorByIdAsync(int id)
    {
        try
        {
            return await _db.Profesores.FindAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new Profesor();
    }
}
