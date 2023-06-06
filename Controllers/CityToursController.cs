using TravelGuide.Models;
using TravelGuide.UnitOfWork.Interface;
using TravelGuide.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelGuide.UnitOfWork.Interface;
using Microsoft.AspNetCore.Authorization;

namespace TravelGuide.Controllers;
[Authorize(Roles ="Admin")]
public class CityToursController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CityToursController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var cityTours = await _unitOfWork.CityTours.GetAllAsync();
        return View(cityTours);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _unitOfWork.CityTours.IsEmpty())
        {
            return NotFound();
        }

        var cityTours = await _unitOfWork.CityTours.GetAsync((int)id.Value);
        if (cityTours == null)
        {
            return NotFound();
        }

        return View(cityTours);
    }

    public IActionResult Create()
    {
        var smth = _unitOfWork.Cities.GetAll();
        ViewData["CityID"] = new SelectList(_unitOfWork.Cities.GetAll(), "CityID", "CityName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CityTourID,Title,Description,Itinerary,Duration,CityID")] CityTourViewModel cityTourViewModel)
    {
        var cityTour = new CityTour
        {
            CityTourID = cityTourViewModel.CityTourID,
            Title = cityTourViewModel.Title,
            Description = cityTourViewModel.Description,
            Itinerary = cityTourViewModel.Itinerary,
            Duration = cityTourViewModel.Duration,
            CityID = cityTourViewModel.CityID,
        };

        if (ModelState.IsValid)
        {
            _unitOfWork.CityTours.Add(cityTour);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
        
        ViewData["CityID"] = new SelectList(await _unitOfWork.Cities.GetAllAsync(), "CityID", "CityName", cityTour.CityID);
        return View(cityTour);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _unitOfWork.CityTours.IsEmpty())
        {
            return NotFound();
        }

        var cityTour = await _unitOfWork.CityTours.GetAsync((int)id);
        if (cityTour == null)
        {
            return NotFound();
        }
        
        ViewData["CityID"] = new SelectList(await _unitOfWork.Cities.GetAllAsync(), "CityID", "CityName", cityTour.CityID);
        return View(cityTour);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CityTourID,Title,Description,Itinerary,Duration,CityID")] CityTourViewModel cityTourViewModel)
    {
        var cityTour = new CityTour
        {
            CityTourID = cityTourViewModel.CityTourID,
            Title = cityTourViewModel.Title,
            Description = cityTourViewModel.Description,
            Itinerary = cityTourViewModel.Itinerary,
            Duration = cityTourViewModel.Duration,
            CityID = cityTourViewModel.CityID,
        };

        if (id != cityTour.CityTourID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _unitOfWork.CityTours.Update(cityTour);
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.CityTours.Find(bol => bol.CityTourID == id).Any())
                {
                    return NotFound();
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        
        ViewData["CityID"] = new SelectList(await _unitOfWork.Cities.GetAllAsync(), "CityID", "CityName", cityTour.CityID);
        return View(cityTour);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _unitOfWork.CityTours.IsEmpty())
        {
            return NotFound();
        }

        var cityTour = await _unitOfWork.CityTours.GetAsync((int)id);
        if (cityTour == null)
        {
            return NotFound();
        }

        return View(cityTour);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_unitOfWork.CityTours.IsEmpty())
        {
            return Problem("Entity set 'TravelContext.CityTours'  is null.");
        }
        var cityTour = await _unitOfWork.CityTours.GetAsync(id);
        if (cityTour != null)
        {
            _unitOfWork.CityTours.Remove(cityTour);
        }

        await _unitOfWork.CompleteAsync();
        return RedirectToAction(nameof(Index));
    }
}