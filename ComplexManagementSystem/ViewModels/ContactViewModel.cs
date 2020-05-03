using System;
using System.ComponentModel.DataAnnotations;
using ComplexManagementSystem.Models;

namespace ComplexManagementSystem.ViewModels
{
    public class ContactDetailsViewModel
    {
        public Contact Contact { get; set; }
    }
    public class ContactCreateViewModel
    {
        [Required]
        public string FullName { get; set; }
        public Guid? ListingId { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
