using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViaroTestJean.Data;
using ViaroTestJean.Models;
using ViaroTestJean.Repositories.Implementations;
using ViaroTestJean.Repositories.Interfaces;

namespace ViaroTestJean.Controllers;

public class GradoController : Controller
{
    private readonly IGrado _grado;

    public GradoController(IGrado IGrado)
    {
        _grado = IGrado;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _grado.GetAllAsync();
        return View(data);
    }

    public async Task<IActionResult> Create()
    {
        var profesores = await _grado.GetAllProfesoresAsync();
        ViewBag.Profesores = profesores;
        return View(new Grado());
    }


    [HttpPost]
    public async Task<IActionResult> Create(Grado grado)
    {
        if (ModelState.IsValid)
        {
            var profesor = await _grado.GetProfesorByIdAsync(grado.ProfesorId);
            if (profesor != null)
               grado.NombreProfesor = profesor.Nombre;            

            await _grado.CreateAsync(grado);
            return RedirectToAction(nameof(Index));
        }
        return View(grado);
    }

    public async Task<IActionResult> Update(int id)
    {
        var data = await _grado.GetByIdAsync(id);
        if (data == null)
            return NotFound();

        var profesores = await _grado.GetAllProfesoresAsync();

        if (profesores == null)        
            ViewBag.Profesores = new SelectList(Enumerable.Empty<Profesor>(), "Id", "Nombre");
        
        else        
            ViewBag.Profesores = new SelectList(profesores, "Id", "Nombre", data.ProfesorId);
        
        return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, Grado grado)
    {
        if (id != grado.Id)
            return BadRequest();

        if (ModelState.IsValid)
        {
            var profesor = await _grado.GetProfesorByIdAsync(grado.ProfesorId);
            if (profesor != null)            
                grado.NombreProfesor = profesor.Nombre;            

            await _grado.UpdateAsync(grado);
            return RedirectToAction(nameof(Index));
        }
        return View(grado);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var data = await _grado.GetByIdAsync(id);
        if (data == null)
            return NotFound();
        
        return View(data);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _grado.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
