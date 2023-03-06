using AspNetCore_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_WebAPI.Repository
{
  public class APIDbContext : DbContext
  {
    public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
    {

    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
  }
}
