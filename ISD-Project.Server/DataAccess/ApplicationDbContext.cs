﻿using ISD_Project.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ISD_Project.Server.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        
        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,IConfiguration configuration) : base(options)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User> Users { get; set; }

    }
}
