using TravelGuide.Models;
using TravelGuide.UnitOfWork.Interface;
using TravelGuide.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace TravelGuide.Controllers;
[Authorize(Roles = "Admin")]
public class HotelsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public HotelsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

  
    public async Task<IActionResult> Index()
    {
        var hotels = await _unitOfWork.Hotels.GetAllAsync();
        return View(hotels);
    }

   
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _unitOfWork.Hotels.IsEmpty())
        {
            return NotFound();
        }

        var hotel = await _unitOfWork.Hotels.GetAsync((int)id);
        if (hotel == null)
        {
            return NotFound();
        }

        return View(hotel);
    }

  
    public IActionResult Create()
    {
        return View();
    }

 
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("HotelID,HotelName,Description,Address")] HotelViewModel hotelViewModel)
    {
        var hotel = new Hotel
        {
            HotelID = hotelViewModel.HotelID,
            HotelName = hotelViewModel.HotelName,
            Description = hotelViewModel.Description,
            Address = hotelViewModel.Address 
        };

        if (!ModelState.IsValid) return View(hotel);

        _unitOfWork.Hotels.Add(hotel);
        await _unitOfWork.CompleteAsync();
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _unitOfWork.Hotels.IsEmpty())
        {
            return NotFound();
        }

        var hotel = await _unitOfWork.Hotels.GetAsync((int)id);
        if (hotel == null)
        {
            return NotFound();
        }
        return View(hotel);
    }

   
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("HotelID,HotelName,Description,Address")] HotelViewModel hotelViewModel)
    {
        var hotel = new Hotel
        {
            HotelID = hotelViewModel.HotelID,
            HotelName = hotelViewModel.HotelName,
            Description = hotelViewModel.Description,
            Address = hotelViewModel.Address,
            
        };

        if (id != hotel.HotelID)
        {
            return NotFound();
        }

        if (!ModelState.IsValid) return View(hotel);

        try
        {
            _unitOfWork.Hotels.Update(hotel);
            await _unitOfWork.CompleteAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_unitOfWork.Hotels.Find(h => h.HotelID == id).Any())
            {
                return NotFound();
            }

            throw;
        }
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _unitOfWork.Hotels.IsEmpty())
        {
            return NotFound();
        }

        var hotel = await _unitOfWork.Hotels.GetAsync((int)id);
        if (hotel == null)
        {
            return NotFound();
        }

        return View(hotel);
    }

   
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_unitOfWork.Hotels.IsEmpty())
        {
            return Problem("Entity set 'TravelContext.Hotels'  is null.");
        }
        var hotel = await _unitOfWork.Hotels.GetAsync(id);
        if (hotel != null)
        {
            _unitOfWork.Hotels.Remove(hotel);
        }

        await _unitOfWork.CompleteAsync();
        return RedirectToAction(nameof(Index));
    }
}