using System;
using ListUser_net6.Models;
using Microsoft.EntityFrameworkCore;

namespace ListUser_net6.DB;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder model)
    {
    }

    public DbSet<Person> Persons { get; set; }
}

