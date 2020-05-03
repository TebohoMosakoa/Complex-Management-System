using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComplexManagementSystem.Models;
using ComplexManagementSystem.Interfaces;
using ComplexManagementSystem.ViewModels;

namespace ComplexManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IAgencyRepository _agencyRepository;
        private readonly IPostRepository _postRepository;
        private readonly IContactRepository _contact;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHouseRepository houseRepository,ILogger<HomeController> logger,
            IAgencyRepository agencyRepository, IPostRepository postRepository,IContactRepository contact)
        {
            _houseRepository = houseRepository;
            _agencyRepository = agencyRepository;
            _postRepository = postRepository;
            _contact = contact;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var houses = _houseRepository.GetHouses;
            var agancy = _agencyRepository.GetAgencies;
            var posts = _postRepository.GetPosts;
            HomeListingViewModel model = new HomeListingViewModel();
            model.Agencies = agancy;
            model.Houses = houses;
            model.BlogPosts = posts;
            return View(model);
        }

        public IActionResult Properties()
        {
            var houses = _houseRepository.GetHouses;
            return View(houses);
        }
        public IActionResult PropertyDetails(int Id)
        {
            HouseDetailsViewModel model = new HouseDetailsViewModel();
            model.House = _houseRepository.GetHouse(Id);
            return View("HouseContact",model);
        }

        public IActionResult News()
        {
            var blogs = _postRepository.GetPosts;
            return View(blogs);
        }
        public IActionResult NewsDetails(int Id)
        {
            PostDetailsViewModels model = new PostDetailsViewModels();
            model.Post = _postRepository.GetPost(Id);
            return View(model);
        }
        
        public IActionResult About()
        {
            var agency = _agencyRepository.GetAgencies.First();
            return View(agency);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                Contact contact = new Contact
                {
                    FullName = model.FullName,
                    ListingId = model.ListingId,
                    Email = model.Email,
                    Phone = model.Phone,
                    Message = model.Message
                };
                _contact.AddContact(contact);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
