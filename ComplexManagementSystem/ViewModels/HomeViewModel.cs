using System;
using System.Collections.Generic;
using ComplexManagementSystem.Models;

namespace ComplexManagementSystem.ViewModels
{
    public class HomeListingViewModel
    {
        public IEnumerable<House> Houses { get; set; }
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public IEnumerable<Agency> Agencies { get; set; }
    }

    
}
