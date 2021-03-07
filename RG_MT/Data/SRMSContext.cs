using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RG_MT.Models;

namespace RG_MT.Data
{
    public class SRMSContext : DbContext
    {
        public SRMSContext(DbContextOptions<SRMSContext> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
