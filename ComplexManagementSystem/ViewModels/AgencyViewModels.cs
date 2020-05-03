using System;
using System.ComponentModel.DataAnnotations;
using ComplexManagementSystem.Models;
using Microsoft.AspNetCore.Http;

namespace ComplexManagementSystem.ViewModels
{
    public class AgencyDetailViewModels
    {
       public Agency Agency { get; set; }
    }

    public class AgencyCreateViewModels
    {
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
        public IFormFile HomePhoto { get; set; }
        public IFormFile AboutPhoto { get; set; }
    }

    public class AgencyEditViewModels : AgencyCreateViewModels
    {
        public int Id { get; set; }
        public string HomePhotoPath { get; set; }
        public string AboutPhotoPath { get; set; }
    }
}
