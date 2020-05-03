using System;
using System.ComponentModel.DataAnnotations;

namespace ComplexManagementSystem.Models
{
    public class Agency
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone1 { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone2 { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string About { get; set; }
        public string HomePhoto { get; set; }
        public string AboutPhoto { get; set; }
    }
}
