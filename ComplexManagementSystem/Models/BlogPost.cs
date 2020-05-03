using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComplexManagementSystem.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="Enter a topic of maximum length 100 Characters")]
        public string Topic { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Enter a Blog of maximum length 100 Characters")]
        public string MiniParagragh { get; set; }

        [Required]
        [StringLength(5000, ErrorMessage = "Enter a Blog of maximum length 5000 Characters")]
        public string Blog { get; set; }

        public DateTime DateCreated { get; set; }

        public string PhotoPath1 { get; set; }
        public string PhotoPath2 { get; set; }
        public string PhotoPath3 { get; set; }
    }
}
