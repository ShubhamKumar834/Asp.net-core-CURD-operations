using Microsoft.EntityFrameworkCore;
using ShubhamDhimanWebApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShubhamDhimanWebApp1.Data
{
    public class StudentDataContext : DbContext
    {
        public StudentDataContext(DbContextOptions<StudentDataContext> options) : base(options)
        {}
        public DbSet<StudentData> StudentsData { get; set; }

    }
}
