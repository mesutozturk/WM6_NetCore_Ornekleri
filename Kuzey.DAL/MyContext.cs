using System;
using System.Collections.Generic;
using System.Text;
using Kuzey.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kuzey.DAL
{
    public class MyContext : IdentityDbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}

