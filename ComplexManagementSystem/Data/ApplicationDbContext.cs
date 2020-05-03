using System;
using System.Collections.Generic;
using System.Text;
using ComplexManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComplexManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
