using System;
using System.Collections.Generic;
using ComplexManagementSystem.Models;

namespace ComplexManagementSystem.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<BlogPost> GetPosts { get; }
        BlogPost GetPost(int Id);
        void AddPost(BlogPost post);
        BlogPost UpdatePost(BlogPost post);
        BlogPost RemoveHouse(BlogPost post);
    }
}
