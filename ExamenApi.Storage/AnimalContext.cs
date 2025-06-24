using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenApi.Core.Models;


public class AnimalContext : DbContext
    {
    private readonly string _connectionString;

    public AnimalContext()
    {

    }

    public AnimalContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AnimalAppDB;Integrated Security=True");
    }

    public DbSet<Animal> Animals { get; set; }

    }

