using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entity;

namespace OnlineShop.DAL
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Item> Item { get; set; }
    }
}
