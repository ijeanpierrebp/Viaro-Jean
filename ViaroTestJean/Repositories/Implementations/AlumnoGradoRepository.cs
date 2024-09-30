using ViaroTestJean.Repositories.Interfaces;
using ViaroTestJean.Models;
using ViaroTestJean.Data;
using Microsoft.EntityFrameworkCore;

namespace ViaroTestJean.Repositories.Implementations;

public class AlumnoGradoRepository : IAlumnoGrado
{
    private readonly ColegioDbContext _db;

    public AlumnoGradoRepository(ColegioDbContext db) { 
    
        _db = db;
    }

    public async Task<List<AlumnoGrado>> GetAllAsync()
    {
        try
        {
            return await _db.AlumnoGrados.Include(a => a.Alumno).Include(g => g.Grado).ToListAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new List<AlumnoGrado>();
    }

    public async Task<AlumnoGrado> GetByIdAsync(int id)
    {
        try
        {
            return await _db.AlumnoGrados.Include(a => a.Alumno).Include(g => g.Grado)
           .FirstOrDefaultAsync(a => a.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new AlumnoGrado();
    }

    public async Task CreateAsync(AlumnoGrado alumnoGrado)
    {
        try
        {
            await _db.AlumnoGrados.AddAsync(alumnoGrado);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateAsync(AlumnoGrado alumnoGrado)
    {
        try
        {
            _db.AlumnoGrados.Update(alumnoGrado);
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
            var alumnoGrado = await GetByIdAsync(id);
            if (alumnoGrado != null)
            {
                _db.AlumnoGrados.Remove(alumnoGrado);
                await _db.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }

    public async Task<List<Alumno>> GetAllAlumnosAsync()
    {
        try
        {
            return await _db.Alumnos.ToListAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new List<Alumno>();
    }

    public async Task<List<Grado>> GetAllGradosAsync()
    {
        try
        {
            return await _db.Grados.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new List<Grado>();

    }
}
