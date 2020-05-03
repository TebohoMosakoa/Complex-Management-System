using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ComplexManagementSystem.Models;
using Microsoft.AspNetCore.Http;

namespace ComplexManagementSystem.ViewModels
{
    public class PostDetailsViewModels
    {
        public BlogPost Post { get; set; }
    }

    public class PostCreateViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Enter a topic of maximum length 100 Characters")]
        public string Topic { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Enter a Blog of maximum length 100 Characters")]
        public string MiniParagragh { get; set; }

        [Required]
        [StringLength(5000, ErrorMessage = "Enter a Blog of maximum length 5000 Characters")]
        public string Blog { get; set; }

        public DateTime DateCreated { get; set; }

        public IFormFile Photo1 { get; set; }
        public IFormFile Photo2 { get; set; }
        public IFormFile Photo3 { get; set; }
    }

    public class PostEditViewModel : PostCreateViewModel
    {
        public int Id { get; set; }
        public string CurrentPhotoPath { get; set; }
    }
}
