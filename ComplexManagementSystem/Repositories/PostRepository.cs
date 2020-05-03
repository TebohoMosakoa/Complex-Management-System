using System;
using System.Collections.Generic;
using ComplexManagementSystem.Data;
using ComplexManagementSystem.Interfaces;
using ComplexManagementSystem.Models;

namespace ComplexManagementSystem.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogPost> GetPosts => _context.Posts;

        public void AddPost(BlogPost post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public BlogPost GetPost(int Id)
        {
            return _context.Posts.Find(Id);
        }

        public BlogPost RemoveHouse(BlogPost post)
        {
            if(post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
            return post;
        }

        public BlogPost UpdatePost(BlogPost post)
        {
            var newPost = _context.Posts.Attach(post);
            newPost.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return post;
        }
    }
}
