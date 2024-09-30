using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ViaroTestJean.Data;
using ViaroTestJean.Models;
using ViaroTestJean.Repositories.Interfaces;

namespace ViaroTestJean.Repositories.Implementations;

public class AlumnoRepository : IAlumno
{

    private readonly ColegioDbContext _db;

    public AlumnoRepository(ColegioDbContext db)
    {
        _db = db;
    }

    public async Task CreateAsync(Alumno alumno)
    {
        try
        {
            if (alumno != null)
            {
                await _db.AddAsync(alumno);
                await _db.SaveChangesAsync();
            }
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
            var data = await _db.Alumnos.Where(x => x.Id == id).FirstOrDefaultAsync();
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

    public async Task<List<Alumno>> GetAllAsync()
    {
        try
        {
            var data = await _db.Alumnos.ToListAsync();
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return new List<Alumno>();

    }

    public async Task<Alumno> GetByIdAsync(int id)
    {
        try
        {
            var data = await _db.Alumnos.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new Alumno();

    }

    public async Task UpdateAsync(Alumno alumno)
    {
        try
        {
            _db.Update(alumno);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }
}
