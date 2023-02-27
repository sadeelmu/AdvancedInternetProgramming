using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace DoctorAPI.Data
{
    public class DoctorAPIContext : DbContext
    {
        public DoctorAPIContext (DbContextOptions<DoctorAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Project.Models.DoctorProfile> DoctorProfile { get; set; } = default!;
    }
}
