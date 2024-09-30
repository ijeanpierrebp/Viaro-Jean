using Microsoft.AspNetCore.Mvc;
using ViaroTestJean.Models;
using ViaroTestJean.Repositories.Interfaces;

namespace ViaroTestJean.Controllers;

public class ProfesorController : Controller
{

    private readonly IProfesor _profesor;

    public ProfesorController(IProfesor IPprofesor)
    {
        _profesor = IPprofesor;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _profesor.GetAllAsync();
        return View(data);
    }

    public IActionResult Create()
    {
        return View(new Profesor());
    }


    [HttpPost]
    public async Task<IActionResult> Create(Profesor profesor)
    {
        if (ModelState.IsValid)
        {
            await _profesor.CreateAsync(profesor);
            return RedirectToAction(nameof(Index));
        }
        return View(profesor);
    }

    public async Task<IActionResult> Update(int id)
    {
        var data = await _profesor.GetByIdAsync(id);
        if (data == null)        
            return NotFound();
        
        return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, Profesor profesor)
    {
        if (id != profesor.Id)        
            return BadRequest();
        

        if (ModelState.IsValid)
        {
            await _profesor.UpdateAsync(profesor);
            return RedirectToAction(nameof(Index));
        }
        return View(profesor);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var data = await _profesor.GetByIdAsync(id);
        if (data == null)        
            return NotFound();
        
        return View(data);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _profesor.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
