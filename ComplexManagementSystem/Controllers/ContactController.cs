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
using ComplexManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace ComplexManagementSystem.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contectRepository;

        public ContactController(IContactRepository contectRepository)
        {
            _contectRepository = contectRepository;
        }

        // GET: Contact
        public IActionResult Index()
        {
            return View(_contectRepository.GetContacts);
        }

        // GET: Contact/Details/5
        public IActionResult Details(int id)
        {
            ContactDetailsViewModel model = new ContactDetailsViewModel();
            model.Contact = _contectRepository.GetContact(id);
            return View(model);
        }

        // GET: Contact/Delete/5
        public IActionResult Delete(int id)
        {
            return View(_contectRepository.GetContact(id));
        }
        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            _contectRepository.RemoveContact(contact);
            return RedirectToAction("Index");
        }
    }
}
