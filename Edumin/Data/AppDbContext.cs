
using Edumin.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Edumin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<ClassModel> Classes { get; set; }
        public DbSet<GenderModel> Genders { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<DesignationModel> Designations { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
    }
}