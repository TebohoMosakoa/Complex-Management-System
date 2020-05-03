using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComplexManagementSystem.Data;
using ComplexManagementSystem.Models;
using ComplexManagementSystem.Interfaces;
using Microsoft.AspNetCore.Hosting;
using ComplexManagementSystem.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace ComplexManagementSystem.Controllers
{
    [Authorize]
    public class AgencyController : Controller
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        public AgencyController(IAgencyRepository agencyRepository,IHostingEnvironment hostingEnvironment)
        {
            _agencyRepository = agencyRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Agency
        public IActionResult Index()
        {
            return View(_agencyRepository.GetAgencies);
        }

        // GET: Agency/Details/5
        public ActionResult Details(int id)
        {
            AgencyDetailViewModels model = new AgencyDetailViewModels();
            model.Agency = _agencyRepository.GetAgency(id);
            return View(model);
        }

        // GET: Agency/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AgencyCreateViewModels model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                string uniqueFileName1 = null;
                if (model.HomePhoto != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.HomePhoto.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.HomePhoto.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (model.AboutPhoto != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName1 = Guid.NewGuid().ToString() + "_" + model.AboutPhoto.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName1);
                    model.AboutPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Agency newAgency = new Agency
                {
                    Name = model.Name,
                    Phone1 = model.Phone1,
                    Phone2 = model.Phone2,
                    Email = model.Email,
                    About = model.About,
                    HomePhoto = uniqueFileName,
                    AboutPhoto = uniqueFileName1
                };
                _agencyRepository.AddAgency(newAgency);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Agency/Edit/5
        public IActionResult Edit(int id)
        {
            Agency agency = _agencyRepository.GetAgency(id);
            AgencyEditViewModels model = new AgencyEditViewModels
            {
                Id = agency.Id,
                Name = agency.Name,
                Phone1 = agency.Phone1,
                Phone2 = agency.Phone2,
                Email = agency.Email,
                About = agency.About,
                HomePhotoPath = agency.HomePhoto,
                AboutPhotoPath = agency.AboutPhoto
            };
            return View(model);
        }

        // POST: Agency/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AgencyEditViewModels model)
        {
            if(ModelState.IsValid)
            {
                Agency agency = _agencyRepository.GetAgency(model.Id);
                agency.Name = model.Name;
                agency.Phone1 = model.Phone1;
                agency.Phone2 = model.Phone2;
                agency.About = model.About;
                _agencyRepository.UpdateAgency(agency);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Agency/Delete/5
        public IActionResult Delete(int Id)
        {
            var agency = _agencyRepository.GetAgency(Id);
            return View(agency);
        }

        [HttpPost]
        public IActionResult Delete(Agency agency)
        {
            _agencyRepository.RemoveAgency(agency);
            return RedirectToAction("Index");
        }
    }
}
