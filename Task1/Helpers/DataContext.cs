namespace Task.Helpers;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Task.Models;


public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseInMemoryDatabase("TestDb");
    }

    public DbSet<Tarefa> Tarefas { get; set; }
}