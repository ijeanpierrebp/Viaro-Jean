using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using ViaroTestJean.Models;
using ViaroTestJean.Repositories.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ViaroTestJean.Controllers;

public class AlumnoController : Controller
{
    private readonly IAlumno _IAlumno;

    public AlumnoController(IAlumno IAlumno)
    {
        _IAlumno = IAlumno;
    }

    public async Task <IActionResult> Index()
    {
        var data = await _IAlumno.GetAllAsync();
        return View(data);
    }

    public  IActionResult Create()
    {
        return View(new Alumno());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Alumno alumno)
    {
        if (ModelState.IsValid)
        {
            await _IAlumno.CreateAsync(alumno);
            return RedirectToAction(nameof(Index));
        }
        return View(alumno);
    }

    public async Task<IActionResult> Update(int id)
    {
        var data = await _IAlumno.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, Alumno alumno)
    {
        if (id != alumno.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            await _IAlumno.UpdateAsync(alumno);
            return RedirectToAction(nameof(Index));
        }
        return View(alumno);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var data = await _IAlumno.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return View(data);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _IAlumno.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
