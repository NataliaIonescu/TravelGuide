using Microsoft.AspNetCore.Mvc;
using TravelGuide.Models;
using TravelGuide.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TravelGuide.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace TravelGuide.Controllers
{
    public class CitiesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Index(string CityName)
        {
            var cities = await _unitOfWork.Cities.GetAllAsync();
            if (CityName != null)
            {
                var citiesWhichContainName = cities.Where(c => c.CityName.Contains(CityName)).ToList();
                return View(citiesWhichContainName);
            }

            return View(cities);
        }
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _unitOfWork.Cities.IsEmpty())
            {
                return NotFound();
            }

            var city = await _unitOfWork.Cities.GetAsync((int)id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            GetImageNames();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityID,CityName,ImageName")] City city)
        {
            if (!ModelState.IsValid) return View(city);
            _unitOfWork.Cities.Add(city);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _unitOfWork.Cities.IsEmpty())
            {
                return NotFound();
            }

            var city = await _unitOfWork.Cities.GetAsync((int)id);
            if (city == null)
            {
                return NotFound();
            }
            GetImageNames();
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityID,CityName,ImageName")] City city)
        {
            if (id != city.CityID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(city);
            try
            {
                _unitOfWork.Cities.Update(city);
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.Cities.Find(c => c.CityID == id).Any())
                {
                    return NotFound();
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _unitOfWork.Cities.IsEmpty())
            {
                return NotFound();
            }

            var city = await _unitOfWork.Cities.GetAsync((int)id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.Cities.IsEmpty())
            {
                return Problem("Entity set 'TravelContext.Cities'  is null.");
            }
            var city = await _unitOfWork.Cities.GetAsync(id);
            if (city != null)
            {
                _unitOfWork.Cities.Remove(city);
            }

            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private void GetImageNames()
        {
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule!.FileName) + @"\..\..\..\wwwroot\images\gallery";
            string filter = "*.*";
            var files = Directory.GetFiles(folder, filter).Where(s => s.ToLower().EndsWith(".jpg") || s.ToLower().EndsWith(".png") || s.ToLower().EndsWith(".jpeg")).ToArray();
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Substring(files[i].LastIndexOf('\\') + 1, files[i].Length - files[i].LastIndexOf('\\') - 1);
            }
            ViewData["ImageName"] = new SelectList((IEnumerable<string>)files);
        }
    }
}


