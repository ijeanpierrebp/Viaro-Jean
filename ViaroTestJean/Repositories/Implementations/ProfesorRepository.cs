using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using ViaroTestJean.Data;
using ViaroTestJean.Models;
using ViaroTestJean.Repositories.Interfaces;

namespace ViaroTestJean.Repositories.Implementations;

public class ProfesorRepository : IProfesor
{
    private readonly ColegioDbContext _db;

    public ProfesorRepository(ColegioDbContext db)
    {
        _db = db;
    }

    public async Task CreateAsync(Profesor profesor)
    {
        try
        {
            await _db.AddAsync(profesor);
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
            var data = await _db.Profesores.Where(x => x.Id == id).FirstOrDefaultAsync();

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

    public async Task<List<Profesor>> GetAllAsync()
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

    public async Task<Profesor> GetByIdAsync(int id)
    {
        try
        {
            var data = await _db.Profesores.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        return new Profesor();
    }

    public async Task UpdateAsync(Profesor profesor)
    {
        try
        {
            _db.Update(profesor);
            await _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }    
}
