using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComplexManagementSystem.Models
{
    public class House
    {
        public int Id { get; set; }
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
        public int Deposit { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        public string PhotoPath1 { get; set; }
        public string PhotoPath2 { get; set; }
        public string PhotoPath3 { get; set; }
        public string PhotoPath4 { get; set; }
        public string PhotoPath5 { get; set; }
        public string PhotoPath6 { get; set; }
    }
}
