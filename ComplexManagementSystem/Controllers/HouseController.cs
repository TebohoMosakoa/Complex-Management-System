using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ComplexManagementSystem.Interfaces;
using ComplexManagementSystem.Models;
using ComplexManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComplexManagementSystem.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HouseController(IHouseRepository houseRepository, IHostingEnvironment hostingEnvironment)
        {
            _houseRepository = houseRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var houses = _houseRepository.GetHouses;
            return View(houses);
        }

        public IActionResult Details(int Id)
        {
            HouseDetailsViewModel model = new HouseDetailsViewModel();
            model.House = _houseRepository.GetHouse(Id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HouseCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                string uniqueFileName1 = null;
                string uniqueFileName2 = null;
                string uniqueFileName3 = null;
                string uniqueFileName4 = null;
                string uniqueFileName5 = null;
                if (model.Photo1 != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo1.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo1.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (model.Photo2 != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName1 = Guid.NewGuid().ToString() + "_" + model.Photo2.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName1);
                    model.Photo2.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (model.Photo3 != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName2 = Guid.NewGuid().ToString() + "_" + model.Photo3.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName2);
                    model.Photo3.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (model.Photo4 != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName3 = Guid.NewGuid().ToString() + "_" + model.Photo4.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName3);
                    model.Photo4.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (model.Photo5 != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName4 = Guid.NewGuid().ToString() + "_" + model.Photo5.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName4);
                    model.Photo5.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (model.Photo6 != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName5 = Guid.NewGuid().ToString() + "_" + model.Photo6.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName5);
                    model.Photo6.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                House newhouse = new House
                {
                    Type = model.Type,
                    ListingId = new Guid(),
                    NumberOfRooms = model.NumberOfRooms,
                    NumberOfBathrooms = model.NumberOfBathrooms,
                    Size = model.Size,
                    MiniDescription = model.MiniDescription,
                    Description = model.Description,
                    Price = model.Price,
                    PricePerMonth = model.PricePerMonth,
                    Deposit = model.Deposit,
                    StreetAddress = model.StreetAddress,
                    PhotoPath1 = uniqueFileName,
                    PhotoPath2 = uniqueFileName1,
                    PhotoPath3 = uniqueFileName2,
                    PhotoPath4 = uniqueFileName3,
                    PhotoPath5 = uniqueFileName4,
                    PhotoPath6 = uniqueFileName5
                };
                _houseRepository.AddHouse(newhouse); 
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            House house = _houseRepository.GetHouse(Id);
            HouseEditViewModel model = new HouseEditViewModel
            {
                Id = house.Id,
                Type = house.Type,
                NumberOfRooms = house.NumberOfRooms,
                NumberOfBathrooms = house.NumberOfBathrooms,
                Size = house.Size,
                MiniDescription = house.MiniDescription,
                Description = house.Description,
                Price = house.Price,
                Deposit = house.Deposit,
                PricePerMonth = house.PricePerMonth,
                StreetAddress = house.StreetAddress,
                CurrentPhotoPath = house.PhotoPath1
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(HouseEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                House house = _houseRepository.GetHouse(model.Id);
                house.Type = model.Type;
                house.NumberOfRooms = model.NumberOfRooms;
                house.NumberOfBathrooms = model.NumberOfBathrooms;
                house.Size = model.Size;
                house.MiniDescription = model.MiniDescription;
                house.Description = model.Description;
                house.Price = model.Price;
                house.Deposit = model.Deposit;
                house.PricePerMonth = model.PricePerMonth;
                house.StreetAddress = model.StreetAddress;
                _houseRepository.UpdateHouse(house);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var house = _houseRepository.GetHouse(Id);
            return View(house);
        }

        [HttpPost]
        public IActionResult Delete(House house)
        {
            _houseRepository.RemoveHouse(house);
            return RedirectToAction("Index");
        }
    }
}
