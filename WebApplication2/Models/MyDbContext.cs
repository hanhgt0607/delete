using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public class Category
        {
            public long id { get; set; }
            public string name { get; set; }
        }
        public class Product
        {
            public long id { get; set; }
            public string name { get; set; }
            public string price { get; set; }
        }
    }
}
