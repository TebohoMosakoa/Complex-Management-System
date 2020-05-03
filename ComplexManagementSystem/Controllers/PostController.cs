using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComplexManagementSystem.Data;
using ComplexManagementSystem.Models;
using ComplexManagementSystem.Interfaces;
using Microsoft.AspNetCore.Hosting;
using ComplexManagementSystem.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace ComplexManagementSystem.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public PostController(IPostRepository postRepository, IHostingEnvironment hostingEnvironment)
        {
            _postRepository = postRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Post
        public IActionResult Index()
        {
            return View(_postRepository.GetPosts);
        }

        // GET: Post/Details/5
        public IActionResult Details(int Id)
        {
            PostDetailsViewModels model = new PostDetailsViewModels();
            model.Post = _postRepository.GetPost(Id);
            return View(model);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                string uniqueFileName1 = null;
                string uniqueFileName2 = null;
                if (model.Photo1 != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo1.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo1.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (model.Photo2 != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName1 = Guid.NewGuid().ToString() + "_" + model.Photo2.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName1);
                    model.Photo2.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (model.Photo3 != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName2 = Guid.NewGuid().ToString() + "_" + model.Photo3.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName2);
                    model.Photo3.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                BlogPost newPost = new BlogPost
                {
                    Topic = model.Topic,
                    MiniParagragh = model.MiniParagragh,
                    Blog = model.Blog,
                    DateCreated = DateTime.Now,
                    PhotoPath1 = uniqueFileName,
                    PhotoPath2 = uniqueFileName1,
                    PhotoPath3 = uniqueFileName2
                };
                _postRepository.AddPost(newPost);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Post/Edit/5
        public IActionResult Edit(int id)
        {
            BlogPost post = _postRepository.GetPost(id);
            PostEditViewModel model = new PostEditViewModel
            {
                Id = post.Id,
                Topic = post.Topic,
                MiniParagragh = post.MiniParagragh,
                Blog = post.Blog,
                DateCreated = post.DateCreated,
                CurrentPhotoPath = post.PhotoPath1
            };
            return View(model);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PostEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                BlogPost post = _postRepository.GetPost(model.Id);
                post.Topic = model.Topic;
                post.MiniParagragh = model.MiniParagragh;
                post.Blog = model.Blog;
                post.DateCreated = model.DateCreated;
                _postRepository.UpdatePost(post);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Post/Delete/5
        public IActionResult Delete(int id)
        {
            var post = _postRepository.GetPost(id);
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public IActionResult Delete(BlogPost post)
        {
            _postRepository.RemoveHouse(post);
            return RedirectToAction(nameof(Index));
        }
    }
}
