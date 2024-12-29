using Microsoft.EntityFrameworkCore;
using School.Models.Entity;
using School.ViewModel;

namespace School.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subjects> Subjects { get; set; }
    public DbSet<Assignment> Assignments { get; set; }

public DbSet<School.ViewModel.AssignmentViewModel> AssignmentViewModel { get; set; } = default!;

}
