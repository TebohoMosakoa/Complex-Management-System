using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ComplexManagementSystem.Models;
using Microsoft.AspNetCore.Http;

namespace ComplexManagementSystem.ViewModels
{
    public class HouseDetailsViewModel
    {
        public House House { get; set; }
    }

    public class HouseCreateViewModel
    {
        [Required]
        public string Type { get; set; }
        public Guid ListingId { get; set; }
        [Required]
        public int NumberOfRooms { get; set; }
        [Required]
        public int NumberOfBathrooms { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public string MiniDescription { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int PricePerMonth { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public int Deposit { get; set; }

        public IFormFile Photo1 { get; set; }
        public IFormFile Photo2 { get; set; }
        public IFormFile Photo3 { get; set; }
        public IFormFile Photo4 { get; set; }
        public IFormFile Photo5 { get; set; }
        public IFormFile Photo6 { get; set; }
    }

    public class HouseEditViewModel : HouseCreateViewModel
    {
        public int Id { get; set; }
        public string CurrentPhotoPath { get; set; }
    }
}
