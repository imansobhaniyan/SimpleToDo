using Microsoft.EntityFrameworkCore;

using SimpleToDo.StorageModels;

namespace SimpleToDo.DataAccessLayer;

public class ToDoDbContext : DbContext
{
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyGroup> CompanyGroups { get; set; }
    public DbSet<CompanyUser> CompanyUsers { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<GroupUser> GroupUsers { get; set; }
    public DbSet<GroupToDo> GroupToDos { get; set; }
    public DbSet<UserToDo> UserToDos { get; set; }
    public DbSet<ToDo> ToDos { get; set; }
}
