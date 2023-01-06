using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsSite.Models;

namespace NewsSite
{
    public class AppDbContent:DbContext
    {
       
        public DbSet <New> News { get; set; }
        public DbSet<Category> Categories { get; set; }

       

        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options) {
            Database.EnsureCreated();
                                
            }


    }
}
