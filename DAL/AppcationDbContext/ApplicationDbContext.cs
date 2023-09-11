using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AppcationDbContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions opt) : base(opt)
        {
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }
    }
}
