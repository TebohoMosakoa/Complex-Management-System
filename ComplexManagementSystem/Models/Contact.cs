using System;
using System.ComponentModel.DataAnnotations;

namespace ComplexManagementSystem.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public Guid? ListingId { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone {get;set;}
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
