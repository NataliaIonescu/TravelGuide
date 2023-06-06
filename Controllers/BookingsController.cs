using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TravelGuide.Models;
using TravelGuide.UnitOfWork.Interface;
using TravelGuide.ViewModels;

namespace TravelGuide.Controllers;

public class BookingsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public BookingsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [Authorize(Roles = "Admin,User")]

    public IActionResult Create(int offerID)
    {
        // ViewData["OfferID"] = new SelectList(_unitOfWork.Offers.GetAll(), "OfferID", "Title");
        var booking = new BookingViewModel
        {
            OfferID = offerID
        };

        return View(booking);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BookingID,OfferID,FirstName,LastName,EmailAddress,PhoneNumber,CardNumber,ExpirationDate,SecurityCode")] BookingViewModel bookingViewModel)
    {
        var booking = new Booking
        {
            BookingID = bookingViewModel.BookingID,
            OfferID = bookingViewModel.OfferID,
            FirstName = bookingViewModel.FirstName,
            LastName = bookingViewModel.LastName,
            EmailAddress = bookingViewModel.EmailAddress,
            PhoneNumber = bookingViewModel.PhoneNumber,
            CardNumber = bookingViewModel.CardNumber,
            ExpirationDate = bookingViewModel.ExpirationDate,
            SecurityCode = bookingViewModel.SecurityCode
        };

        // if (ModelState.IsValid)
        // {
        //     _unitOfWork.Bookings.Add(booking);
        //     await _unitOfWork.CompleteAsync();
        //     return RedirectToAction(nameof(Index));
        // }
        // ViewData["OfferID"] = new SelectList(await _unitOfWork.Offers.GetAllAsync(), "OfferID", "Title", booking.OfferID);
       //  return View(booking);

        if (ModelState.IsValid)
        {
            _unitOfWork.Bookings.Add(booking);
            await _unitOfWork.CompleteAsync();

            // Redirect to the Confirmation view with a success message
            TempData["ConfirmationMessage"] = "Your booking is confirmed. Thank you for booking your next holiday on our website!";
           // return RedirectToAction("Confirmation", "Bookings");
        }

        //ViewData["OfferID"] = new SelectList(await _unitOfWork.Offers.GetAllAsync(), "OfferID", "Title", booking.OfferID);
        return View("Confirmation","Bookings");
    }

}