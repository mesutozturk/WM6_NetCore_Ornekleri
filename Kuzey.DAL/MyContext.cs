using System;
using System.Collections.Generic;
using System.Text;
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
    }
}

