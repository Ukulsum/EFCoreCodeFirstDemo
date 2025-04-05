using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstDemo.Entities
{
    // EFCoreDbContext class inherits from DbContext, which is the primary class for interacting with the database using EF Core.
    public class EFCoreDbContext : DbContext
    {
        // Constructor that accept DbContextOptions<EFCoreDbContext> as a parameter.
        // The options parameter contains the settings required by EF Core to configure the DbContext,
        // Such as the connection string and provider.
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options) 
        {
            
        }


        // OnConfiguring is an overirde method that allows configuring the DbContext options,
        // like setting the database provider and connection string.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database provider and connection string.
            // UseSqlServer method configures the DbContext to use SQL Server as the database provider.

        }





        // DbSet<Student> Students represents a table in the database corresponding to the Student entity.
        // EF Core uses DbSet<TEntity> to track changes and execute queries relatedto the Student entity.
        public DbSet<Student> Students { get; set; }

        // DbSet<Branch> Branches represents a table in the database corresponding to the Branch entity.
        // Similar to the Students DbSet, this property is used by EF Core to track and manage Branch entities.
        public DbSet<Branch> Branches { get; set; }
    }
}
