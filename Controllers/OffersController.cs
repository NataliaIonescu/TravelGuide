using TravelGuide.Models;
using TravelGuide.UnitOfWork.Interface;
using TravelGuide.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelGuide.UnitOfWork.Interface;
using System;
using TravelGuide.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace TravelGuide.Controllers;

public class OffersController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookingRepository _bookingRepository;
    public OffersController(IUnitOfWork unitOfWork, IBookingRepository bookingRepository)
    {
        _unitOfWork = unitOfWork;
        _bookingRepository = bookingRepository;
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var offers = await _unitOfWork.Offers.GetAllAsync();
        return View(offers);
    }
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> BookOffers()
    {
        var offers = await _unitOfWork.Offers.GetAllAsync();
        return View(offers);
    }
    [HttpPost]
    public IActionResult Book(int offerID)
    {

        // return RedirectToAction("Create", "Bookings"); // Redirect to a suitable action after booking
        return RedirectToAction("Create", "Bookings", new { offerID = offerID });
    }
    [Authorize(Roles = "Admin,User")]

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _unitOfWork.Offers.IsEmpty())
        {
            return NotFound();
        }

        var offer = await _unitOfWork.Offers
            .GetAsync((int)id.Value);

        if (offer == null)
        {
            return NotFound();
        }

        // Load related entities (Hotel and CityTour) using explicit loading
        await _unitOfWork.Offers.LoadRelatedEntitiesAsync(offer, o => o.Hotel, o => o.CityTour);



        return View("Details", offer);
    }



    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        var smth = _unitOfWork.Hotels.GetAll();
        ViewData["HotelID"] = new SelectList(_unitOfWork.Hotels.GetAll(), "HotelID", "HotelName");
        var smth2 = _unitOfWork.CityTours.GetAll();
        ViewData["CityTourID"] = new SelectList(_unitOfWork.CityTours.GetAll(), "CityTourID", "Title");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("OfferID,Title,Description,Price,HotelID,CityTourID")] OfferViewModel cityTourViewModel)
    {
        var offer = new Offer
        {
            OfferID = cityTourViewModel.OfferID,
            Title = cityTourViewModel.Title,
            Description = cityTourViewModel.Description,
            Price = cityTourViewModel.Price,
            HotelID = cityTourViewModel.HotelID,
            CityTourID = cityTourViewModel.CityTourID,
        };

        if (ModelState.IsValid)
        {
            _unitOfWork.Offers.Add(offer);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["HotelID"] = new SelectList(await _unitOfWork.Hotels.GetAllAsync(), "HotelID", "HotelName", offer.HotelID);
        ViewData["CityTour"] = new SelectList(await _unitOfWork.CityTours.GetAllAsync(), "CityTourID", "Title", offer.CityTourID);
        return View(offer);
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _unitOfWork.Offers.IsEmpty())
        {
            return NotFound();
        }

        var offer = await _unitOfWork.Offers.GetAsync((int)id);
        if (offer == null)
        {
            return NotFound();
        }
        ViewData["HotelID"] = new SelectList(await _unitOfWork.Hotels.GetAllAsync(), "HotelID", "HotelName", offer.HotelID);
        ViewData["CityTourID"] = new SelectList(await _unitOfWork.CityTours.GetAllAsync(), "CityTourID", "Title", offer.CityTourID);
        return View(offer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("OfferID,Title,Description,Price,HotelID,CityTourID")] OfferViewModel offerViewModel)
    {
        var offer = new Offer
        {
            OfferID = offerViewModel.OfferID,
            Title = offerViewModel.Title,
            Description = offerViewModel.Description,
            Price = offerViewModel.Price,
            HotelID = offerViewModel.HotelID,
            CityTourID = offerViewModel.CityTourID,
        };

        if (id != offer.OfferID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _unitOfWork.Offers.Update(offer);
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.Offers.Find(bol => bol.OfferID == id).Any())
                {
                    return NotFound();
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["HotelID"] = new SelectList(await _unitOfWork.Hotels.GetAllAsync(), "HotelID", "HotelName", offer.HotelID);
        ViewData["CityTourID"] = new SelectList(await _unitOfWork.CityTours.GetAllAsync(), "CityTourID", "Title", offer.CityTourID);
        return View(offer);
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _unitOfWork.Offers.IsEmpty())
        {
            return NotFound();
        }

        var offer = await _unitOfWork.Offers.GetAsync((int)id);
        if (offer == null)
        {
            return NotFound();
        }

        return View(offer);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_unitOfWork.Offers.IsEmpty())
        {
            return Problem("Entity set 'TravelContext.Offers'  is null.");
        }
        var offer = await _unitOfWork.Offers.GetAsync(id);
        if (offer != null)
        {
            _unitOfWork.Offers.Remove(offer);
        }

        await _unitOfWork.CompleteAsync();
        return RedirectToAction(nameof(Index));
    }
}