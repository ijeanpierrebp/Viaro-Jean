using Microsoft.AspNetCore.Mvc;
using ViaroTestJean.Models;
using ViaroTestJean.Repositories.Interfaces;

namespace ViaroTestJean.Controllers;

public class AlumnoGradoController : Controller
{

    private readonly IAlumnoGrado _IAlumnoGrado;

    public AlumnoGradoController(IAlumnoGrado IAlumnoGrado)
    {
        _IAlumnoGrado = IAlumnoGrado;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _IAlumnoGrado.GetAllAsync();
        return View(data);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Alumnos = await _IAlumnoGrado.GetAllAlumnosAsync();
        ViewBag.Grados = await _IAlumnoGrado.GetAllGradosAsync();
        return View(new AlumnoGrado());
    }       

    [HttpPost]
    public async Task<IActionResult> Create(AlumnoGrado alumnoGrado)
    {
        if (ModelState.IsValid)
        {
            await _IAlumnoGrado.CreateAsync(alumnoGrado);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Alumnos = await _IAlumnoGrado.GetAllAlumnosAsync();
        ViewBag.Grados = await _IAlumnoGrado.GetAllGradosAsync();
        return View(alumnoGrado);
    }


    public async Task<IActionResult> Update(int id)
    {
        var data = await _IAlumnoGrado.GetByIdAsync(id);
        if (data == null)        
            return NotFound();
        
        ViewBag.Alumnos = await _IAlumnoGrado.GetAllAlumnosAsync();
        ViewBag.Grados = await _IAlumnoGrado.GetAllGradosAsync();
        return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, AlumnoGrado alumnoGrado)
    {
        if (id != alumnoGrado.Id)
               return BadRequest(); 

        if (ModelState.IsValid)
        {
            await _IAlumnoGrado.UpdateAsync(alumnoGrado);
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Alumnos = await _IAlumnoGrado.GetAllAlumnosAsync();
        ViewBag.Grados = await _IAlumnoGrado.GetAllGradosAsync();
        return View(alumnoGrado);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var data = await _IAlumnoGrado.GetByIdAsync(id);

        if (data == null)        
            return NotFound();
        
        return View(data);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _IAlumnoGrado.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

